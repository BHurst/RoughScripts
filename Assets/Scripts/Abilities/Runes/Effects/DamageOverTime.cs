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
        status.rate = worldAbility.wSchoolRune.Damage();
        status.maxDuration = worldAbility.wFormRune.Duration();

        target.AddStatus(status);
    }
}