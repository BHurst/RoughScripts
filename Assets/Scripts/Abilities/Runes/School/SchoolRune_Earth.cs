using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Earth : SchoolRune
{
    public SchoolRune_Earth()
    {
        rank = 1;
        runeName = "Earth";
        schoolRuneType = SchoolRuneTag.Earth;
        runeImageLocation = "Abilities/Runes/Schools/Earth";
        schoolDamageMod = 1f;
        baseCastSpeed = 2f;
        baseCost = 9f;
        baseCooldown = 3f;
    }
}