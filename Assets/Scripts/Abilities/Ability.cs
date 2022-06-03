using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ability
{
    public Guid abilityID;
    public Guid abilityOwner;
    public RootEntity.EntityType ownerEntityType;
    public string abilityName;
    public bool initialized = false;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public FormRune formRune;
    public CastModeRune castModeRune;
    public SchoolRune schoolRune;
    public List<EffectRune> effectRunes;
    public Ability abilityToTrigger;
    public CreationMethod creation = CreationMethod.Hazard;
    public string tooltipDamageDescription;
    public int rank = 1;
    public float cooldown = 0;
    public float overrideDamage = -1f;
    public float overrideMultiplier = 1;
    public float calculatedDamage = 0;
    public float calculatedHealing = 0;
    public float increasedProjectileSpeed = 1;
    public float increasedArea = 1;
    public float increasedChains = 0;
    public float increasedProjectiles = 0;

    public float GetDamage()
    {
        switch (rank)
        {
            case 1:
                return 55 * schoolRune.damageMod;
            case 2:
                return 60 * schoolRune.damageMod;
            case 3:
                return 67 * schoolRune.damageMod;
            case 4:
                return 74 * schoolRune.damageMod;
            case 5:
                return 81 * schoolRune.damageMod;
            case 6:
                return 89 * schoolRune.damageMod;
            case 7:
                return 98 * schoolRune.damageMod;
            case 8:
                return 108 * schoolRune.damageMod;
            case 9:
                return 118 * schoolRune.damageMod;
            case 10:
                return 130 * schoolRune.damageMod;
            case 11:
                return 143 * schoolRune.damageMod;
            case 12:
                return 157 * schoolRune.damageMod;
            case 13:
                return 173 * schoolRune.damageMod;
            case 14:
                return 190 * schoolRune.damageMod;
            case 15:
                return 209 * schoolRune.damageMod;
            case 16:
                return 230 * schoolRune.damageMod;
            case 17:
                return 253 * schoolRune.damageMod;
            case 18:
                return 278 * schoolRune.damageMod;
            case 19:
                return 306 * schoolRune.damageMod;
            case 20:
                return 336 * schoolRune.damageMod;
            default:
                return 0;
        }
    }

    public float GetCost()
    {
        return schoolRune.baseCost * formRune.formResourceCostMod;
    }

    internal void Construct(Ability ability, Guid owner, RootEntity.EntityType entityType)
    {
        abilityID = Guid.NewGuid();
        abilityOwner = owner;
        ownerEntityType = entityType;
        initialized = true;
        formRune = ability.formRune;
        castModeRune = ability.castModeRune;
        schoolRune = ability.schoolRune;
        effectRunes = ability.effectRunes;
        rank = ability.rank;
        if (ability.abilityToTrigger != null && UtilityService.CanFormTriggerForm(formRune.formRuneType, ability.abilityToTrigger.formRune.formRuneType))
            abilityToTrigger = ability.abilityToTrigger;
        else
            abilityToTrigger = null;

        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
        overrideDamage = ability.overrideDamage;
    }
    

    public void NameSelf()
    {
        abilityName = formRune.runeName
            + " " + castModeRune.runeName
            + " " + schoolRune.runeName;

        foreach (var rune in effectRunes)
        {
            abilityName += " " + rune.runeName;
        }
    }

    public static bool NullorUninitialized(Ability ability)
    {
        if (ability != null && ability.initialized)
            return false;

        return true;
    }

    public enum CreationMethod
    {
        Hazard,
        UnitCast,
        Triggered
    }
}