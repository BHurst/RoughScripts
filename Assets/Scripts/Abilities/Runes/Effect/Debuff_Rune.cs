using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_Rune : Rune, IRank
{
    public int rank { get; set; } = 1;
    private float actualDuration;
    public bool selfHarm = false;
    private int actualDamage;

    public int damage
    {
        get
        {
            DetermineDebuffStrength();
            return actualDamage;
        }
        set
        {
            actualDamage = value;
        }
    }

    public float duration
    {
        get
        {
            DetermineDebuffStrength();
            return actualDuration;
        }
        set
        {
            actualDuration = value;
        }
    }

    private void DetermineDebuffStrength()
    {
        switch (rank)
        {
            case 1:
                {
                    actualDamage = 1;
                    actualDuration = 3;
                }
                break;
            case 2:
                {
                    actualDamage = 3;
                    actualDuration = 4;
                }
                break;
            case 3:
                {
                    actualDamage = 7;
                    actualDuration = 5;
                }
                break;
            case 4:
                {
                    actualDamage = 15;
                    actualDuration = 7;
                }
                break;
            case 5:
                {
                    actualDamage = 25;
                    actualDuration = 10;
                }
                break;
            default:
                break;
        }
    }
}