using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harm : Rune, IRank
{
    public int rank { get; set; } = 1;
    public bool selfHarm = false;
    private int actualDamage;

    public int damage
    {
        get
        {
            DetermineDamageRuneValue();
            return actualDamage;
        }
        set
        {
            actualDamage = value;
        }
    }

    private void DetermineDamageRuneValue()
    {
        switch (rank)
        {
            case 1:
                actualDamage = 1;
                break;
            case 2:
                actualDamage = 3;
                break;
            case 3:
                actualDamage = 7;
                break;
            case 4:
                actualDamage = 15;
                break;
            case 5:
                actualDamage = 25;
                break;
            default:
                break;
        }
    }
}