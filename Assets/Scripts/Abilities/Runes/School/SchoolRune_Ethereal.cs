using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ethereal : SchoolRune
{
    public SchoolRune_Ethereal()
    {
        rank = 1;
        runeName = "Ethereal";
        schoolRuneType = SchoolRuneTag.Ethereal;
        runeImageLocation = "Abilities/Runes/Schools/Ethereal";
        schoolDamageMod = 1f;
        baseCastSpeed = 2f;
        baseCost = 7f;
        baseCooldown = 1f;
    }
}