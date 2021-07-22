using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune : Rune
{
    public FormRuneTag formRuneType;
    public float formDamageMod = 1f;

    public float Duration()
    {
        switch (rank)
        {
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
            case 4:
                return 5;
            case 5:
                return 7;
            case 6:
                return 8;
            case 7:
                return 10;
            case 8:
                return 12;
            case 9:
                return 15;
            case 10:
                return 20;
            default:
                return 0;
        }
    }
}