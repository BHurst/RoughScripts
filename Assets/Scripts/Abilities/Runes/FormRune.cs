using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public string formImageLocation = "";
    public string formAnimation = "";
    public FormRuneTag formRuneType;
    public float formDamageMod = 0f;
    public float formDuration = 0f;
    public float formArea = 0f;
    public float formSpeed = 0f;

    public FormRune Clone()
    {
        FormRune newForm = new FormRune();
        newForm.runeName = runeName;
        newForm.runeDescription = runeDescription;
        newForm.rank = rank;
        newForm.harmful = harmful;
        newForm.helpful = helpful;
        newForm.selfHarm = selfHarm;
        newForm.formRuneType = formRuneType;
        newForm.formDamageMod = formDamageMod;
        newForm.formDuration = formDuration;
        newForm.formArea = formArea;
        return newForm;
    }
}