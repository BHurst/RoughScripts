using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : EffectRune
{
    public DamageOverTime()
    {
        triggerTag = TriggerTag.OnHit;
    }

    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = Damage();
        status.maxDuration = Duration();

        target.AddStatus(status);
    }
}