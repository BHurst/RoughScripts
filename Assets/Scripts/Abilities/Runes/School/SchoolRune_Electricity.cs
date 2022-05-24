using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Electricity : SchoolRune
{
    public SchoolRune_Electricity()
    {
        rank = 1;
        runeName = "Electricity";
        runeDescription = "Control over the energy of matter.";
        schoolRuneType = SchoolRuneTag.Electricity;
        runeImageLocation = "Abilities/Runes/Schools/Electricity";
        baseCastTime = 1.8f;
        baseCost = 8f;
        baseCooldown = 0f;
        damageMod = 1.15f;
        SetDamageRanks();
    }
}