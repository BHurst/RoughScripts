using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Life : SchoolRune
{
    public SchoolRune_Life()
    {
        runeName = "Life";
        schoolRuneType = SchoolRuneTag.Life;
        runeImageLocation = "Abilities/Runes/Schools/Life";
        baseDamage = 4;
    }
}