using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Air : SchoolRune
{
    public SchoolRune_Air()
    {
        schoolRuneType = SchoolRuneTag.Air;
        runeImageLocation = "Abilities/Runes/Schools/Air";
        baseDamage = 5;
    }
}