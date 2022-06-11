using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentSlot  {
    public SlotName slotName;
    public SlotType slotType;
    public string imageLocation = "Items/";
    public EquipmentInventoryItem itemInSlot;

    public enum SlotName
    {
        Back,
        Chest,
        Head,
        Neck,
        Waist,
        Left_Arm,
        Right_Arm,
        Left_Foot,
        Right_Foot,
        Left_Hand,
        Right_Hand,
        Left_Leg,
        Right_Leg,
        Left_Shoulder,
        Right_Shoulder,
        Left_Weapon,
        Right_Weapon
    }

    public enum SlotType
    {
        None,
        Back,
        Chest,
        Head,
        Neck,
        Waist,
        Arm,
        Foot,
        Hand,
        Leg,
        Shoulder,
        Weapon
    }
}