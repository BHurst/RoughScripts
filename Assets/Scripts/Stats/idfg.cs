using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idfg
{
    public float Tier1(ModifierGroup modifierGroup)
    {
        if(modifierGroup.Aspect == ModifierGroup.EAspect.Damage || modifierGroup.Aspect == ModifierGroup.EAspect.DamageTaken)
        {
            return  Random.Range(2, 5)/100;
        }
        return 0;
    }
}