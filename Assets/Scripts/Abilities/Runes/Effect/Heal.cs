using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Rune
{
    public int rank { get; set; } = 1;
    public bool enemyHeal = false;
    private int actualHeal;

    public int healing
    {
        get
        {
            DetermineHealRuneValue();
            return actualHeal;
        }
        set
        {
            actualHeal = value;
        }
    }

    public void DetermineHealRuneValue()
    {
        switch (rank)
        {
            case 1:
                actualHeal = 1;
                break;
            case 2:
                actualHeal = 3;
                break;
            case 3:
                actualHeal = 7;
                break;
            case 4:
                actualHeal = 15;
                break;
            case 5:
                actualHeal = 25;
                break;
            default:
                break;
        }
    }
}