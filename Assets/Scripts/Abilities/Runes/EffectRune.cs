using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class EffectRune : Rune {

    public TriggerTag triggerTag;

    public virtual void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {

    }

    public float Duration()
    {
        return rank switch
        {
            1 => 2,
            2 => 3,
            3 => 4,
            4 => 5,
            5 => 7,
            6 => 8,
            7 => 10,
            8 => 12,
            9 => 15,
            10 => 20,
            _ => 3,
        };
    }

    public float Damage()
    {
        return rank switch
        {
            1 => 2,
            2 => 3,
            3 => 4,
            4 => 6,
            5 => 9,
            6 => 13,
            7 => 19,
            8 => 27,
            9 => 35,
            10 => 45,
            _ => 1,
        };
    }

    public float Heal()
    {
        return rank switch
        {
            1 => -1,
            2 => -2,
            3 => -3,
            4 => -5,
            5 => -8,
            6 => -11,
            7 => -15,
            8 => -20,
            9 => -25,
            10 => -30,
            _ => -1,
        };
    }

    public virtual float EffectStrength()
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
            _ => -1,
        };
    }
}