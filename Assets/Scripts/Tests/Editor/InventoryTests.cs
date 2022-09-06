using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
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
}