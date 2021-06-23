using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : ISpecialEffect
{
    public string specialEffectName { get; set; } = "Dash";
    public int specialEffectID { get; set; }

    public void Effect(Guid target)
    {
        Vector2 flattenedDir = new Vector2(Camera.main.transform.forward.x, Camera.main.transform.forward.z).normalized;
        Vector3 dir = new Vector3(flattenedDir.x, 0, flattenedDir.y);

        RootUnit rootUnit = GameWorldReferenceClass.GetUnitByID(target).GetComponent<RootUnit>();
        rootUnit.transform.GetComponent<Rigidbody>().AddForce(dir * 3);
        rootUnit.moveAbilityTimer = 0;
    }
}