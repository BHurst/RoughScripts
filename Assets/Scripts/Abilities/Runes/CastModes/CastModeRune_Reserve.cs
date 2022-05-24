using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Reserve : CastModeRune
{
    public CastModeRune_Reserve()
    {
        runeName = "Reserve";
        runeDescription = "Magic is readied ahead of time, the instantly used on demand.";
        castModeRuneType = CastModeRuneTag.Reserve;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
    }
}