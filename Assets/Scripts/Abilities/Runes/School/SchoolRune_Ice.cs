using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ice : SchoolRune
{
    public SchoolRune_Ice()
    {
        rank = 1;
        runeName = "Ice";
        runeDescription = "Control over heat, but backwards.";
        schoolRuneType = SchoolRuneTag.Ice;
        runeImageLocation = "Abilities/Runes/Schools/Ice";
        baseCastTime = 2f;
        baseCost = 9f;
        baseCooldown = 0f;
        damageMod = .85f;
    }
}