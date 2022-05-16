using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ethereal : SchoolRune
{
    public SchoolRune_Ethereal()
    {
        rank = 1;
        runeName = "Ethereal";
        runeDescription = "Control over the relationship between magic and the soul beings.";
        schoolRuneType = SchoolRuneTag.Ethereal;
        runeImageLocation = "Abilities/Runes/Schools/Ethereal";
        baseCastSpeed = 2f;
        baseCost = 7f;
        baseCooldown = 0f;
    }
}