using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SchoolRune : Rune
{
    public SchoolRuneTag schoolRuneType;
    public float baseCastSpeed;
    public float baseCost;
    public float baseCooldown;

    public SchoolRune Clone()
    {
        SchoolRune newSchoolRune = new SchoolRune();
        newSchoolRune.runeName = runeName;
        newSchoolRune.runeDescription = runeDescription;
        newSchoolRune.rank = rank;
        newSchoolRune.harmful = harmful;
        newSchoolRune.helpful = helpful;
        newSchoolRune.selfHarm = selfHarm;
        newSchoolRune.schoolRuneType = schoolRuneType;
        newSchoolRune.baseCastSpeed = baseCastSpeed;
        newSchoolRune.baseCost = baseCost;
        newSchoolRune.baseCooldown = baseCooldown;
        return newSchoolRune;
    }

    public float GetDamage()
    {
        switch (rank)
        {
            case 1:
                return 55;
            case 2:
                return 60;
            case 3:
                return 67;
            case 4:
                return 74;
            case 5:
                return 81;
            case 6:
                return 89;
            case 7:
                return 98;
            case 8:
                return 108;
            case 9:
                return 118;
            case 10:
                return 130;
            case 11:
                return 143;
            case 12:
                return 157;
            case 13:
                return 173;
            case 14:
                return 190;
            case 15:
                return 209;
            case 16:
                return 230;
            case 17:
                return 253;
            case 18:
                return 278;
            case 19:
                return 306;
            case 20:
                return 336;
            default:
                return 0;
        }
    }
}