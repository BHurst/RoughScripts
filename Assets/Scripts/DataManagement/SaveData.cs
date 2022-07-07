using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public GameStateFlags gameStateFlags;
    public List<BaseQuest> questProgress;
    #region PlayerData
    public CharacterLevel playerLevel;
    public TalentStructure_Serialized talentStructure;
    public List<InventoryItem> playerInventory;
    public List<EquipmentInventoryItem_Serialized> playerEquipmentInventory;
    public List<EquipmentInventoryItem_Serialized> playerEquipment;
    #endregion
}