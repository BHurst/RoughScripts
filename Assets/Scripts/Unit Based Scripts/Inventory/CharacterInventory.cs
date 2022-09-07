﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class CharacterInventory
{
    public Guid owner;
    public List<InventoryItem> Inventory = new List<InventoryItem>();
    public int MaxInventory = 200;
    public int amountNotPickedUp = 0;

    public event EventHandler<int> ItemUsed;
    public event EventHandler<int> ItemDepleted;
    public event EventHandler<InventoryItem> ItemPickedUp;

    public void SetQuickItem(int index)
    {
        GameWorldReferenceClass.GetUnitByID(owner).quickItem = (ConsumableInventoryItem)Inventory[index];
        UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)Inventory[0]);
    }

    public void PickUp(WorldItem itemToBeGrabbed)
    {
        if (AddItem(itemToBeGrabbed.inventoryItem.Clone(), false))
            ResourceManager.HideItem(itemToBeGrabbed);
        else
            ErrorScript.DisplayError("No more room");
    }

    public bool ReceiveItem(InventoryItem itemToBeGrabbed)
    {
        if (AddItem(itemToBeGrabbed.Clone(), false))
            return true;
        else
            return false;
    }

    public bool RemoveItemAtIndex(int index)
    {
        if (Inventory.Count > (index))
        {
            Inventory.RemoveAt(index);
            UIManager.main.inventorySheet.RemoveInventorySlot(index);
            return true;
        }
        return false;
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (Inventory.Contains(item))
        {
            var index = Inventory.IndexOf(item);
            Inventory.Remove(item);
            UIManager.main.inventorySheet.RemoveInventorySlot(index);
            return true;
        }
        return false;
    }

    public bool RemoveItemByID(int itemId)
    {
        if (Inventory.Exists(x => x.itemID == itemId))
        {
            var index = Inventory.FindIndex(0, Inventory.Count, x => x.itemID == itemId);
            Inventory.RemoveAt(index);
            UIManager.main.inventorySheet.RemoveInventorySlot(index);
            return true;
        }
        return false;
    }

    public bool UseItem(int index)
    {
        ConsumableInventoryItem item = (ConsumableInventoryItem)PlayerCharacterUnit.player.charInventory.Inventory[index];

        if (item.usable)
        {
            item.Use(PlayerCharacterUnit.player);
            if (item.currentUses == 0)
            {
                Inventory.Remove(item);
                UIManager.main.inventorySheet.RemoveInventorySlot(index);
                return true;
            }
            return false;
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public bool UseItem(InventoryItem item)
    {
        if (Inventory.Contains(item))
        {
            var index = Inventory.IndexOf(item);
            ConsumableInventoryItem itemToUse = (ConsumableInventoryItem)PlayerCharacterUnit.player.charInventory.Inventory.Find(x => x == item);
            itemToUse.Use(PlayerCharacterUnit.player);

            if (itemToUse.currentUses <= 0)
            {
                ItemDepleted?.Invoke(this, index);
                Inventory.Remove(item);
                return true;
            }
            else
            {
                ItemUsed?.Invoke(this, index);
                return false;
            }
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public void DropEverything()
    {
        for (int i = Inventory.Count - 1; i > -1; i--)
        {
            TossItem(Inventory[i], i);
            Inventory.RemoveAt(i);
        }
    }

    public bool DropItem(InventoryItem itemToRemove, int index)
    {
        if (RemoveItemAtIndex(index))
        {
            GameObject tempItem = GameObject.Instantiate(Resources.Load("BlankItem"), GameWorldReferenceClass.GetUnitByID(owner).transform.position, Quaternion.identity) as GameObject;

            tempItem.GetComponent<WorldItem>().inventoryItem = itemToRemove;

            return true;
        }
        return false;
    }

    public bool TossItem(InventoryItem itemToRemove, int index)
    {
        if (RemoveItemAtIndex(index))
        {
            RootCharacter unitToDrop = GameWorldReferenceClass.GetUnitByID(owner);
            Vector3 pos = unitToDrop.transform.position;

            if (ResourceManager.AllWorldItems.Count > 0)
            {
                WorldItem itemBeingCreated = ResourceManager.RestoreItem();
                itemBeingCreated.inventoryItem = itemToRemove;
                itemBeingCreated.transform.position = new Vector3(UnityEngine.Random.Range(-.25f, .25f) + pos.x, .25f + pos.y, UnityEngine.Random.Range(-.25f, .25f) + pos.z);
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
                itemBeingCreated.inventoryItem = itemToRemove;
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
        InventoryItem existingItem = Inventory.FirstOrDefault(x => x.itemID == itemToCheck.itemID);

        if (existingItem != null)
            return true;
        return false;
    }

    public bool CheckItem(int itemIDToCheck)
    {
        InventoryItem existingItem = Inventory.FirstOrDefault(x => x.itemID == itemIDToCheck);

        if (existingItem != null)
            return true;
        return false;
    }

    public void UnequipToInventory(InventoryItem itemToAdd)
    {
        Inventory.Add(itemToAdd);
        UIManager.main.inventorySheet.AddInventorySlot(itemToAdd);
    }

    public bool AddItem(InventoryItem itemToAdd, bool suppressNotification)
    {
        InventoryItem existingItem = Inventory.FirstOrDefault(x => x.itemID == itemToAdd.itemID);

        if (existingItem != null && existingItem.unique)
        {
            return false;
        }
        else if (existingItem != null && existingItem.currentStackSize < existingItem.maxStackSize)
        {
            existingItem.currentStackSize = Math.Clamp(existingItem.currentStackSize + itemToAdd.currentStackSize, 0, existingItem.maxStackSize);
            return true;
        }
        else if (existingItem == null || itemToAdd.maxStackSize == 1)
        {
            Inventory.Add(itemToAdd);
            //if (!suppressNotification)
            //    ItemPickedUp?.Invoke(this, itemToAdd);
            //UIManager.main.inventorySheet.AddInventorySlot(itemToAdd);
            //if (itemToAdd.itemID == UIManager.main.quickItemSlot.itemID && UIManager.main.quickItemSlot.empty)
            //    UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)itemToAdd);
            return true;
        }
        return false;
    }

    public bool New_RemoveItem(InventoryItem itemToRemove)
    {
        InventoryItem existingItem = Inventory.FirstOrDefault(x => x.itemID == itemToRemove.itemID);

        if (existingItem != null && existingItem.currentStackSize > itemToRemove.currentStackSize)
        {
            existingItem.currentStackSize -= itemToRemove.currentStackSize;
            return true;
        }
        else if (existingItem != null && existingItem.currentStackSize == itemToRemove.currentStackSize)
        {
            Inventory.Remove(existingItem);
            return true;
        }
        return false;
    }

    public bool AddItem_OLD(InventoryItem itemToAdd)
    {
        if (itemToAdd.maxStackSize > 1)
        {
            amountNotPickedUp = itemToAdd.currentStackSize;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].itemID == itemToAdd.itemID)
                {
                    amountNotPickedUp = (Inventory[i].currentStackSize + itemToAdd.currentStackSize) - Inventory[i].maxStackSize;

                    if (amountNotPickedUp > 0)
                        itemToAdd.currentStackSize = amountNotPickedUp;
                }
            }

            if (amountNotPickedUp > 0 && Inventory.Count < MaxInventory)
            {
                Inventory.Add(itemToAdd);
                
                UIManager.main.inventorySheet.AddInventorySlot(itemToAdd);
                if (itemToAdd.itemID == UIManager.main.quickItemSlot.itemID && UIManager.main.quickItemSlot.empty)
                {
                    UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)itemToAdd);
                }
                return true;
            }
            else
                return true;
        }
        else if (Inventory.Count >= MaxInventory)
            return false;
        else
        {
            if (itemToAdd.itemType != InventoryItem.ItemType.LocusRune)
            {
                Inventory.Add(itemToAdd);
                //if (!suppressNotification)
                    ItemPickedUp?.Invoke(this, itemToAdd);
                UIManager.main.inventorySheet.AddInventorySlot(itemToAdd);
                if (itemToAdd.itemID == UIManager.main.quickItemSlot.itemID && UIManager.main.quickItemSlot.empty)
                    UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)itemToAdd);
                return true;
            }
            else
            {
                PlayerCharacterUnit.player.availableLocusRuneItems.Add((LocusRuneItem)itemToAdd);
                return true;
            }
        }

    }
}