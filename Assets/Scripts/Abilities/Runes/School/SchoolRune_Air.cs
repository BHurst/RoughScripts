using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Air : SchoolRune
{
    public SchoolRune_Air()
    {
        runeName = "Air";
        schoolRuneType = SchoolRuneTag.Air;
        runeImageLocation = "Abilities/Runes/Schools/Air";
        baseDamage = 2f;
        baseCastSpeed = .75f;
        baseCost = 6f;
        baseCooldown = 1f;
    }
}