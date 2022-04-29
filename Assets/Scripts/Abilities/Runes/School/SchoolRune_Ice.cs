using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Ice : SchoolRune
{
    public SchoolRune_Ice()
    {
        rank = 1;
        runeName = "Ice";
        schoolRuneType = SchoolRuneTag.Ice;
        runeImageLocation = "Abilities/Runes/Schools/Ice";
        schoolDamageMod = .8f;
        baseCastSpeed = 2f;
        baseCost = 9f;
        baseCooldown = 3f;
    }
}