using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : ISpecialEffect
{
    public string specialEffectName { get; set; } = "Retreat";
    public int specialEffectID { get; set; }

    public void Effect(Guid target)
    {
        Vector2 flattenedDir = new Vector2(-Camera.main.transform.forward.x, -Camera.main.transform.forward.z).normalized;
        Vector3 dir = new Vector3(flattenedDir.x, 0, flattenedDir.y);

        GameWorldReferenceClass.GetUnitByID(target).GetComponent<RootUnit>().Shove(15, dir);
    }
}