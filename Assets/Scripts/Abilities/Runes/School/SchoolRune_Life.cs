using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Life : SchoolRune
{
    public SchoolRune_Life()
    {
        rank = 1;
        runeName = "Life";
        runeDescription = "Control over the physical nature of living beings.";
        schoolRuneType = SchoolRuneTag.Life;
        runeImageLocation = "Abilities/Runes/Schools/Life";
        baseCastTime = 3.2f;
        baseCost = 7f;
        baseCooldown = 0f;
        damageMod = .8f;
    }
}