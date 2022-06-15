using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbility : RootAbility
{
    public FormRune formRune;
    public BasicAbility abilityToTrigger;
    public bool createdWithStatus = false;

    public override float GetDamage()
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

    public override float GetDuration()
    {
        return formRune.formDuration;
    }

    public override float GetArea()
    {
        return formRune.formArea;
    }

    public override float GetDamageMultipliers()
    {
        return formRune.formDamageMod * snapshot.overrideMultiplier;
    }

    public override float GetCost()
    {
        return schoolRune.baseCost * formRune.formResourceCostMod;
    }

    public override string GetPrepareAnimation()
    {
        return formRune.formPrepareAnimation;
    }

    public override string GetCastAnimation()
    {
        return formRune.formCastAnimation;
    }

    public override string GetPrefabDirectory()
    {
        return String.Format("Prefabs/Abilities/Forms/{0}", formRune.formRuneType);
    }

    public override string GetParticleDirectory()
    {
        return String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", formRune.formRuneType, schoolRune.schoolRuneType);
    }

    public override RootAbility.HitType GetHitType()
    {
        return formRune.hitType;
    }

    public void Construct(BasicAbility ability, Guid owner, RootEntity.EntityType entityType)
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
        statuses = ability.statuses;
        snapshot = ability.snapshot;
        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
        snapshot.overrideDamage = ability.snapshot.overrideDamage;
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
}