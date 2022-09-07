using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryTests
{
    [Test]
    public void Add_NewItem()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemID = 0;
        item.currentStackSize = 1;
        item.maxStackSize = 2;
        //Act
        inventory.AddItem(item, true);
        //Assert
        Assert.AreEqual(inventory.Inventory[inventory.Inventory.Count - 1].itemName, item.itemName);
    }

    [Test]
    public void Remove_Item()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemID = 0;
        item.currentStackSize = 1;
        item.maxStackSize = 2;
        inventory.Inventory.Add(item);
        //Act
        inventory.New_RemoveItem(item);
        //Assert
        Assert.IsNull(inventory.Inventory.FirstOrDefault(x => x.itemID == 0));
        Assert.AreEqual(inventory.Inventory.Count(), 0);
    }

    [Test]
    public void Increase_ItemStack()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemID = 0;
        item.currentStackSize = 1;
        item.maxStackSize = 2;
        inventory.Inventory.Add(item);
        //Act
        inventory.AddItem(item, true);
        //Assert
        Assert.AreEqual(inventory.Inventory.First(x => x.itemID == 0).currentStackSize, 2);
    }

    [Test]
    public void Decrease_ItemStack()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item1 = new InventoryItem();
        item1.itemID = 0;
        item1.currentStackSize = 2;
        item1.maxStackSize = 2;
        inventory.Inventory.Add(item1);
        InventoryItem item2 = new InventoryItem();
        item2.itemID = 0;
        item2.currentStackSize = 1;
        item2.maxStackSize = 2;
        //Act
        inventory.New_RemoveItem(item2);
        //Assert
        Assert.AreEqual(inventory.Inventory.First(x => x.itemID == 0).currentStackSize, 1);
    }

    [Test]
    public void Remove_EmptyStack()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item = new InventoryItem();
        item.itemID = 0;
        item.currentStackSize = 2;
        item.maxStackSize = 2;
        inventory.Inventory.Add(item);
        //Act
        inventory.New_RemoveItem(item);
        //Assert
        Assert.IsNull(inventory.Inventory.FirstOrDefault(x => x.itemID == 0));
    }

    [Test]
    public void DoNot_Add_FullStack()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item1 = new InventoryItem();
        item1.itemID = 0;
        item1.currentStackSize = 2;
        item1.maxStackSize = 2;
        inventory.Inventory.Add(item1);
        InventoryItem item2 = new InventoryItem();
        item2.itemID = 0;
        item2.currentStackSize = 1;
        item2.maxStackSize = 2;
        //Act
        inventory.AddItem(item2, true);
        //Assert
        Assert.AreEqual(inventory.Inventory.First(x => x.itemID == 0).currentStackSize, 2);
        Assert.AreEqual(inventory.Inventory.Count, 1);
    }

    [Test]
    public void Add_NonStackable()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item1 = new InventoryItem();
        item1.itemID = 0;
        item1.currentStackSize = 1;
        item1.maxStackSize = 1;
        inventory.Inventory.Add(item1);
        InventoryItem item2 = new InventoryItem();
        item2.itemID = 0;
        item2.currentStackSize = 1;
        item2.maxStackSize = 1;
        //Act
        inventory.AddItem(item2, true);
        //Assert
        Assert.AreEqual(inventory.Inventory[0].itemID, 0);
        Assert.AreEqual(inventory.Inventory[0].currentStackSize, 1);
        Assert.AreEqual(inventory.Inventory[1].itemID, 0);
        Assert.AreEqual(inventory.Inventory[1].currentStackSize, 1);
    }

    [Test]
    public void DoNot_Add_UniqueDuplicate()
    {
        //Arrange
        CharacterInventory inventory = new CharacterInventory();
        InventoryItem item1 = new InventoryItem();
        item1.itemID = 0;
        item1.currentStackSize = 1;
        item1.maxStackSize = 1;
        item1.unique = true;
        inventory.Inventory.Add(item1);
        InventoryItem item2 = new InventoryItem();
        item2.itemID = 0;
        item2.currentStackSize = 1;
        item2.maxStackSize = 1;
        item2.unique = true;
        //Act
        inventory.AddItem(item2, true);
        //Assert
        Assert.AreEqual(inventory.Inventory.Count, 1);
    }
}