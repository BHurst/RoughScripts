using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventoryManager : MonoBehaviour {
    
    public static void AttachEquipment(RootUnit target, InventoryItem equipment)
    {
        switch (equipment.iStats.equipment.fitsInSlot)
        {
            case EquipmentSlotName.Head:
                target.doll.AddEquipment(equipment);
                target.doll.head.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Back:
                target.doll.AddEquipment(equipment);
                target.doll.back.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Chest:
                target.doll.AddEquipment(equipment);
                target.doll.chest.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Arms:
                target.doll.AddEquipment(equipment);
                target.doll.arms.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Legs:
                target.doll.AddEquipment(equipment);
                target.doll.legs.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Mainhand:
                target.doll.AddEquipment(equipment);
                target.doll.mainHand.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Offhand:
                target.doll.AddEquipment(equipment);
                target.doll.offHand.itemInSlot = equipment;
                break;
            case EquipmentSlotName.Neck:
                target.doll.AddEquipment(equipment);
                target.doll.neck.itemInSlot = equipment;
                break;
            case EquipmentSlotName.LeftBracelet:
                target.doll.AddEquipment(equipment);
                target.doll.leftBracelet.itemInSlot = equipment;
                break;
            case EquipmentSlotName.RightBracelet:
                target.doll.AddEquipment(equipment);
                target.doll.rightBracelet.itemInSlot = equipment;
                break;
            default:
                break;
        }
    }

    public static void RemoveEquipment(RootUnit target, EquipmentSlotName slot)
    {
        EquipmentSlot temp = new EquipmentSlot();
        switch (slot)
        {
            case EquipmentSlotName.Head:
                temp = target.doll.head;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Back:
                temp = target.doll.back;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Chest:
                temp = target.doll.chest;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Arms:
                temp = target.doll.arms;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Legs:
                temp = target.doll.legs;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Mainhand:
                temp = target.doll.mainHand;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Offhand:
                temp = target.doll.offHand;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.Neck:
                temp = target.doll.neck;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.LeftBracelet:
                temp = target.doll.leftBracelet;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            case EquipmentSlotName.RightBracelet:
                temp = target.doll.rightBracelet;
                temp.hasItem = false;
                target.doll.RemoveEquipment(temp.itemInSlot);
                temp.itemInSlot = new InventoryItem();
                break;
            default:
                break;
        }
    }
}

public enum EquipmentSlotName
{
    None,
    Head,
    Back,
    Chest,
    Arms,
    Legs,
    Mainhand,
    Offhand,
    Neck,
    LeftBracelet,
    RightBracelet
}