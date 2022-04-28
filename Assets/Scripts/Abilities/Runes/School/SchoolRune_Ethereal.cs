using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ethereal : SchoolRune
{
    public SchoolRune_Ethereal()
    {
        runeName = "Ethereal";
        schoolRuneType = SchoolRuneTag.Ethereal;
        runeImageLocation = "Abilities/Runes/Schools/Ethereal";
        baseDamage = 10f;
        baseCastSpeed = 2.1f;
        baseCost = 6f;
        baseCooldown = 1f;
    }
}