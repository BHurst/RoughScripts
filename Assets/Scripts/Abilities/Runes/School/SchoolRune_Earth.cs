using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Earth : SchoolRune
{
    public SchoolRune_Earth()
    {
        runeName = "Earth";
        schoolRuneType = SchoolRuneTag.Earth;
        runeImageLocation = "Abilities/Runes/Schools/Earth";
        baseDamage = 10f;
        baseCastSpeed = 2.1f;
        baseCost = 7.5f;
        baseCooldown = 3f;
    }
}