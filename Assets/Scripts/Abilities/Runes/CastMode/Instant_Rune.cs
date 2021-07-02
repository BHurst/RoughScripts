using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant_Rune : CastModeRune
{
    public Instant_Rune()
    {
        castTime = 0f;
        castMode = CastModeRuneTag.Instant;
    }
}