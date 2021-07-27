using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUnit : MonoBehaviour
{
    public Guid unitID = Guid.NewGuid();
    public Vector3 location;
    public int team = 2;
    public float unitHealth
    {
        get { return actualHealth; }
        set { actualHealth = Mathf.Clamp(value, 0, unitMaxHealth); }
    }
    [SerializeField] private float actualHealth = 100;
    public float unitMaxHealth = 100;
    public float unitMana = 100;
    public float unitMaxMana = 100;
    public float unitMaxSingleManaExpenditure = 100;
    public string unitName = "DummyName";
    public bool inCombat = false;
    public bool hasSpeech = false;
    public string hostility; //Make enum
    public bool isAlive = true;
    public Ability queuedAbility = null;
    public Ability abilityBeingCast = null;
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
    public List<Ability> hotbarAbilities = new List<Ability>();
    public UnitStats totalStats = new UnitStats();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll doll = new EquipmentDoll();
    public CharacterLevel level = new CharacterLevel();
    public float globalCooldown = 0;
    public List<Ability> abilitiesOnCooldown = new List<Ability>();
    public PopupTextManager popupTextManager;
    public List<Status> activeStatuses = new List<Status>();
    public float timer;
    public MovementState movementState = MovementState.Idle;
    public bool pushedEvenFurtherBeyond = false;
    public Vector3 eyesOffset = new Vector3(0, 2, 0);

    public void Shove(float pushForce, Vector3 direction)
    {
        transform.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
        pushedEvenFurtherBeyond = true;
    }

    public void IncrementTimers()
    {
        timer += Time.deltaTime;
        moveAbilityTimer += Time.deltaTime;
        globalCooldown = Mathf.Clamp(globalCooldown -= Time.deltaTime, 0, 100);
        if(abilitiesOnCooldown.Count > 0)
        {
            for (int i = abilitiesOnCooldown.Count - 1; i > -1; i--)
            {
                abilitiesOnCooldown[i].cooldown = Mathf.Clamp(abilitiesOnCooldown[i].cooldown -= Time.deltaTime, 0, 100000000);
                if (abilitiesOnCooldown[i].cooldown == 0)
                    abilitiesOnCooldown.RemoveAt(i);
            }
        }
    }

    public void RefreshStats()
    {
        doll.DetermineWeaponStats();
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

    public void AddStatus(Status status)
    {
        activeStatuses.Add(status);
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.IncreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public void ResolveHit(float value, bool overTime)
    {
        if (value != 0)
            popupTextManager.AddHit(value);
    }

    public void ResolveHeal(float value)
    {
        popupTextManager.AddHeal(value);
    }

    public void ResolveValueStatuses()
    {
        float totalStatusChange = 0;

        for (int i = activeStatuses.Count - 1; i > -1; i--)
        {
            totalStatusChange -= activeStatuses[i].rate * Time.deltaTime;
            activeStatuses[i].currentDuration += Time.deltaTime;
            if (activeStatuses[i].currentDuration > activeStatuses[i].maxDuration)
            {
                foreach (ModifierGroup modifierGroup in activeStatuses[i].modifierGroups)
                {
                    totalStats.DecreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
                }
                activeStatuses.RemoveAt(i);
            }
        }
        if (totalStatusChange != 0)
            DamageManager.CalculateStatusDamage(this, totalStatusChange);
    }

    public virtual void CastingTimeCheck()
    {
        if (queuedAbility != null && queuedAbility.initialized)
        {
            if (queuedAbility.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
            {
                Cast(queuedAbility);
                StopCast();
                return;
            }
            currentCastingTime += Time.deltaTime;
            if (queuedAbility.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                if (currentCastingTime > queuedAbility.aCastModeRune.BaseCastTime())
                {
                    Cast(queuedAbility);
                    StopCast();
                    return;
                }
            }
        }
    }

    public void Cast(Ability ability)
    {
        movementState = MovementState.Idle;
        //GetComponent<Animator>().Play("RightHandCast");
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", ability.aFormRune.formRuneType))) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", ability.aFormRune.formRuneType, ability.aSchoolRune.schoolRuneType))) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(ability, unitID);
        abilityResult.transform.position = primarySpellCastLocation.position;

        if (worldAbility.wEffectRunes != null)
        {
            foreach (var rune in worldAbility.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                    rune.Effect(this, this, worldAbility);
            }
        }
    }

    public void Kill()
    {
        unitHealth = 0;
        isAlive = false;
        state.ClearState();
        RefreshStats();
    }

    public void StopCast()
    {
        currentCastingTime = 0;
        queuedAbility = null;
    }
}

public enum MovementState
{
    Attacking,
    Casting,
    Idle,
    Moving,
    Sprinting
}