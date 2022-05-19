using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public string formAnimation = "";
    public FormRuneTag formRuneType;
    //Implicit
    public float formDuration = 0;
    public float formArea = 0;
    public float formSpeed = 0;
    public float formInterval = 0;
    public int formMaxTargets = 1;
    //Tertiary
    public float formDamageMod = 0;
    public float formResourceCostMod = 0;
    public float formCooldownMod = 0;
    public float formCastSpeedMod = 0;

    public FormRune Clone()
    {
        FormRune newFormRune = new FormRune();
        newFormRune.runeName = runeName;
        newFormRune.runeDescription = runeDescription;
        newFormRune.rank = rank;
        newFormRune.harmful = harmful;
        newFormRune.helpful = helpful;
        newFormRune.selfHarm = selfHarm;
        newFormRune.formRuneType = formRuneType;
        newFormRune.formDamageMod = formDamageMod;
        newFormRune.formDuration = formDuration;
        newFormRune.formArea = formArea;
        newFormRune.formSpeed = formSpeed;
        newFormRune.formInterval = formInterval;
        newFormRune.formMaxTargets = formMaxTargets;
        return newFormRune;
    }
}