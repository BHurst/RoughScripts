using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_DamageOverTime : EffectRune
{
    public EffectRune_DamageOverTime()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "A damage over time effect will be applied to the target";
        readableName = "DoT";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, _WorldAbilityForm abilityObject)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = damage;
        status.maxDuration = duration;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}