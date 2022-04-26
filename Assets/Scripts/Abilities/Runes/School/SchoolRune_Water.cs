using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Water : SchoolRune
{
    public SchoolRune_Water()
    {
        schoolRuneType = SchoolRuneTag.Water;
        runeImageLocation = "Abilities/Runes/Schools/Water";
        baseDamage = 6;
    }
}