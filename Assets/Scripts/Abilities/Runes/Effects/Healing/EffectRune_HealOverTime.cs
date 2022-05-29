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
    
    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = 1;
        status.maxDuration = 1;
        status.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}