using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : ISpecialEffect
{
    public string specialEffectName { get; set; } = "Lunge";
    public int specialEffectID { get; set; }

    public void Effect(Guid target)
    {
        RootUnit rootUnit = GameWorldReferenceClass.GetUnitByID(target).GetComponent<RootUnit>();
        Vector3 dir = Camera.main.transform.forward;
        GameWorldReferenceClass.GetUnitByID(target).GetComponent<RootUnit>().Shove(15, dir);
        rootUnit.moveAbilityTimer = 0;
    }
}