using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Kinetic : SchoolRune
{
    public SchoolRune_Kinetic()
    {
        runeName = "Kinetic";
        schoolRuneType = SchoolRuneTag.Kinetic;
        runeImageLocation = "Abilities/Runes/Schools/Kinetic";
        baseDamage = 13;
        baseCastSpeed = .6f;
        baseCost = 5f;
        baseCooldown = 0f;
    }
}