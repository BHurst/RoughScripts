using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Debuff : EffectRune
{
    public EffectRune_Debuff()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "A debuff will be applied to the target";
        readableName = "Debuff";
    }
    
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.GlobalDamage, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .01f * EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = 7;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}