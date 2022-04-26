using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Kinetic : SchoolRune
{
    public SchoolRune_Kinetic()
    {
        schoolRuneType = SchoolRuneTag.Kinetic;
        runeImageLocation = "Abilities/Runes/Schools/Kinetic";
        baseDamage = 7;
    }
}