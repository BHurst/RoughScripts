using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Arcane : SchoolRune
{
    public SchoolRune_Arcane()
    {
        schoolRuneType = SchoolRuneTag.Arcane;
        runeImageLocation = "Abilities/Runes/Schools/Arcane";
        baseDamage = 10;
    }
}