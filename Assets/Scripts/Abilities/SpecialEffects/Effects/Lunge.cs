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
        rootUnit.transform.GetComponent<Rigidbody>().AddForce(dir * 15, ForceMode.Impulse);
        rootUnit.moveAbilityTimer = 0;
    }
}