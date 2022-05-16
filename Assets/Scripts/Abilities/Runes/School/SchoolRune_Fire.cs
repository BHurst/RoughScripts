using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Fire : SchoolRune
{
    public SchoolRune_Fire()
    {
        rank = 1;
        runeName = "Fire";
        runeDescription = "Control over heat.";
        schoolRuneType = SchoolRuneTag.Fire;
        runeImageLocation = "Abilities/Runes/Schools/Fire";
        baseCastSpeed = 2.4f;
        baseCost = 14f;
        baseCooldown = 0f;
    }
}