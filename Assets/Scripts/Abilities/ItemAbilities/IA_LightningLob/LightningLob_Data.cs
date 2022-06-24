using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningLob_Data : UniqueAbility
{

    public LightningLob_Data()
    {
        abilityID = Guid.NewGuid();
        abilityOwner = Guid.Empty;
        ownerEntityType = RootEntity.EntityType.None;
        abilityName = "Lightning Lob";
        initialized = true;
        castModeRune = new CastModeRune_CastTime();
        schoolRune = new SchoolRune_Electricity();
        effectRunes = new List<EffectRune>();
        abilityStateManager = new AbilityStateManager();
        creation = CreationMethod.UnitCast;
        rank = 1;
        cooldown = 0;
        snapshot = new CalculatedAbilityStats();
        objectType = typeof(LightningLob_Object);
        harmful = true;
        hitType = HitType.MultiHit;
        damage = 5f;
        duration = 5f;
        area = 10f;
        chains = 0;
        cost = 24f;
    }

    public LightningLob_Data(Guid owner, RootEntity.EntityType entityType)
    {
        abilityID = Guid.NewGuid();
        abilityOwner = owner;
        ownerEntityType = entityType;
        abilityName = "Lightning Lob";
        initialized = true;
        castModeRune = new CastModeRune_CastTime();
        schoolRune = new SchoolRune_Electricity();
        effectRunes = new List<EffectRune>();
        abilityStateManager = new AbilityStateManager();
        creation = CreationMethod.UnitCast;
        rank = 1;
        cooldown = 0;
        snapshot = new CalculatedAbilityStats();
        objectType = typeof(LightningLob_Object);
        harmful = true;
        hitType = HitType.MultiHit;
        damage = 5f;
        duration = 5f;
        area = 10f;
        chains = 0;
        cost = 24f;
    }

    public override string GetAbilityDescription()
    {
        DamageManager.CalculateAbilityAttacker(this);
        return string.Format("Tosses a ball of {0} that zaps enemies within {1}m from it every {2}s for {3} {0} damage until it hits the ground.",
            schoolRune.schoolRuneType,
            snapshot.area,
            .1f / snapshot.castSpeed,
            MathF.Round(snapshot.damage * 100) / 100);
    }

    public override float GetCastTime()
    {
        return 1.5f;
    }
}