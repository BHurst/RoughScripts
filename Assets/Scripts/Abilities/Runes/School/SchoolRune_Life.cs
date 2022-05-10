using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Life : SchoolRune
{
    public SchoolRune_Life()
    {
        rank = 1;
        runeName = "Life";
        schoolRuneType = SchoolRuneTag.Life;
        runeImageLocation = "Abilities/Runes/Schools/Life";
        baseCastSpeed = 3.2f;
        baseCost = 7f;
        baseCooldown = 0f;
    }
}