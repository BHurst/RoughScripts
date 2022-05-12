using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_HealOverTime : EffectRune
{
    public EffectRune_HealOverTime()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = Heal();
        status.maxDuration = Duration();
        status.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}