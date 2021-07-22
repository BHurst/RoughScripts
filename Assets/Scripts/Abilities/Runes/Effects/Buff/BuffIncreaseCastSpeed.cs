using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffIncreaseCastSpeed : EffectRune
{
    public BuffIncreaseCastSpeed()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = ModifierGroup.eStat.Cast, Aspect = ModifierGroup.eAspect.Rate, Method = ModifierGroup.eMethod.AddPercent, Value = .05f * EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = Duration();

        target.AddStatus(status);
    }
}