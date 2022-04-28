using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ice : SchoolRune
{
    public SchoolRune_Ice()
    {
        runeName = "Ice";
        schoolRuneType = SchoolRuneTag.Ice;
        runeImageLocation = "Abilities/Runes/Schools/Ice";
        baseDamage = 5f;
        baseCastSpeed = 2.1f;
        baseCost = 7.5f;
        baseCooldown = 3f;
    }
}