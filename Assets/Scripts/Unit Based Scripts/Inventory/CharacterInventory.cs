using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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
        if (AddItem(itemToBeGrabbed.inventoryItem.Clone()))
            ResourceManager.HideItem(itemToBeGrabbed);
        else
            ErrorScript.DisplayError("No more room");
    }

    public bool ReceiveItem(InventoryItem itemToBeGrabbed)
    {
        if (AddItem(itemToBeGrabbed.Clone()))
            return true;
        else
            return false;
    }

    public bool RemoveItem(int index)
    {
        if (Inventory.Count > (index))
        {
            Inventory.RemoveAt(index);
            UIManager.main.inventorySheet.RemoveInventorySlot(index);
            return true;
        }
        Debug.Log("You do not have that item.");
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
        Debug.Log("You do not have that item.");
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
        if (RemoveItem(index))
        {
            GameObject tempItem = GameObject.Instantiate(Resources.Load("BlankItem"), GameWorldReferenceClass.GetUnitByID(owner).transform.position, Quaternion.identity) as GameObject;

            tempItem.GetComponent<WorldItem>().inventoryItem = itemToRemove;
            
            return true;
        }
        return false;
    }

    public bool TossItem(InventoryItem itemToRemove, int index)
    {
        if (RemoveItem(index))
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
        foreach (InventoryItem invSlot in Inventory)
        {
            if (invSlot.itemID == itemToCheck.itemID)
                return true;
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public void UnequipToInventory(InventoryItem itemToAdd)
    {
        Inventory.Add(itemToAdd);
        UIManager.main.inventorySheet.AddInventorySlot(itemToAdd);
    }

    public bool AddItem(InventoryItem itemToAdd)
    {
        if (itemToAdd.stackable)
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
                ItemPickedUp?.Invoke(this, itemToAdd);
                var newItems = new List<InventoryItem>
                {
                    itemToAdd
                };
                UIManager.main.inventorySheet.AddInventorySlot(newItems);
                for (int i = 0; i < newItems.Count; i++)
                {
                    if (newItems[i].itemID == UIManager.main.quickItemSlot.itemID && UIManager.main.quickItemSlot.empty)
                    {
                        UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)newItems[i]);
                        i = newItems.Count;
                    }
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
            if(itemToAdd.itemType != InventoryItem.ItemType.LocusRune)
            {
                Inventory.Add(itemToAdd);
                ItemPickedUp?.Invoke(this, itemToAdd);
                var newItems = new List<InventoryItem>
            {
                itemToAdd
            };
                UIManager.main.inventorySheet.AddInventorySlot(newItems);
                for (int i = 0; i < newItems.Count; i++)
                {
                    if (newItems[i].itemID == UIManager.main.quickItemSlot.itemID && UIManager.main.quickItemSlot.empty)
                    {
                        UIManager.main.quickItemSlot.SetQuickItem((ConsumableInventoryItem)newItems[i]);
                        i = newItems.Count;
                    }
                }
                return true;
            }
            else
            {
                PlayerCharacterUnit.player.availableLocusRuneItems.Add((LocusRuneItem)itemToAdd);
                return true;
            }
        }

    }

    public bool AddItem(WorldItem itemToAdd)
    {
        if (itemToAdd.inventoryItem.stackable)
        {
            amountNotPickedUp = itemToAdd.inventoryItem.currentStackSize;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].itemID == itemToAdd.inventoryItem.itemID)
                {
                    amountNotPickedUp = (Inventory[i].currentStackSize + itemToAdd.inventoryItem.currentStackSize) - Inventory[i].maxStackSize;

                    if (amountNotPickedUp > 0)
                        itemToAdd.inventoryItem.currentStackSize = amountNotPickedUp;
                }
            }

            if (amountNotPickedUp > 0 && Inventory.Count < MaxInventory)
            {
                Inventory.Add(itemToAdd.inventoryItem);
                return true;
            }
            else
                return true;
        }
        else if (Inventory.Count >= MaxInventory)
            return false;
        else
        {
            if (itemToAdd.inventoryItem.itemType != InventoryItem.ItemType.LocusRune)
            {
                Inventory.Add(itemToAdd.inventoryItem);
                return true;
            }
            else
            {
                PlayerCharacterUnit.player.availableLocusRuneItems.Add((LocusRuneItem)itemToAdd.inventoryItem);
                return true;
            }
        }

    }
}