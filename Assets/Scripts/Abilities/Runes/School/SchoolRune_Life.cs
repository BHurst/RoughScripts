using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Life : SchoolRune
{
    public SchoolRune_Life()
    {
        runeName = "Life";
        schoolRuneType = SchoolRuneTag.Life;
        runeImageLocation = "Abilities/Runes/Schools/Life";
        baseDamage = 3f;
        baseCastSpeed = 3.5f;
        baseCost = 6f;
        baseCooldown = 1f;
    }
}