using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager
{
    private static SaveLoadManager Instance = null;
    private static readonly object padlock = new object();

    public static SaveLoadManager main
    {
        get
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new SaveLoadManager();
                }
                return Instance;
            }
        }
    }

    public void SaveData()
    {
        SaveData save = new SaveData();

        BinaryFormatter bf = new BinaryFormatter();
        SetSaveObject(save);
        FileStream file = File.Create(Application.persistentDataPath + "/save.weeb");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Saved to " + Application.persistentDataPath + "/save.weeb");
    }

    public void LoadData()
    {
        SaveData save = new SaveData();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.weeb", FileMode.Open);
        save = (SaveData)bf.Deserialize(file);
        file.Close();
        SetWorld(save);
        Debug.Log("Loaded from " + Application.persistentDataPath + "/save.weeb");
    }

    public void SetWorld(SaveData save)
    {
        GameStateFlags.CurrentState = save.gameStateFlags;
        QuestManager.QuestList = save.questProgress;
        PlayerCharacterUnit.player.totalStats = save.playerStats;
        PlayerCharacterUnit.player.charInventory.Inventory.Clear();
        UIManager.main.inventorySheet.RemoveAllSlots();

        foreach (var item in save.playerInventory)
        {
            PlayerCharacterUnit.player.charInventory.AddItem(item, true);
        }
        foreach (var item in save.playerEquipmentInventory)
        {
            EquipmentInventoryItem newEII = new EquipmentInventoryItem();
            newEII.FillFromSerialized(item);
            PlayerCharacterUnit.player.charInventory.AddItem(newEII, true);
        }
        PlayerCharacterUnit.player.unitEquipment.RemoveAllEquipment();
        foreach (var item in save.playerEquipment)
        {
            EquipmentInventoryItem newEII = new EquipmentInventoryItem();
            newEII.FillFromSerialized(item);
            PlayerCharacterUnit.player.unitEquipment.AddEquipment(newEII);
        }
    }

    public void SetSaveObject(SaveData save)
    {
        save.gameStateFlags = GameStateFlags.CurrentState;
        save.questProgress = QuestManager.QuestList;
        save.playerStats = PlayerCharacterUnit.player.totalStats;
        save.playerInventory = PlayerCharacterUnit.player.charInventory.Inventory.FindAll(x => x.itemType == InventoryItem.ItemType.Ammo || x.itemType == InventoryItem.ItemType.Basic || x.itemType == InventoryItem.ItemType.Consumable);
        save.playerEquipmentInventory = new List<EquipmentInventoryItem_Serialized>();
        foreach (var item in PlayerCharacterUnit.player.charInventory.Inventory)
        {
            if (item.itemType == InventoryItem.ItemType.Equipment)
            {
                EquipmentInventoryItem_Serialized newEII = new EquipmentInventoryItem_Serialized();
                newEII.FillFromUnserialized((EquipmentInventoryItem)item);
                save.playerEquipmentInventory.Add(newEII);
            }
        }
        save.playerEquipment = new List<EquipmentInventoryItem_Serialized>();
        foreach (var item in PlayerCharacterUnit.player.unitEquipment.AllEquipment)
        {
            if (item.itemInSlot != null)
            {
                EquipmentInventoryItem_Serialized newEII = new EquipmentInventoryItem_Serialized();
                newEII.FillFromUnserialized(item.itemInSlot);
                save.playerEquipment.Add(newEII);
            }
        }
    }
}