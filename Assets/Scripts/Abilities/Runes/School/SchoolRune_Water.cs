using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Water : SchoolRune
{
    public SchoolRune_Water()
    {
        rank = 1;
        runeName = "Water";
        runeDescription = "Control over liquids.";
        schoolRuneType = SchoolRuneTag.Water;
        runeImageLocation = "Abilities/Runes/Schools/Water";
        baseCastSpeed = 1.8f;
        baseCost = 7f;
        baseCooldown = 0f;
        damageMod = .85f;
        SetDamageRanks();
    }
}