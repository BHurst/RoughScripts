using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RootAbility
{
    public Guid abilityID;
    public Guid abilityOwner;
    public RootEntity.EntityType ownerEntityType;
    public string abilityName;
    public bool initialized = false;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public CastModeRune castModeRune;
    public SchoolRune schoolRune;
    public List<EffectRune> effectRunes;
    public RootAbility abilityToTrigger;
    public AbilityStateManager abilityStateManager;
    public CreationMethod creation = CreationMethod.Hazard;
    public bool predictProjectileLocation = false;
    public string tooltipDamageDescription;
    public int rank = 1;
    public float cooldown = 0;
    public CalculatedAbilityStats snapshot;

    public virtual float GetDamage()
    {
        return 0;
    }

    public virtual float GetDuration()
    {
        return 0;
    }

    public virtual float GetArea()
    {
        return 0;
    }

    public virtual int GetChains()
    {
        return 0;
    }

    public virtual float GetCost()
    {
        return 0;
    }

    public virtual HitType GetHitType()
    {
        return RootAbility.HitType.None;
    }

    public virtual TargettingType GetTargettingType()
    {
        return TargettingType.None;
    }

    public virtual RootAbility GetAbilityToTrigger()
    {
        return null;
    }
    
    public virtual float GetDamageMultipliers()
    {
        return 1;
    }

    public virtual string GetPrefabDirectory()
    {
        return "";
    }

    public virtual string GetParticleDirectory()
    {
        return "";
    }

    public static bool NullorUninitialized(RootAbility ability)
    {
        if (ability != null && ability.initialized)
            return false;

        return true;
    }

    public virtual string GetPrepareAnimation()
    {
        return "";
    }

    public virtual string GetCastAnimation()
    {
        return "";
    }

    public virtual void Construct(RootAbility ability, Guid owner, RootEntity.EntityType entityType)
    {
        
    }

    public BasicAbility GetAsBasic()
    {
        return (BasicAbility)this;
    }

    public UniqueAbility GetAsUnique()
    {
        return (UniqueAbility)this;
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

    public enum TargettingType
    {
        None,
        Single,
        Multiple
    }
}