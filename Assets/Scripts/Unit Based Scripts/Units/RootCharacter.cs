using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCharacter : RootEntity
{
    public int team = 2;
    public bool inCombat = false;
    public bool hasSpeech = false;
    public Hostility hostility;
    public bool isAlive = true;
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
    public UnitStats totalStats = new UnitStats();
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll unitEquipment = new EquipmentDoll();
    public float globalCooldown = 0;
    public List<RootAbility> abilitiesOnCooldown = new List<RootAbility>();
    public PopupTextManager popupTextManager;
    public List<Status> activeStatuses = new List<Status>();
    public float timer;
    public ActionState actionState = ActionState.Idle;
    public MovementState movementState = MovementState.Idle;
    public SprintState sprintState = SprintState.Idle;
    public bool pushedBeyondMaxSpeed = false;
    public Vector3 eyesOffset = new Vector3(0, 2, 0);
    public Animator animator;
    public Rigidbody unitBody;
    public UnitUIManager uiCollection;

    public void BasicStart()
    {
        InitializeUnitUI();
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

    bool PickupRangeCheck(WorldItem currentItemTarget)
    {
        if (Vector3.Distance(currentItemTarget.transform.position, this.transform.position) <= 1)
            return true;
        else
            return false;
    }

    public bool InteractRangeCheck(WorldObject currentInteractTarget)
    {
        if (Vector3.Distance(currentInteractTarget.transform.position, this.transform.position) <= currentInteractTarget.distanceToBeInteracted)
            return true;
        else
            return false;
    }

    public virtual void AddStatus(Status status)
    {
        Status foundStatus = activeStatuses.Find(x => x.name == status.name);

        if (foundStatus != null)
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
        }
        else
        {
            activeStatuses.Add(status);
            status.currentDuration = status.maxDuration;
            foreach (ModifierGroup modifierGroup in status.modifierGroups)
            {
                totalStats.IncreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
            }
        }

    }

    public virtual void RemoveStatus(Status status)
    {
        activeStatuses.Remove(status);
        status.setToRemove = true;
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.DecreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public virtual void AddSpecialStatus(SpecialStatus status)
    {
        state.AddSpecialStatus(status);
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
                ResolveHit(totalStatusChange, true);
            else
                ResolveHeal(totalStatusChange, true);
        }
    }

    public virtual void ResolveHit(float value, bool overTime)
    {
        if (value != 0)
        {
            totalStats.ModifyHealth(-value);
            if (overTime)
                uiCollection.floatingDamage.AddDot(value);
            else
            {
                uiCollection.floatingDamage.AddHit(value, value / totalStats.Health_Max);
                uiCollection.enemyHealthBar.recentlyHit = true;
            }
        }
    }

    public virtual void ResolveHeal(float value, bool overTime)
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

    public virtual void ActiveAbilityCheck()
    {
        if (abilityPreparingToCast != null && abilityPreparingToCast.initialized)
        {
            if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            {
                Cast(abilityPreparingToCast);
                StopCast();
                return;
            }
            currentCastingTime += Time.deltaTime;
            if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                if (currentCastingTime > abilityPreparingToCast.castModeRune.baseCastTime)
                {
                    Cast(abilityPreparingToCast);
                    StopCast();
                    return;
                }
            }
        }
    }

    public virtual void Cast()
    {

    }

    public void Cast(RootAbility ability)
    {
        actionState = ActionState.Idle;
        if (ability is BasicAbility)
        {
            GameObject abilityResult = Instantiate(Resources.Load(ability.GetPrefabDirectory())) as GameObject;
            GameObject particles = Instantiate(Resources.Load(ability.GetParticleDirectory())) as GameObject;
            particles.transform.SetParent(abilityResult.transform);
            BasicAbilityForm worldAbility = abilityResult.GetComponent<BasicAbilityForm>();
            worldAbility.ability.Construct((BasicAbility)ability, unitID, entityType);

            abilityResult.transform.position = primarySpellCastLocation.position;

            if (worldAbility.ability.effectRunes != null)
            {
                foreach (var rune in worldAbility.ability.effectRunes)
                {
                    if (rune.triggerTag == Rune.TriggerTag.OnCast)
                        rune.Effect(this, this, worldAbility);
                }
            }
        }
        else if (ability is UniqueAbility)
        {

        }

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