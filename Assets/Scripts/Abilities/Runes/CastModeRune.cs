using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CastModeRune : Rune
{
    public CastModeRuneTag castModeRuneType;
    public float baseCastTime = 0;
    public float baseCooldown = 0;

    public CastModeRune Clone()
    {
        CastModeRune newCastModeRune = new CastModeRune();
        newCastModeRune.runeName = runeName;
        newCastModeRune.runeDescription = runeDescription;
        newCastModeRune.rank = rank;
        newCastModeRune.harmful = harmful;
        newCastModeRune.helpful = helpful;
        newCastModeRune.selfHarm = selfHarm;
        newCastModeRune.castModeRuneType = castModeRuneType;
        newCastModeRune.baseCastTime = baseCastTime;
        newCastModeRune.baseCooldown = baseCooldown;
        return newCastModeRune;
    }
}