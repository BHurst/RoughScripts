using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseAbility
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
    public CreationMethod creation = CreationMethod.Hazard;
    public string tooltipDamageDescription;
    public int rank = 1;
    public float cooldown = 0;
    public UnitStatsSnapshot snapshot;

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

    public virtual float GetCost()
    {
        return 0;
    }

    public virtual FormRune.HitType GetHitType()
    {
        return FormRune.HitType.None;
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

    public static bool NullorUninitialized(BaseAbility ability)
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

    public enum CreationMethod
    {
        Hazard,
        UnitCast,
        Triggered
    }
}