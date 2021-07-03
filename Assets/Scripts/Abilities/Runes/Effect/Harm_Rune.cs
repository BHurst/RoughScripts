using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Harm_Rune : Rune
{
    public int rank = 1;
    public bool selfHarm = false;
    public bool active = false;

    public float Value()
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