using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueAbility : RootAbility
{
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

    public override TargettingType GetTargettingType()
    {
        return TargettingType.Single;
    }
}