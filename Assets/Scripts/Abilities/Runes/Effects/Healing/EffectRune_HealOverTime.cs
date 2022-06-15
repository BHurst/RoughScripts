using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_HealOverTime : EffectRune
{
    public EffectRune_HealOverTime()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "A heal over time will be applied to the target.";
        readableName = "HoT";
    }
    
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = abilityObject.ability.GetDamage() / 5;
        status.maxDuration = 5;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}