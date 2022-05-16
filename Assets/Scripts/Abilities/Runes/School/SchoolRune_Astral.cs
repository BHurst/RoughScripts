using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Astral : SchoolRune
{
    public SchoolRune_Astral()
    {
        rank = 1;
        runeName = "Astral";
        runeDescription = "Meta control. Control of the universe.";
        schoolRuneType = SchoolRuneTag.Astral;
        runeImageLocation = "Abilities/Runes/Schools/Astral";
        baseCastSpeed = 3.6f;
        baseCost = 20f;
        baseCooldown = 0f;
    }
}