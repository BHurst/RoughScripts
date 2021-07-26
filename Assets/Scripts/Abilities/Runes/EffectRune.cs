using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class EffectRune : Rune {

    public TriggerTag triggerTag;

    public virtual void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {

    }

    public float Duration()
    {
        switch (rank)
        {
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
            case 4:
                return 5;
            case 5:
                return 7;
            case 6:
                return 8;
            case 7:
                return 10;
            case 8:
                return 12;
            case 9:
                return 15;
            case 10:
                return 20;
            default:
                return 3;
        }
    }

    public float Damage()
    {
        switch (rank)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 4;
            case 4:
                return 6;
            case 5:
                return 9;
            case 6:
                return 13;
            case 7:
                return 19;
            case 8:
                return 27;
            case 9:
                return 35;
            case 10:
                return 45;
            default:
                return 1;
        }
    }

    public float Heal()
    {
        switch (rank)
        {
            case 1:
                return -1;
            case 2:
                return -2;
            case 3:
                return -3;
            case 4:
                return -5;
            case 5:
                return -8;
            case 6:
                return -11;
            case 7:
                return -15;
            case 8:
                return -20;
            case 9:
                return -25;
            case 10:
                return -30;
            default:
                return -1;
        }
    }

    public float EffectStrength()
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
                return -1;
        }
    }
}