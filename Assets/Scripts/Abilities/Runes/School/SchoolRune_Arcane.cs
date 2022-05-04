using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Arcane : SchoolRune
{
    public SchoolRune_Arcane()
    {
        rank = 1;
        runeName = "Arcane";
        schoolRuneType = SchoolRuneTag.Arcane;
        runeImageLocation = "Abilities/Runes/Schools/Arcane";
        schoolDamageMod = 3f;
        baseCastSpeed = 2f;
        baseCost = 12f;
        baseCooldown = 0f;
    }
}