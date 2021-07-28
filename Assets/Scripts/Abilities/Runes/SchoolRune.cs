using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SchoolRune : Rune
{
    public SchoolRuneTag schoolRuneType;

    public SchoolRune Clone()
    {
        SchoolRune temp = new SchoolRune();
        temp.runeName = runeName;
        temp.runeDescription = runeDescription;
        temp.rank = rank;
        temp.harmful = harmful;
        temp.helpful = helpful;
        temp.selfHarm = selfHarm;
        temp.schoolRuneType = schoolRuneType;
        return temp;
    }

    public override string RuneImageLocation()
    {
        switch (schoolRuneType)
        {
            case SchoolRuneTag.Air:
                return "Abilities/Runes/Schools/Air";
            case SchoolRuneTag.Arcane:
                return "Abilities/Runes/Schools/Arcane";
            case SchoolRuneTag.Astral:
                return "Abilities/Runes/Schools/Astral";
            case SchoolRuneTag.Electricity:
                return "Abilities/Runes/Schools/Electricity";
            case SchoolRuneTag.Ethereal:
                return "Abilities/Runes/Schools/Ethereal";
            case SchoolRuneTag.Ice:
                return "Abilities/Runes/Schools/Ice";
            case SchoolRuneTag.Fire:
                return "Abilities/Runes/Schools/Fire";
            case SchoolRuneTag.Kinetic:
                return "Abilities/Runes/Schools/Kinetic";
            case SchoolRuneTag.Nature:
                return "Abilities/Runes/Schools/Nature";
            case SchoolRuneTag.Water:
                return "Abilities/Runes/Schools/Water";
            default:
                return "Abilities/Runes/Schools/Default";
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
                return 0;
        }
    }
}