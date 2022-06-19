using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Buff : EffectRune
{
    public ModifierGroup.EStat stat;
    public ModifierGroup.EAspect aspect;
    public ModifierGroup.EMethod method;
    public float value;

    public EffectRune_Buff()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "A buff will be applied to the target.";
        readableName = "Buff";
    }

    public override float EffectStrength()
    {
        if(method == ModifierGroup.EMethod.Flat)
        {
            return rank switch
            {
                1 => 1,
                2 => 1.5f,
                3 => 3f,
                4 => 5f,
                5 => 8f,
                6 => 10f,
                7 => 12.5f,
                8 => 15f,
                9 => 17.5f,
                10 => 20f,
                _ => 0,
            };
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            return rank switch
            {
                1 => .05f,
                2 => .10f,
                3 => .15f,
                4 => .25f,
                5 => .35f,
                6 => .45f,
                7 => .55f,
                8 => .70f,
                9 => .85f,
                10 => 1f,
                _ => 0,
            };
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            return rank switch
            {
                1 => .05f,
                2 => .10f,
                3 => .15f,
                4 => .20f,
                5 => .25f,
                6 => .30f,
                7 => .35f,
                8 => .40f,
                9 => .45f,
                10 => .50f,
                _ => 1,
            };
        }
        return 0;
    }

    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = stat, Aspect = aspect, Method = method, Value = EffectStrength() });
        status.statusId = abilityObject.ability.abilityID;
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = 7;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}