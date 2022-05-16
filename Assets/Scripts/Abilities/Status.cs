using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status
{
    public string name = "";
    public Guid sourceUnit;
    public float rate = 0;
    public List<ModifierGroup> modifierGroups = new List<ModifierGroup>();
    public float maxDuration = 0;
    public float currentDuration = 0;
    public bool setToRemove = false;
    public string imageLocation = "Abilities/Runes/Schools/Default";
    public bool refreshable = true;
    public int stacks = 1;
    public int maxStacks = 1;
    public bool stackable = false;
}