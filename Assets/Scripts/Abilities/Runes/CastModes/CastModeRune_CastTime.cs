using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_CastTime : CastModeRune
{
    public CastModeRune_CastTime()
    {
        castModeRuneType = CastModeRuneTag.CastTime;
        runeImageLocation = "Abilities/Runes/CastModes/CastTime";
        baseCastTime = 2f;
        baseCooldown = 0f;
    }
}