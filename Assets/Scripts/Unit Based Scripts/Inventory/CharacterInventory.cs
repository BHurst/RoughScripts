using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterInventory
{
    public Guid owner;
    public List<Item> Inventory = new List<Item>();
    public int MaxInventory = 20;
    public int amountNotPickedUp = 0;

    public void PickUp(WorldItem itemToBeGrabbed)
    {
        if (AddItem(ConvertItemToInventory(itemToBeGrabbed)))
            ResourceManager.HideItem(itemToBeGrabbed);
        else
            ErrorScript.DisplayError("No more room");
    }

    public bool ReceiveItem(WorldItem itemToBeGrabbed)
    {
        if (AddItem(ConvertItemToInventory(itemToBeGrabbed)))
            return true;
        else
            return false;
    }

    public bool RemoveItem(Item itemToRemove)
    {
        foreach (Item item in Inventory)
        {
            if (item == itemToRemove)
            {
                Inventory.Remove(item);
                return true;
            }
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public void DropEverything()
    {
        for (int i = Inventory.Count - 1; i > -1; i--)
        {
            TossItem(Inventory[i]);
            Inventory.RemoveAt(i);
        }
    }

    public bool DropItem(Item itemToRemove)
    {
        if (RemoveItem(itemToRemove))
        {
            WorldItem tempItem = new WorldItem();
            tempItem.item = itemToRemove;
            GameObject.Instantiate(tempItem, GameWorldReferenceClass.GetUnitByID(owner).transform.position, new Quaternion());
            return true;
        }
        return false;
    }

    public bool TossItem(Item itemToRemove)
    {
        if (RemoveItem(itemToRemove))
        {
            RootUnit unitToDrop = GameWorldReferenceClass.GetUnitByID(owner);
            Vector3 pos = unitToDrop.transform.position;

            if (ResourceManager.AllWorldItems.Count > 0)
            {
                WorldItem itemBeingCreated = ResourceManager.RestoreItem();
                itemBeingCreated.item = itemToRemove;
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
                itemBeingCreated.item = itemToRemove;
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

    public bool CheckItem(Item itemToCheck)
    {
        foreach (Item invSlot in Inventory)
        {
            if (invSlot.itemID == itemToCheck.itemID)
                return true;
        }
        Debug.Log("You do not have that item.");
        return false;
    }

    public Item ConvertItemToInventory(WorldItem toBeConverted)
    {
        Item itemForInventory;

        itemForInventory = toBeConverted.item;

        return itemForInventory;
    }

    public bool AddItem(Item itemToAdd)
    {
        if (itemToAdd.GetType() is IStackable newItem)
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i].itemID == itemToAdd.itemID)
                {
                    if (Inventory[i].GetType() is IStackable inventoryItem)
                    {
                        amountNotPickedUp = (inventoryItem.currentStackSize + newItem.currentStackSize) - inventoryItem.maxStackSize;

                        if (amountNotPickedUp > 0)
                            newItem.currentStackSize = amountNotPickedUp;
                    }
                }
            }

            if (amountNotPickedUp > 0)
                return false;
            else
                return true;
        }
        else if (Inventory.Count >= MaxInventory)
            return false;
        else
        {
            Inventory.Add(itemToAdd);
            return true;
        }

    }
}