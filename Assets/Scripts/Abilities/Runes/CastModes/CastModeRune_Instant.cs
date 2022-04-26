using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Instant : CastModeRune
{
    public CastModeRune_Instant()
    {
        runeName = "Instant";
        castModeRuneType = CastModeRuneTag.Instant;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
        baseCastTime = 0f;
        baseCooldown = 5f;
    }
}