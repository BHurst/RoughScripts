using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public FormRuneTag formRuneType;
    public float formDamageMod = 1f;

    public FormRune Clone()
    {
        FormRune temp = new FormRune();
        temp.runeName = runeName;
        temp.runeDescription = runeDescription;
        temp.runeImageLocation = runeImageLocation;
        temp.rank = rank;
        temp.harmful = harmful;
        temp.helpful = helpful;
        temp.selfHarm = selfHarm;
        temp.formRuneType = formRuneType;
        temp.formDamageMod = formDamageMod;
        return temp;
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
                return 0;
        }
    }
}