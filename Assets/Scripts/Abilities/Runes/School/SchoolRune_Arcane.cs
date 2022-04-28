using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Arcane : SchoolRune
{
    public SchoolRune_Arcane()
    {
        runeName = "Arcane";
        schoolRuneType = SchoolRuneTag.Arcane;
        runeImageLocation = "Abilities/Runes/Schools/Arcane";
        baseDamage = 30f;
        baseCastSpeed = 2.1f;
        baseCost = 10f;
        baseCooldown = 6f;
    }
}