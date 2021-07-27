using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : EffectRune
{
    public Debuff()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = ModifierGroup.eStat.GlobalDamage, Aspect = ModifierGroup.eAspect.DamageTaken, Method = ModifierGroup.eMethod.AddPercent, Value = .01f * EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = Duration();

        target.AddStatus(status);
    }
}