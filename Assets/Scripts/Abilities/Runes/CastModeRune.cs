using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModeRune : Rune
{
    public CastModeRuneTag castModeRuneType;

    public float BaseCastTime()
    {
        switch (rank)
        {
            case 1:
                return 1;
            case 2:
                return 1.1f;
            case 3:
                return 1.2f;
            case 4:
                return 1.35f;
            case 5:
                return 1.5f;
            case 6:
                return 1.75f;
            case 7:
                return 2;
            case 8:
                return 2.3f;
            case 9:
                return 2.6f;
            case 10:
                return 3;
            default:
                return 1;
        }
    }

    public float Cooldown()
    {
        switch (rank)
        {
            case 1:
                return 5;
            case 2:
                return 4.5f;
            case 3:
                return 4;
            case 4:
                return 3.5f;
            case 5:
                return 3;
            case 6:
                return 2.5f;
            case 7:
                return 2;
            case 8:
                return 1.5f;
            case 9:
                return 1f;
            case 10:
                return .5f;
            default:
                return 1;
        }
    }
}