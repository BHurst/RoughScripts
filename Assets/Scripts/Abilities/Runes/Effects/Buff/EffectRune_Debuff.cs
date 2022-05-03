using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Debuff : EffectRune
{
    public EffectRune_Debuff()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.GlobalDamage, Aspect = ModifierGroup.EAspect.DamageTaken, Method = ModifierGroup.EMethod.AddPercent, Value = .01f * EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = Duration();
        status.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}