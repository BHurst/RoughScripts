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
    public float damageMod;

    public float[] damageRanks;

    public void SetDamageRanks()
    {
        damageRanks = new float[] {
            55,
            60,
            67,
            74,
            81,
            89,
            98,
            108,
            118,
            130,
            143,
            157,
            173,
            190,
            209,
            230,
            253,
            278,
            306,
            336
        };
    }

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
        newSchoolRune.damageMod = damageMod;
        return newSchoolRune;
    }

    public float GetDamage()
    {
        switch (rank)
        {
            case 1:
                return 55 * damageMod;
            case 2:
                return 60 * damageMod;
            case 3:
                return 67 * damageMod;
            case 4:
                return 74 * damageMod;
            case 5:
                return 81 * damageMod;
            case 6:
                return 89 * damageMod;
            case 7:
                return 98 * damageMod;
            case 8:
                return 108 * damageMod;
            case 9:
                return 118 * damageMod;
            case 10:
                return 130 * damageMod;
            case 11:
                return 143 * damageMod;
            case 12:
                return 157 * damageMod;
            case 13:
                return 173 * damageMod;
            case 14:
                return 190 * damageMod;
            case 15:
                return 209 * damageMod;
            case 16:
                return 230 * damageMod;
            case 17:
                return 253 * damageMod;
            case 18:
                return 278 * damageMod;
            case 19:
                return 306 * damageMod;
            case 20:
                return 336 * damageMod;
            default:
                return 0;
        }
    }
}