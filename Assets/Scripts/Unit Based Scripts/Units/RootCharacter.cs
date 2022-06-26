using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCharacter : RootEntity
{
    public bool isAlive = true;
    public bool inCombat = false;
    public bool hasSpeech = false;
    public Hostility hostility;
    public RootAbility abilityPreparingToCast = null;
    public RootAbility abilityBeingCast = null;
    public float currentCastingTime = 0;
    public float talkRange = 3.2f;
    public float attackTimer = 0;
    public float moveAbilityTimer = 0;
    public int size = 2;
    public bool attackable = true;
    public Transform primarySpellCastLocation;
    public Transform mainhandWeapon;
    public Transform offhandWeaponLocation;
    public float waistHight = 1f;
    public CharacterInventory charInventory = new CharacterInventory();
    public ConsumableInventoryItem quickItem;
    public UnitStats totalStats = new UnitStats();
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public UnitParticleParent particleParent;
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll unitEquipment = new EquipmentDoll();
    public List<RootAbility> knownAbilities = new List<RootAbility>();
    public float globalCooldown = 0;
    public List<RootAbility> abilitiesOnCooldown = new List<RootAbility>();
    public PopupTextManager popupTextManager;
    public List<Status> activeStatuses = new List<Status>();
    public RootCharacter currentTarget;
    public float timer;
    public ActionState actionState = ActionState.Idle;
    public MovementState movementState = MovementState.Idle;
    public SprintState sprintState = SprintState.Idle;
    public bool pushedBeyondMaxSpeed = false;
    public Vector3 eyesOffset = new Vector3(0, 2, 0);
    public Animator animator;
    public Rigidbody unitBody;
    public UnitUIManager uiCollection;

    public UnitParticleParent particleStateParent;

    public event EventHandler<Status> StatusGained;
    public event EventHandler<Status> StatusLost;

    public void BasicStart()
    {
        InitializeUnitUI();
        RigParticles();
    }

    public void RigParticles()
    {
        state.BurnParticles = particleParent.BurnParticles;
        state.OverchargeParticles = particleParent.OverchargeParticles;
        state.SoulRotParticles = particleParent.SoulRotParticles;
        state.DecayParticles = particleParent.DecayParticles;
        state.BleedParticles = particleParent.BleedParticles;
    }

    public void InitializeUnitUI()
    {
        uiCollection = GetComponent<UnitUIManager>();
        GameObject newUICollection = Instantiate(Resources.Load("Prefabs/UIComponents/UnitUICollectionObject")) as GameObject;
        newUICollection.name = gameObject.name + "UICollectionObject";
        newUICollection.transform.SetParent(GameObject.Find("UnitUICollection").transform);
        newUICollection.transform.position = new Vector3(-200, -200, 0);
        uiCollection.parentPane = newUICollection.transform;
        Transform anchor = transform.Find("UnitUIAnchor");
        if (anchor != null)
            uiCollection.DelayedStart(anchor, newUICollection.transform.Find("Floating_Damage").GetComponent<FloatingDamage>(), newUICollection.transform.Find("Floating_Healing").GetComponent<FloatingHealing>(), GameObject.Find(newUICollection.name).GetComponent<CanvasGroup>());
        else
            uiCollection.DelayedStart(transform, newUICollection.transform.Find("Floating_Damage").GetComponent<FloatingDamage>(), newUICollection.transform.Find("Floating_Healing").GetComponent<FloatingHealing>(), GameObject.Find(newUICollection.name).GetComponent<CanvasGroup>());

        uiCollection.enemyHealthBar = newUICollection.transform.Find("DamagedHealthBar").GetComponent<EnemyHealthBar>();
        uiCollection.enemyHealthBar.character = this;
    }

    public void Shove(float pushForce, Vector3 direction)
    {
        unitBody.AddForce(direction * pushForce, ForceMode.Impulse);
        pushedBeyondMaxSpeed = true;
    }

    public void IncrementTimers()
    {
        timer += Time.deltaTime;
        moveAbilityTimer += Time.deltaTime;
        globalCooldown = Mathf.Clamp(globalCooldown -= Time.deltaTime, 0, 100);
        if (abilitiesOnCooldown.Count > 0)
        {
            for (int i = abilitiesOnCooldown.Count - 1; i > -1; i--)
            {
                abilitiesOnCooldown[i].cooldown = Mathf.Clamp(abilitiesOnCooldown[i].cooldown -= Time.deltaTime, 0, 100000000);
                if (abilitiesOnCooldown[i].cooldown == 0)
                    abilitiesOnCooldown.RemoveAt(i);
            }
        }
    }

    public bool InteractRangeCheck(WorldObject currentInteractTarget)
    {
        if (Vector3.Distance(currentInteractTarget.transform.position, this.transform.position) <= currentInteractTarget.distanceToBeInteracted)
            return true;
        else
            return false;
    }

    public void AddStatus(Status status)
    {
        Status foundStatus = activeStatuses.Find(x => x.statusId == status.statusId);

        if (foundStatus != null && status.sourceUnit == foundStatus.sourceUnit)
        {
            if (status.refreshable)
            {
                foundStatus.currentDuration = status.maxDuration;
            }
            if (status.stackable)
            {
                if (status.stacks < status.maxStacks)
                    foundStatus.stacks++;
            }
            return;
        }

        activeStatuses.Add(status);
        StatusGained?.Invoke((PlayerCharacterUnit)this, status);
        status.currentDuration = status.maxDuration;
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.IncreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }

    }

    public void RemoveStatus(Status status)
    {
        activeStatuses.Remove(status);
        status.setToRemove = true;
        StatusLost?.Invoke((PlayerCharacterUnit)this, status);
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.DecreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public virtual void AddState(StateEffect status)
    {
        state.AddState(status);
    }

    public void ResolveStatuses()
    {
        float totalStatusChange = 0;

        for (int i = activeStatuses.Count - 1; i > -1; i--)
        {
            totalStatusChange += activeStatuses[i].rate * Time.deltaTime;
            activeStatuses[i].currentDuration -= Time.deltaTime;
            if (activeStatuses[i].currentDuration <= 0)
            {
                RemoveStatus(activeStatuses[i]);
            }
        }
        if (totalStatusChange != 0)
        {
            if (totalStatusChange > 0)
                InflictDamage(totalStatusChange, true);
            else
                InflictHealing(totalStatusChange, true);
        }
    }

    public virtual void InflictDamage(float value, bool overTime)
    {
        if (value != 0)
        {
            totalStats.ModifyHealth(-value);
            if (overTime)
            {
                uiCollection.floatingDamage.AddDot(value);
                uiCollection.enemyHealthBar.ResetDisplayTimer();
            }
            else
            {
                uiCollection.floatingDamage.AddHit(value, value / totalStats.Health_Max);
                uiCollection.enemyHealthBar.ResetDisplayTimer();
            }
        }
    }

    public virtual void InflictHealing(float value, bool overTime)
    {
        if (value != 0)
        {
            totalStats.ModifyHealth(value);
            if (overTime)
                uiCollection.floatingHealing.AddHot(value);
            else
                uiCollection.floatingHealing.AddHit(value);
        }
    }

    public void ActiveAbilityCheck()
    {
        if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Attack)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
        {
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            if (currentCastingTime > abilityPreparingToCast.GetCastTime())
            {
                actionState = ActionState.Casting;
                abilityBeingCast = abilityPreparingToCast;
                if (entityType == EntityType.Player)
                    animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
                else
                    Cast();
                FinishPreparingToCast(false);
            }
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
        {
            actionState = ActionState.Channeling;
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            totalStats.Channel_Current = Mathf.Clamp(totalStats.Channel_Current + (totalStats.Channel_Rate * Time.deltaTime), totalStats.Channel_Default, totalStats.Channel_Max);
            if (currentCastingTime > .25f)
            {
                if (totalStats.Mana_Current - abilityPreparingToCast.GetCost() < 0)
                {
                    abilityPreparingToCast = null;
                    currentCastingTime = 0;
                    totalStats.Channel_Current = totalStats.Channel_Default;
                    actionState = ActionState.Idle;
                    return;
                }
                abilityBeingCast = abilityPreparingToCast;
                Cast();

                totalStats.Mana_Current -= abilityPreparingToCast.GetCost();
                currentCastingTime -= .25f;
            }
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
        {
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            currentCastingTime = Mathf.Clamp(currentCastingTime, 0, abilityPreparingToCast.GetCastTime() * (1 + totalStats.Charge_Max_AddPercent.value));
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            actionState = ActionState.Casting;
            abilityBeingCast = abilityPreparingToCast;
            if (entityType == EntityType.Player)
                animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
            else
                Cast();
            
            FinishPreparingToCast(false);
        }
    }

    public void Cast()
    {
        var cmType = abilityBeingCast.castModeRune.castModeRuneType;
        totalStats.Mana_Current -= abilityBeingCast.GetCost() / (1 + totalStats.Mana_Cost_AddPercent.value) / totalStats.Mana_Cost_MultiplyPercent.value;
        abilityBeingCast.cooldown = abilityBeingCast.schoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);

        RootAbilityForm worldAbility = null;

        if (abilityBeingCast is BasicAbility)
            worldAbility = AbilityFactory.InstantiateBasicWorldAbility((BasicAbility)abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, RootAbility.CreationMethod.UnitCast, null).GetComponent<BasicAbilityForm>();
        else if (abilityBeingCast is UniqueAbility)
            worldAbility = AbilityFactory.InstantiateUniqueWorldAbility((UniqueAbility)abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, RootAbility.CreationMethod.UnitCast, null).GetComponent<UniqueAbilityForm>();
        if (entityType == EntityType.Character)
            worldAbility.targetPreference = currentTarget.transform;
        GlobalEventManager.AbilityCastTrigger(this, worldAbility, this, transform.position);
        if (worldAbility.ability.effectRunes != null)
        {
            foreach (var rune in worldAbility.ability.effectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                {
                    if (rune.targetSelf)
                        rune.Effect(this, this, worldAbility);
                }
            }
        }

        abilityBeingCast.abilityStateManager.ApplyStateOnCast(this);

        if (cmType == Rune.CastModeRuneTag.Attack)
        {
            actionState = ActionState.Attacking;
        }
        else if (cmType == Rune.CastModeRuneTag.CastTime)
        {
            actionState = ActionState.Idle;

            if (abilityBeingCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
                totalStats.ExpendCharge(abilityBeingCast.schoolRune.schoolRuneType);

            FinishPreparingToCast(false);
            abilityBeingCast = null;
        }
        else if (cmType == Rune.CastModeRuneTag.Channel)
        {
            abilityBeingCast = null;
        }
        else if (cmType == Rune.CastModeRuneTag.Charge)
        {
            actionState = ActionState.Idle;
        }
        else if (cmType == Rune.CastModeRuneTag.Instant)
        {
            actionState = ActionState.Idle;
        }
        else if (cmType == Rune.CastModeRuneTag.Reserve)
        {
            actionState = ActionState.Idle;
        }
    }

    public void ManualReserve()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        if (currentCastingTime > totalStats.ReserveRecoveryTime_Default)
        {
            //animator.SetTrigger(abilityCharging.aFormRune.formAnimation);

            totalStats.RecoverReserve(abilityPreparingToCast.schoolRune.schoolRuneType);
            currentCastingTime = 0;
            if (totalStats.IsReserveFull(abilityPreparingToCast.schoolRune.schoolRuneType))
            {
                abilityPreparingToCast = null;
                currentCastingTime = 0;
                actionState = ActionState.Idle;
            }
        }
    }

    public void ChargeCast()
    {
        actionState = ActionState.Casting;
        if (entityType == EntityType.Player)
            animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
        else
            Cast();
        abilityBeingCast = abilityPreparingToCast;
        ((CastModeRune_Charge)abilityBeingCast.castModeRune).chargeAmount = currentCastingTime / (abilityBeingCast.GetCastTime() * (1 + totalStats.Charge_Max_AddPercent.value));
        FinishPreparingToCast(false);
    }

    public virtual void LifeCheck()
    {
        if (totalStats.Health_Current > totalStats.Health_Max)
            totalStats.Health_Current = totalStats.Health_Max;

        if (totalStats.Health_Current <= 0)
        {
            Kill();
        }
    }

    public virtual void RegenTick()
    {
        if (state.Decaying == false)
            if (totalStats.Health_Current < totalStats.Health_Max)
                totalStats.Health_Current = Mathf.Clamp((totalStats.Health_Current + totalStats.Health_Regeneration * Time.deltaTime), 0, totalStats.Health_Max);
        if (totalStats.Mana_Current < totalStats.Mana_Max)
            totalStats.Mana_Current = Mathf.Clamp((totalStats.Mana_Current + totalStats.Mana_Regeneration * Time.deltaTime), 0, totalStats.Mana_Max);
    }

    public void Kill()
    {
        totalStats.Health_Current = 0;
        isAlive = false;
        state.ClearState();
        for (int i = activeStatuses.Count - 1; i >= 0; i--)
        {
            RemoveStatus(activeStatuses[i]);
        }
    }

    public virtual void StopCast()
    {
        currentCastingTime = 0;
        abilityPreparingToCast = null;
    }

    public void FinishPreparingToCast(bool continueShowingCastBar)
    {
        currentCastingTime = 0;
        abilityPreparingToCast = null;
    }

    public void StandardUnitTick()
    {
        IncrementTimers();

        if (isAlive == true)
        {
            RegenTick();
            ResolveStatuses();
            state.StateTick(this);
            LifeCheck();
        }
    }
}

public enum ActionState
{
    Idle,
    Animating,
    Attacking,
    Casting,
    Channeling,
    PreparingAbility,
    Reserving
}

public enum MovementState
{
    Idle,
    Moving
}

public enum SprintState
{
    Idle,
    Sprinting
}

public enum Hostility
{
    Hostile,
    Passive
}