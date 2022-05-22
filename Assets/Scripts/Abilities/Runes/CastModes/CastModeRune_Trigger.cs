using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Trigger : CastModeRune
{
    // Start is called before the first frame update
    public CastModeRune_Trigger()
    {
        runeName = "Trigger";
        runeDescription = "Magic that must be used via another ability.";
        castModeRuneType = CastModeRuneTag.Trigger;
        runeImageLocation = "Abilities/Runes/CastModes/Instant";
    }
}