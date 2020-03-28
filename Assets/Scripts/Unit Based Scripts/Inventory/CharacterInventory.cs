using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterInventory
{
    public List<InventorySlot> Inventory = new List<InventorySlot>();
    public int amountNotPickedUp = 0;

    public void PickUp(WorldItem itemToBeGrabbed)
    {
        amountNotPickedUp = itemToBeGrabbed.iStats.stackCount;

        if (itemToBeGrabbed.iStats.itemName == "Money")
        {
            GameWorldReferenceClass.PartyMoney += itemToBeGrabbed.iStats.itemValue * itemToBeGrabbed.iStats.stackCount;
            ResourceManager.HideItem(itemToBeGrabbed);
        }
        else if (AddItem(ConvertItemToInventory(itemToBeGrabbed)))
            ResourceManager.HideItem(itemToBeGrabbed);
        else
        {
            itemToBeGrabbed.iStats.stackCount = amountNotPickedUp;
            if(itemToBeGrabbed.iStats.stackable)
                ErrorScript.DisplayError("Cannot carry any more " + itemToBeGrabbed.iStats.itemName + "s.");
            else
                ErrorScript.DisplayError("Cannot carry another " + itemToBeGrabbed.iStats.itemName);
        }
    }

    public bool ReceiveItem(WorldItem itemToBeGrabbed)
    {
        amountNotPickedUp = itemToBeGrabbed.iStats.stackCount;
        if (AddItem(ConvertItemToInventory(itemToBeGrabbed)))
            return true;
        else
            return false;
    }

    public bool RemoveItem(InventoryItem itemToRemove)
    {
        foreach (InventorySlot invSlot in Inventory)
        {
            if (invSlot.itemInSlot == itemToRemove)
            {
                Inventory.Remove(invSlot);
                //Debug.Log(itemToRemove.itemName + " was removed from slot " + invSlot.slotNumber);
                return true;
            }
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public void DropEverything(RootUnit NPCtoDrop)
    {
        foreach (InventorySlot slot in Inventory)
        {
            DropItem(slot.itemInSlot, NPCtoDrop);
            slot.itemInSlot = new InventoryItem();
        }
    }

    public bool DropItem(InventoryItem itemToRemove, Vector3 mouse)
    {
        if (RemoveItem(itemToRemove))
        {
            WorldItem tempItem = new WorldItem();
            tempItem.iStats = itemToRemove.iStats;
            GameObject.Instantiate(tempItem, new Vector3 { x = mouse.x, y = mouse.y + .3f, z = mouse.z }, new Quaternion(0, 0, 0, 0));
            return true;
        }
        return false;
    }

    public bool DropItem(InventoryItem itemToRemove, RootUnit unitToDrop)
    {
        if (RemoveItem(itemToRemove))
        {
            if (ResourceManager.AllWorldItems.Count > 0)
            {
                WorldItem itemBeingCreated = ResourceManager.RestoreItem();
                itemBeingCreated.iStats = itemToRemove.iStats;
                itemBeingCreated.transform.position = new Vector3(UnityEngine.Random.Range(-.25f, .25f) + unitToDrop.transform.position.x, .25f + unitToDrop.transform.position.y, UnityEngine.Random.Range(-.25f, .25f) + unitToDrop.transform.position.z);
                itemBeingCreated.transform.LookAt(unitToDrop.transform);
                itemBeingCreated.transform.Rotate(0, 180, 0);
                itemBeingCreated.GetComponent<Rigidbody>().velocity = itemBeingCreated.transform.forward * UnityEngine.Random.Range(4f, 7f);
                itemBeingCreated.transform.rotation = UnityEngine.Random.rotation;
                itemBeingCreated.transform.SetParent(GameObject.Find("Items").transform);
                itemBeingCreated.gameObject.SetActive(true);
                return true;
            }
            else
            {
                GameObject freshWorldItem = GameObject.Instantiate(Resources.Load("BlankItem")) as GameObject;
                WorldItem itemBeingCreated = freshWorldItem.GetComponent<WorldItem>();
                itemBeingCreated.iStats = itemToRemove.iStats;
                itemBeingCreated.transform.position = new Vector3(UnityEngine.Random.Range(-.25f, .25f) + unitToDrop.transform.position.x, .25f + unitToDrop.transform.position.y, UnityEngine.Random.Range(-.25f, .25f) + unitToDrop.transform.position.z);
                itemBeingCreated.transform.LookAt(unitToDrop.transform);
                itemBeingCreated.transform.Rotate(0, 180, 0);
                itemBeingCreated.GetComponent<Rigidbody>().velocity = itemBeingCreated.transform.forward * UnityEngine.Random.Range(4f, 7f);
                itemBeingCreated.transform.rotation = UnityEngine.Random.rotation;
                freshWorldItem.transform.SetParent(GameObject.Find("Items").transform);
                return true;
            }
        }
        return false;
    }

    public bool CheckItem(InventoryItem itemToCheck)
    {
        foreach (InventorySlot invSlot in Inventory)
        {
            if (invSlot.itemInSlot == itemToCheck)
                return true;
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public InventoryItem ConvertItemToInventory(WorldItem toBeConverted)
    {
        InventoryItem itemForInventory = new InventoryItem();

        itemForInventory.iStats = toBeConverted.iStats;

        return itemForInventory;
    }

    public bool AddItem(InventoryItem itemToAdd)
    {
        bool maxStackSize = false;
        if (itemToAdd.iStats.stackable)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].itemInSlot.iStats.itemName == itemToAdd.iStats.itemName && Inventory[i].itemInSlot.iStats.stackCount != Inventory[i].itemInSlot.iStats.stackSize)
                {
                    amountNotPickedUp = Inventory[i].itemInSlot.StackIncrease(itemToAdd.iStats.stackCount);
                    if (amountNotPickedUp > 0)
                    {
                        itemToAdd.iStats.stackCount = amountNotPickedUp;
                        return false;
                    }
                    else
                        return true;
                }

                if (Inventory[i].itemInSlot.iStats.itemName == itemToAdd.iStats.itemName && Inventory[i].itemInSlot.iStats.stackCount == Inventory[i].itemInSlot.iStats.stackSize)
                    maxStackSize = true;
            }
            if (maxStackSize)
                return false;
            else
            {
                Inventory.Add(new InventorySlot { itemInSlot = itemToAdd });
                return true;
            }
        }
        else
        {
            Inventory.Add(new InventorySlot { itemInSlot = itemToAdd });
            return true;
        }
        
    }
}