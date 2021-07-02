using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastTime_Rune : CastModeRune
{
    public CastTime_Rune()
    {
        castTime = 1.5f;
        castMode = CastModeRuneTag.CastTime;
    }
}