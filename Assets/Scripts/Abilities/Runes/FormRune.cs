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
                return 3;
            case 2:
                return 4;
            case 3:
                return 5;
            case 4:
                return 7;
            case 5:
                return 10;
            default:
                return 3;
        }
    }
}