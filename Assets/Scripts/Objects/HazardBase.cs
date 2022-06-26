using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HazardBase : RootEntity
{
    public float hazardOverrideDamage;
    public SchoolRune.SchoolRuneTag school;
    public float hazardArea;

    public void InitializeEntity(HazardBase newHazard)
    {
        team = -1;
        GameWorldReferenceClass.GW_listOfHazards.Add(newHazard);
    }
}