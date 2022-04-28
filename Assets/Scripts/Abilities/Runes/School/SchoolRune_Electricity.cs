using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Electricity : SchoolRune
{
    public SchoolRune_Electricity()
    {
        runeName = "Electricity";
        schoolRuneType = SchoolRuneTag.Electricity;
        runeImageLocation = "Abilities/Runes/Schools/Electricity";
        baseDamage = 20;
        baseCastSpeed = 1.7f;
        baseCost = 6.5f;
        baseCooldown = 2f;
    }
}