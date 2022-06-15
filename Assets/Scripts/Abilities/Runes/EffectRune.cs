using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[Serializable]
public class EffectRune : Rune {

    public TriggerTag triggerTag;
    public bool targetSelf = false;
    public string readableName = "";
    public float duration = 0;
    public float damage = 0;
    public float heal = 0;

    public virtual void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm ability)
    {

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