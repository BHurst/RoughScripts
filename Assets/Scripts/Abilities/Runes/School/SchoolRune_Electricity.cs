using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Electricity : SchoolRune
{
    public SchoolRune_Electricity()
    {
        schoolRuneType = SchoolRuneTag.Electricity;
        runeImageLocation = "Abilities/Runes/Schools/Electricity";
        baseDamage = 6;
    }
}