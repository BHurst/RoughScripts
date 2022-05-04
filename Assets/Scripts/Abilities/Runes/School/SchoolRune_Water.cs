using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Water : SchoolRune
{
    public SchoolRune_Water()
    {
        rank = 1;
        runeName = "Water";
        schoolRuneType = SchoolRuneTag.Water;
        runeImageLocation = "Abilities/Runes/Schools/Water";
        schoolDamageMod = .8f;
        baseCastSpeed = 1.8f;
        baseCost = 7f;
        baseCooldown = 0f;
    }
}