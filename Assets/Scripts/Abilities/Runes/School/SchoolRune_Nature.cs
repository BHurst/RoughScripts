using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Nature : SchoolRune
{
    public SchoolRune_Nature()
    {
        schoolRuneType = SchoolRuneTag.Nature;
        runeImageLocation = "Abilities/Runes/Schools/Nature";
        baseDamage = 6;
    }
}