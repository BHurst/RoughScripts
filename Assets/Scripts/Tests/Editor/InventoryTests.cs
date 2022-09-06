using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryTests
{
    [Test]
    public void AddNewItemToCharacterInventory()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemName = "New Item";
        //Act
        inventory.New_AddItem(item);
        //Assert
        Assert.AreEqual(inventory.Inventory[inventory.Inventory.Count - 1].itemName, item.itemName);
    }

    [Test]
    public void RemoveItemFromCharacterInventory()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemName = "New Item";
        inventory.Inventory.Add(item);
        //Act
        inventory.New_RemoveItem(item);
        //Assert
        Assert.IsNull(inventory.Inventory.FirstOrDefault(x => x.itemName == "New Item"));
        Assert.AreEqual(inventory.Inventory.Count(), 0);
    }

    [Test]
    public void IncreaseStackSizeOfInventoryItem()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemName = "New Item";
        item.currentStackSize = 1;
        item.maxStackSize = 2;
        inventory.Inventory.Add(item);
        //Act
        inventory.New_AddItem(item);
        //Assert
        Assert.AreEqual(inventory.Inventory.First(x => x.itemName == "New Item").currentStackSize, 2);
    }

    [Test]
    public void DecreaseStackSizeOfInventoryItem()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item1 = new InventoryItem();
        item1.itemName = "New Item";
        item1.currentStackSize = 2;
        item1.maxStackSize = 2;
        inventory.Inventory.Add(item1);
        InventoryItem item2 = new InventoryItem();
        item2.itemName = "New Item";
        item2.currentStackSize = 1;
        item2.maxStackSize = 2;
        //Act
        inventory.New_RemoveItem(item2);
        //Assert
        Assert.AreEqual(inventory.Inventory.First(x => x.itemName == "New Item").currentStackSize, 1);
    }

    [Test]
    public void RemoveItemIfStackSizeReachesZero()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemName = "New Item";
        item.currentStackSize = 2;
        item.maxStackSize = 2;
        inventory.Inventory.Add(item);
        //Act
        inventory.New_RemoveItem(item);
        //Assert
        Assert.IsNull(inventory.Inventory.FirstOrDefault(x => x.itemName == "New Item"));
    }
}