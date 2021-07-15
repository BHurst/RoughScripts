using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolRune : Rune
{
    public SchoolRuneTag schoolRuneType;

    public float Damage()
    {
        switch (rank)
        {
            case 1:
                return 1;
            case 2:
                return 3;
            case 3:
                return 7;
            case 4:
                return 15;
            case 5:
                return 25;
            default:
                return 1;
        }
    }
}