using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : CastModeRune
{
    public Instant()
    {
        castTime = 0f;
        castMode = CastModeRuneTag.Instant;
    }
}