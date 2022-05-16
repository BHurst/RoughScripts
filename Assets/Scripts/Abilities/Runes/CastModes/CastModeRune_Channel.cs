using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune_Channel : CastModeRune
{
    public CastModeRune_Channel()
    {
        runeName = "Channel";
        runeDescription = "Constant energy is poured from caster.";
        castModeRuneType = CastModeRuneTag.Channel;
        runeImageLocation = "Abilities/Runes/CastModes/Channel";
        baseCastTime = 4f;
    }
}