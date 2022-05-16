using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Arcane : SchoolRune
{
    public SchoolRune_Arcane()
    {
        rank = 1;
        runeName = "Arcane";
        runeDescription = "Control over magic in its natural form.";
        schoolRuneType = SchoolRuneTag.Arcane;
        runeImageLocation = "Abilities/Runes/Schools/Arcane";
        baseCastSpeed = 2f;
        baseCost = 12f;
        baseCooldown = 0f;
    }
}