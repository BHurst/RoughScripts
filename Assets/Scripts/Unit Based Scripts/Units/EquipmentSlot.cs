﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentSlot  {
    public string slotName;
    public string acceptedItem;
    public string imageLocation = "Items/";
    public EquipmentInventoryItem itemInSlot;
}