using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Astral : SchoolRune
{
    public SchoolRune_Astral()
    {
        runeName = "Astral";
        schoolRuneType = SchoolRuneTag.Astral;
        runeImageLocation = "Abilities/Runes/Schools/Astral";
        baseDamage = 13f;
        baseCastSpeed = 4.25f;
        baseCost = 21f;
        baseCooldown = 15f;
    }
}