using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_DamageOverTime : EffectRune
{
    public EffectRune_DamageOverTime()
    {
        triggerTag = TriggerTag.OnHit;
    }

    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = Damage();
        status.maxDuration = Duration();
        status.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}