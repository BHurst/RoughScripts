using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOverTime : EffectRune
{
    public HealOverTime()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = Heal();
        status.maxDuration = Duration();

        target.AddStatus(status);
    }
}