using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAbility : MonoBehaviour
{
    public Guid worldAbilityID;
    public Guid abilityOwner;
    public RootEntity.EntityType ownerEntityType;
    public string worldAbilityName;
    public FormRune wFormRune;
    public CastModeRune wCastModeRune;
    public SchoolRune wSchoolRune;
    public List<EffectRune> wEffectRunes;
    public Ability abilityToTrigger;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public CreationMethod creation = CreationMethod.Hazard;
    public HitType hitType = HitType.None;

    public float overrideDamage = -1;
    public float overrideMultiplier = 1;
    public Transform targetPreference;
    public List<RootCharacter> previousTargets = new List<RootCharacter>();
    public float calculatedDamage = 0;
    public float calculatedHealing = 0;
    public float increasedProjectileSpeed = 1;
    public float increasedArea = 1;
    public float increasedChains = 0;
    public float increasedProjectiles = 0;

    public void AffectTarget()
    {
        DamageManager.CalculateAbilityDefender(abilityOwner, this);
    }

    internal void Construct(Ability ability, Guid owner, RootEntity.EntityType entityType)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        ownerEntityType = entityType;
        wFormRune = ability.aFormRune;
        wCastModeRune = ability.aCastModeRune;
        wSchoolRune = ability.aSchoolRune;
        wEffectRunes = ability.aEffectRunes;
        if (ability.abilityToTrigger != null && UtilityService.CanFormTriggerForm(wFormRune.formRuneType, ability.abilityToTrigger.aFormRune.formRuneType))
            abilityToTrigger = ability.abilityToTrigger;
        else
            abilityToTrigger = null;

        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
        hitType = wFormRune.hitType;
        overrideDamage = ability.overrideDamage;
    }

    internal void Construct(WorldAbility ability, Guid owner, RootEntity.EntityType entityType)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        ownerEntityType = entityType;
        wFormRune = ability.wFormRune;
        wCastModeRune = ability.wCastModeRune;
        wSchoolRune = ability.wSchoolRune;
        wEffectRunes = null;
        abilityToTrigger = null;

        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
        hitType = wFormRune.hitType;
        overrideDamage = ability.overrideDamage;
    }

    public enum CreationMethod
    {
        Hazard,
        UnitCast,
        Triggered
    }

    public enum HitType
    {
        None,
        DoT,
        Hit,
        MultiHit
    }
}