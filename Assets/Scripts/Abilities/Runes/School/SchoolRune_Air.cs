using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Air : SchoolRune
{
    public SchoolRune_Air()
    {
        rank = 1;
        runeName = "Air";
        runeDescription = "Control over the winds.";
        schoolRuneType = SchoolRuneTag.Air;
        runeImageLocation = "Abilities/Runes/Schools/Air";
        baseCastSpeed = 1.2f;
        baseCost = 7f;
        baseCooldown = 0f;
    }
}