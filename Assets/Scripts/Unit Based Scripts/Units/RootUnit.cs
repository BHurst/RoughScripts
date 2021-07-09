using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUnit : MonoBehaviour
{
    public Guid unitID = Guid.NewGuid();
    public Vector3 location;
    public int team = 2;
    public float unitHealth = 100;
    public float unitMaxHealth = 100;
    public float unitMana = 100;
    public float unitMaxMana = 100;
    public float unitMaxSingleManaExpenditure = 100;
    public string unitName = "DummyName";
    public bool droppedItems = false;
    public bool inCombat = false;
    public bool hasSpeech = false;
    public string hostility; //Make enum
    public bool isAlive = true;
    public bool moving = false;
    public Ability currentAbilityToUse = null;
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
    public List<AbilitySlot> hotbarAbilities = new List<AbilitySlot>();
    public UnitStats totalStats = new UnitStats();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll doll = new EquipmentDoll();
    public CharacterLevel level = new CharacterLevel();
    public Cooldowns abilitiesOnCooldown = new Cooldowns();
    public List<Status> activeStatuses = new List<Status>();
    public float timer;
    public MovementState movementState = MovementState.Idle;
    public bool pushedEvenFurtherBeyond = false;
    public Vector3 eyesOffset = new Vector3(0,2,0);

    public void Shove(float pushForce, Vector3 direction)
    {
        transform.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
        pushedEvenFurtherBeyond = true;
    }

    public void IncrementTimers()
    {
        timer += Time.deltaTime;
        moveAbilityTimer += Time.deltaTime;
    }

    public void RefreshState()
    {

        //foreach (RootStatus status in currentStatusEffects)
        //{
        //    if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Fire) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //    {
        //    }
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Nature) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Poisoned = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Water) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Wet = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Air) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Electrified = true;
        //    else if (status.statusBaseDamageType.Equals(SpellStats.AbilitySchool.Physical) && status.AbilityTags.Contains(AbilityTags.AbilityTag.Damage))
        //        state.Bleeding = true;
        //    else if (status.AbilityTags.Contains(AbilityTags.AbilityTag.Stun))
        //    {
        //        state.Stunned = true;
        //        attackTimer = 0;
        //        queuedAbility = null;
        //    }
        //    else if (status.AbilityTags.Contains(AbilityTags.AbilityTag.Root))
        //        state.Rooted = true;
        //}


    }

    public void RefreshStats()
    {
        doll.DetermineWeaponStats();

        RefreshState();
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

    public void ResolveHit(float value, bool overTime)
    {
        PopupTextManager.AddHit(unitID, value, transform.position);
    }

    public void ResolveHeal(float value)
    {
        PopupTextManager.AddHeal(unitID, value, transform.position);
    }

    public void ResolveValueStatuses()
    {
        float totalStatusChange = 0;

        for (int i = activeStatuses.Count - 1; i > -1; i--)
        {
            totalStatusChange -= activeStatuses[i].rate * Time.deltaTime;
            activeStatuses[i].currentDuration += Time.deltaTime;
            if (activeStatuses[i].currentDuration > activeStatuses[i].maxDuration)
                activeStatuses.RemoveAt(i);
        }
        if (totalStatusChange != 0)
            DamageManager.CalculateStatusDamage(this, totalStatusChange);
    }

    public void ResolveSizeCollision(RootUnit Char1, RootUnit Char2)
    {
        if (Char1.size > Char2.size)
        {
            Char2.GetComponent<Rigidbody>().velocity = Char1.transform.position - Char2.transform.position;
        }
        else if (Char1.size == Char2.size)
        {
            Char2.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
        }
    }

    public virtual void CastingTimeCheck()
    {
        if (currentAbilityToUse != null && currentAbilityToUse.initialized)
        {
            if (currentAbilityToUse.castModeRune.castMode == Rune.CastModeRuneTag.Instant)
            {
                Cast(currentAbilityToUse);
                StopCast();
                return;
            }
            currentCastingTime += Time.deltaTime;
            if (currentAbilityToUse.castModeRune.castMode == Rune.CastModeRuneTag.CastTime)
            {
                if (currentCastingTime > currentAbilityToUse.castModeRune.castTime)
                {
                    Cast(currentAbilityToUse);
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
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", ability.formRune.form))) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", ability.formRune.form, ability.schoolRune.school))) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(ability, unitID);
        abilityResult.transform.position = primarySpellCastLocation.position;
    }

    public void Kill()
    {
        unitHealth = 0;
        isAlive = false;
        state.ClearState();
        RefreshState();
        RefreshStats();
    }

    public void ActionCD()
    {

    }

    public void StopCast()
    {
        currentCastingTime = 0;
        currentAbilityToUse = null;
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