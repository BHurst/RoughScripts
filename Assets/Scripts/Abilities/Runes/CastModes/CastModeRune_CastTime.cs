using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_CastTime : CastModeRune
{
    public CastModeRune_CastTime()
    {
        runeName = "Cast Time";
        runeDescription = "After a duration, the user creates magic under their own power.";
        castModeRuneType = CastModeRuneTag.CastTime;
        runeImageLocation = "Abilities/Runes/CastModes/CastTime";
    }
}