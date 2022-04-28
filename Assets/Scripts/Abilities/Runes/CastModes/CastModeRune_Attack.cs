using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Attack : CastModeRune
{
    public CastModeRune_Attack()
    {
        runeName = "Attack";
        castModeRuneType = CastModeRuneTag.Attack;
        runeImageLocation = "Abilities/Runes/CastModes/Attack";
        baseCastTime = 0f;
    }
}