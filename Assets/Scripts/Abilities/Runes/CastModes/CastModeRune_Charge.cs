using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Charge : CastModeRune
{
    public float chargeAmount;
    public CastModeRune_Charge()
    {
        runeName = "Charge";
        runeDescription = "Magic is gathered, gaining strength over time.";
        castModeRuneType = CastModeRuneTag.Charge;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
        chargeAmount = 0;
    }
}