using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Kinetic : SchoolRune
{
    public SchoolRune_Kinetic()
    {
        rank = 1;
        runeName = "Kinetic";
        schoolRuneType = SchoolRuneTag.Kinetic;
        runeImageLocation = "Abilities/Runes/Schools/Kinetic";
        schoolDamageMod = 1.4f;
        baseCastSpeed = .5f;
        baseCost = 5f;
        baseCooldown = 0f;
    }
}