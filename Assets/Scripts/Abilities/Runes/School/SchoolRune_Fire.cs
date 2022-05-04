using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune_Fire : SchoolRune
{
    public SchoolRune_Fire()
    {
        rank = 1;
        runeName = "Fire";
        schoolRuneType = SchoolRuneTag.Fire;
        runeImageLocation = "Abilities/Runes/Schools/Fire";
        schoolDamageMod = 2.6f;
        baseCastSpeed = 2.4f;
        baseCost = 14f;
        baseCooldown = 0f;
    }
}