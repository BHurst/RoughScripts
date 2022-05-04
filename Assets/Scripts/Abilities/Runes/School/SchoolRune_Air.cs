using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Air : SchoolRune
{
    public SchoolRune_Air()
    {
        rank = 1;
        runeName = "Air";
        schoolRuneType = SchoolRuneTag.Air;
        runeImageLocation = "Abilities/Runes/Schools/Air";
        schoolDamageMod = .6f;
        baseCastSpeed = 1.2f;
        baseCost = 7f;
        baseCooldown = 0f;
    }
}