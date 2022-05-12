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
    }

    public override float EffectStrength()
    {
        if(method == ModifierGroup.EMethod.Flat)
        {
            return rank switch
            {
                1 => 1,
                2 => 1.5f,
                3 => 2f,
                4 => 2.5f,
                5 => 3f,
                6 => 3.5f,
                7 => 4f,
                8 => 4.5f,
                9 => 5f,
                10 => 6f,
                _ => 0,
            };
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            return rank switch
            {
                1 => 1,
                2 => 1.3f,
                3 => 1.6f,
                4 => 2f,
                5 => 2.5f,
                6 => 3.2f,
                7 => 4f,
                8 => 5.5f,
                9 => 7.5f,
                10 => 10f,
                _ => 0,
            };
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            return rank switch
            {
                1 => 1.05f,
                2 => 1.1f,
                3 => 1.15f,
                4 => 1.2f,
                5 => 1.25f,
                6 => 1.3f,
                7 => 1.35f,
                8 => 1.4f,
                9 => 1.45f,
                10 => 1.5f,
                _ => 1,
            };
        }
        return 0;
    }

    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = stat, Aspect = aspect, Method = method, Value = EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = Duration();
        status.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}