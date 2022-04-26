using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public string formAnimation = "";
    public FormRuneTag formRuneType;
    public float formDamageMod = 0f;
    public float formDuration = 0f;
    public float formArea = 0f;
    public float formSpeed = 0f;
    public int maxTargets = 1;

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
        return newFormRune;
    }
}