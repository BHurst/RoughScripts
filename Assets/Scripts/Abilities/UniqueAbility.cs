using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueAbility : RootAbility
{
    public string prefabLocation;
    public Type objectType;
    public RootAbility.HitType hitType;
    public float damage;
    public float duration;
    public float area;
    public int chains;
    public float cost;

    public UniqueAbility()
    {
        abilityID = Guid.NewGuid();
        abilityOwner = Guid.Empty;
        ownerEntityType = RootEntity.EntityType.None;
        abilityName = "";
        initialized = true;
        castModeRune = null;
        schoolRune = null;
        effectRunes = new List<EffectRune>();
        creation = CreationMethod.UnitCast;
        rank = 1;
        cooldown = 0;
        snapshot = new CalculatedAbilityStats();
    }

    public override float GetDamage()
    {
        return damage;
    }

    public override float GetDuration()
    {
        return duration;
    }

    public override float GetArea()
    {
        return area;
    }

    public override int GetChains()
    {
        return chains;
    }

    public override float GetCost()
    {
        return cost;
    }

    public override HitType GetHitType()
    {
        return hitType;
    }

    public override RootAbility GetAbilityToTrigger()
    {
        return null;
    }

    public override float GetDamageMultipliers()
    {
        return 1;
    }

    public override string GetParticleDirectory()
    {
        return "";
    }

    public override string GetPrepareAnimation()
    {
        return "";
    }

    public override TargettingType GetTargettingType()
    {
        return TargettingType.Single;
    }

    public override string GetPrefabDirectory()
    {
        return "Prefabs/Abilities/UniqueAbilityObject";
    }

    public override string GetCastAnimation()
    {
        return "triggerMainHandCast";
    }

    public override void Construct(RootAbility ability, Guid owner, RootEntity.EntityType entityType)
    {
        UniqueAbility realForm = (UniqueAbility)ability;

        abilityID = Guid.NewGuid();
        abilityOwner = owner;
        ownerEntityType = entityType;
        initialized = true;
        castModeRune = realForm.castModeRune;
        schoolRune = realForm.schoolRune;
        effectRunes = realForm.effectRunes;
        rank = realForm.rank;
        //if (realForm.abilityToTrigger != null && UtilityService.CanFormTriggerForm(formRune.formRuneType, ((BasicAbility)realForm.abilityToTrigger).formRune.formRuneType))
        //    abilityToTrigger = realForm.abilityToTrigger;
        //else
        //    abilityToTrigger = null;
        abilityStateManager = realForm.abilityStateManager;
        predictProjectileLocation = realForm.predictProjectileLocation;

        snapshot = realForm.snapshot;
        harmful = realForm.harmful;
        helpful = realForm.helpful;
        selfHarm = realForm.selfHarm;
        snapshot.overrideDamage = realForm.snapshot.overrideDamage;
        hitType = realForm.hitType;
        damage = realForm.damage;
        duration = realForm.duration;
        area = realForm.area;
        chains = realForm.chains;
        cost = realForm.cost;
    }
}