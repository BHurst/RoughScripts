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
    public float timer;
    public MovementState movementState = MovementState.Idle;
    public float globalActionCooldown = 0;

    public Ability abilityIKnow1 = new Ability() { abilityID = Guid.Empty, abilityName = "Orb", formRune = new Orb(), schoolRunes = new List<SchoolRune>() { new Fire() }, harmRune = new Harm { rank = 5 },
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Arc", formRune = new Arc(), schoolRunes = new List<SchoolRune>() { new Air() }, harmRune = new Harm { rank = 4 },
            abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Strike", formRune = new Strike(), schoolRunes = new List<SchoolRune>() { new Air() }, harmRune = new Harm { rank = 3 } } } };

    public Ability abilityIKnow2 = new Ability() { abilityID = Guid.Empty, abilityName = "Strike", formRune = new Strike(), schoolRunes = new List<SchoolRune>() { new Air() }, harmRune = new Harm { rank = 5 } };
    public Ability abilityIKnow3 = new Ability() { abilityID = Guid.Empty, abilityName = "Self Cast", formRune = new SelfCast(), harmRune = new Harm { selfHarm = true, rank = 5 }, schoolRunes = new List<SchoolRune>() { new Fire() }, specialEffect = new Dash() };
    public Ability abilityIKnow4 = new Ability() { abilityID = Guid.Empty, abilityName = "Nova", formRune = new Nova(), schoolRunes = new List<SchoolRune>() { new Astral() }, harmRune = new Harm { rank = 5 },
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Strike", formRune = new Strike(), schoolRunes = new List<SchoolRune>() { new Air() }, harmRune = new Harm { rank = 5 } } };

    public Ability abilityIKnow5 = new Ability() { abilityID = Guid.Empty, abilityName = "Command", formRune = new Command(), schoolRunes = new List<SchoolRune>() { new Arcane() }, harmRune = new Harm { rank = 1 }, 
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Nova", formRune = new Nova(), schoolRunes = new List<SchoolRune>() { new Astral() }, harmRune = new Harm { rank = 3 } } };


    public Ability abilityIKnow6 = new Ability() { abilityID = Guid.Empty, abilityName = "Wave", formRune = new Wave(), schoolRunes = new List<SchoolRune>() { new Water() }, harmRune = new Harm { rank = 5 } };
    public Ability abilityIKnow7 = new Ability() { abilityID = Guid.Empty, abilityName = "Arc", formRune = new Arc(), schoolRunes = new List<SchoolRune>() { new Air() }, harmRune = new Harm { rank = 5 },
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Zone", formRune = new Zone(), schoolRunes = new List<SchoolRune>() { new Ethereal() }, harmRune = new Harm { rank = 4 } } };

    public Ability abilityIKnow8 = new Ability() { abilityID = Guid.Empty, abilityName = "Weapon", formRune = new Weapon(), schoolRunes = new List<SchoolRune>() { new Kinetic() }, harmRune = new Harm { rank = 5 } };
    public Ability abilityIKnow9 = new Ability() { abilityID = Guid.Empty, abilityName = "Beam", formRune = new Beam(), schoolRunes = new List<SchoolRune>() { new Arcane() }, harmRune = new Harm { rank = 5 } };
    public Ability abilityIKnow10 = new Ability() { abilityID = Guid.Empty, abilityName = "Zone", formRune = new Zone(), schoolRunes = new List<SchoolRune>() { new Ethereal() }, harmRune = new Harm { rank = 5 } };

    public enum MovementState
    {
        Idle,
        Attacking
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

    public void MovementCheck()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude >= totalStats.MoveSpeed / 5)
            moving = true;
        else
            moving = false;
    }

    bool PickupRangeCheck(WorldItem currentItemTarget)
    {
        if (Vector3.Distance(currentItemTarget.transform.position, this.transform.position) <= currentItemTarget.interactDistance)
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

    public void ResolveHit(float value)
    {
        PopupTextManager.AddHit(unitID, value, transform.position);
    }

    public void ResolveHeal(float value)
    {
        PopupTextManager.AddHeal(unitID, value, transform.position);
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

    public void CastingTimeCheck()
    {
        //if (abilityBeingCast != null)
        //{
        //    if (abilityBeingCast.stats.abilityTags.Contains(SpellStats.AbilityTag.Channel))
        //    {
        //        currentCastingTime += Time.deltaTime;
        //        if (abilityBeingCast.stats.abilityBaseRangeMaximum == 0)
        //        {
        //            if (currentCastingTime > abilityBeingCast.stats.abilityBasePulseTimer / totalStats.BonusCastSpeedPercent)
        //            {
        //                SpawnAbility(abilityBeingCast);

        //                abilitiesOnCooldown.AddCooldown(abilityBeingCast.abilityID, abilityBeingCast.stats.abilityBaseCooldown);

        //                currentCastingTime = 0;

        //                if (abilityBeingCast.stats.abilityBaseCastTime <= 0 || abilityBeingCast.stats.abilityBaseCastTime < abilityBeingCast.stats.abilityBasePulseTimer)
        //                    StopCast();
        //            }
        //        }
        //        else
        //            StopCast();
        //    }
        //    else
        //    {
        //        currentCastingTime += Time.deltaTime;
        //        if (currentCastingTime >= abilityBeingCast.stats.abilityBaseCastTime / totalStats.BonusCastSpeedPercent)
        //        {
        //            var charAnimator = GetComponent<Animator>();
        //            if (abilityBeingCast.stats.abilityTags.Contains(SpellStats.AbilityTag.Attack))
        //            {
        //                charAnimator.speed = totalStats.AttackSpeed * totalStats.BonusAttackSpeedPercent;
        //                charAnimator.Play("WeaponSwing");
        //                SpawnAbility(abilityBeingCast);
        //            }
        //            else if (abilityBeingCast.stats.abilityTags.Contains(SpellStats.AbilityTag.Spell))
        //            {
        //                charAnimator.speed = totalStats.BonusCastSpeedPercent;
        //                charAnimator.Play("RightHandCast");
        //                SpawnAbility(abilityBeingCast);
        //            }

        //            abilitiesOnCooldown.AddCooldown(abilityBeingCast.abilityID, abilityBeingCast.stats.abilityBaseCooldown);

        //            abilityBeingCast = null;
        //            currentCastingTime = 0;

        //        }
        //        else if (moving == true && abilityBeingCast.stats.abilityTags.Contains(SpellStats.AbilityTag.Stationary))
        //            StopCast();
        //    }
        //}
    }

    public void Cast(Ability ability)
    {
        //GetComponent<Animator>().Play("RightHandCast");
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", ability.formRune.form))) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", ability.formRune.form, ability.schoolRunes[0].school))) as GameObject;
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
    }
}