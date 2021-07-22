using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public Guid sourceUnit;
    public float rate = 0;
    public List<ModifierGroup> modifierGroups = new List<ModifierGroup>();
    public float maxDuration = 0;
    public float currentDuration = 0;
}