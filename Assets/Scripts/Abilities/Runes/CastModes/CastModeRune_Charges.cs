using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Charges : CastModeRune
{
    public CastModeRune_Charges()
    {
        runeName = "Charges";
        runeDescription = "Magic is readied ahead of time, the instantly used on demand.";
        castModeRuneType = CastModeRuneTag.Charges;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
    }
}