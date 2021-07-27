using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : EffectRune
{
    public ModifierGroup.eStat stat;
    public ModifierGroup.eAspect aspect;
    public ModifierGroup.eMethod method;
    public float value;

    public Buff()
    {
        triggerTag = TriggerTag.OnHit;
    }

    public override float EffectStrength()
    {
        if(method == ModifierGroup.eMethod.Flat)
        {
            switch (rank)
            {
                case 1:
                    return 1;
                case 2:
                    return 1.5f;
                case 3:
                    return 2f;
                case 4:
                    return 2.5f;
                case 5:
                    return 3f;
                case 6:
                    return 3.5f;
                case 7:
                    return 4f;
                case 8:
                    return 4.5f;
                case 9:
                    return 5f;
                case 10:
                    return 6f;
                default:
                    return 0;
            }
        }
        else if (method == ModifierGroup.eMethod.AddPercent)
        {
            switch (rank)
            {
                case 1:
                    return 1;
                case 2:
                    return 1.3f;
                case 3:
                    return 1.6f;
                case 4:
                    return 2f;
                case 5:
                    return 2.5f;
                case 6:
                    return 3.2f;
                case 7:
                    return 4f;
                case 8:
                    return 5.5f;
                case 9:
                    return 7.5f;
                case 10:
                    return 10f;
                default:
                    return 0;
            }
        }
        else if (method == ModifierGroup.eMethod.MultiplyPercent)
        {
            switch (rank)
            {
                case 1:
                    return 1.05f;
                case 2:
                    return 1.1f;
                case 3:
                    return 1.15f;
                case 4:
                    return 1.2f;
                case 5:
                    return 1.25f;
                case 6:
                    return 1.3f;
                case 7:
                    return 1.35f;
                case 8:
                    return 1.4f;
                case 9:
                    return 1.45f;
                case 10:
                    return 1.5f;
                default:
                    return 1;
            }
        }
        return 0;
    }

    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Status status = new Status();
        status.modifierGroups.Add(new ModifierGroup() { Stat = stat, Aspect = aspect, Method = method, Value = EffectStrength() });
        status.sourceUnit = owner.unitID;
        status.rate = 0;
        status.maxDuration = Duration();

        target.AddStatus(status);
    }
}