using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Water : SchoolRune
{
    public SchoolRune_Water()
    {
        runeName = "Water";
        schoolRuneType = SchoolRuneTag.Water;
        runeImageLocation = "Abilities/Runes/Schools/Water";
        baseDamage = 5f;
        baseCastSpeed = 1.7f;
        baseCost = 6f;
        baseCooldown = 1f;
    }
}