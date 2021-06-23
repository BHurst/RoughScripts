using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : ISpecialEffect
{
    public string specialEffectName { get; set; } = "Launch";
    public int specialEffectID { get; set; }

    public void Effect(Guid target)
    {
        Vector3 dir = new Vector3(0, 1, 0);

        RootUnit rootUnit = GameWorldReferenceClass.GetUnitByID(target).GetComponent<RootUnit>();
        rootUnit.transform.GetComponent<Rigidbody>().AddForce(dir*3);
        rootUnit.moveAbilityTimer = 0;
    }
}