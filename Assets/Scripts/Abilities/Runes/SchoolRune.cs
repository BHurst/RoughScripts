using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SchoolRune : Rune
{
    public SchoolRuneTag schoolRuneType;
    public float baseDamage;

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
        newSchoolRune.baseDamage = baseDamage;
        return newSchoolRune;
    }
}