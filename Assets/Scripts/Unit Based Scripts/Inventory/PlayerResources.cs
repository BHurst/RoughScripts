using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources
{
    public int magicDust = 100;

    public bool CostCheck(int cost)
    {
        if (magicDust - cost >= 0)
            return true;

        return false;
    }
}