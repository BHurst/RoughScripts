using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Fire : SchoolRune
{
    public SchoolRune_Fire()
    {
        runeName = "Fire";
        schoolRuneType = SchoolRuneTag.Fire;
        runeImageLocation = "Abilities/Runes/Schools/Fire";
        baseDamage = 24f;
        baseCastSpeed = 2.5f;
        baseCost = 12f;
        baseCooldown = 7.5f;
    }
}