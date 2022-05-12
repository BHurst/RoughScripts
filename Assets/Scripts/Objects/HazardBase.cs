using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBase : RootEntity
{
    public void InitializeEntity(HazardBase newHazard)
    {
        GameWorldReferenceClass.GW_listOfHazards.Add(newHazard);
    }
}