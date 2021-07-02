using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public int itemID = 0;
    public string itemName = "DEFAULT_ITEM";
    public string itemImageLocation = "Prefabs/Images/ItemPlaceholder";
    public string itemDescription = "A default item placeholder.";
    public ItemType itemType;

    public virtual void Use(RootUnit user)
    {

    }

    
}

public enum ItemType
{
    Basic,
    Consumable,
    Equipment
}

public enum EquipmentSlotName
{
    None,
    Back,
    Chest,
    Foot,
    ForeArm,
    Hand,
    Head,
    Neck,
    Shin,
    Shoulder,
    Thigh,
    UpperArm,
    Waist
}