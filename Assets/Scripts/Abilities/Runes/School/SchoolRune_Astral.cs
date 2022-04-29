using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Astral : SchoolRune
{
    public SchoolRune_Astral()
    {
        rank = 1;
        runeName = "Astral";
        schoolRuneType = SchoolRuneTag.Astral;
        runeImageLocation = "Abilities/Runes/Schools/Astral";
        schoolDamageMod = 1.4f;
        baseCastSpeed = 3.6f;
        baseCost = 20f;
        baseCooldown = 15f;
    }
}