using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Kinetic : SchoolRune
{
    public SchoolRune_Kinetic()
    {
        rank = 1;
        runeName = "Kinetic";
        runeDescription = "Control over the force behind movement.";
        schoolRuneType = SchoolRuneTag.Kinetic;
        runeImageLocation = "Abilities/Runes/Schools/Kinetic";
        baseCastSpeed = .5f;
        baseCost = 5f;
        baseCooldown = 0f;
    }
}