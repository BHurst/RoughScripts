using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Charges : CastModeRune
{
    public CastModeRune_Charges()
    {
        runeName = "Charges";
        castModeRuneType = CastModeRuneTag.Charges;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
    }
}