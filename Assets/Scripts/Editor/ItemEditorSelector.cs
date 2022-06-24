using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldItem))]
public class ItemEditorSelector : Editor
{
    List<string> consumables = new List<string>();
    List<string> equipments = new List<string>();
    List<string> locusRunes = new List<string>();
    public int itemListIndex;
    SerializedProperty itemToLoadType;

    public InventoryItem.ItemType categoryToDisplay;

    private void OnEnable()
    {
        consumables = new List<string>();
        itemListIndex = 0;
        itemToLoadType = serializedObject.FindProperty("itemToLoadType");

        DirectoryInfo healingConsumablesdir = new DirectoryInfo("Assets/Scripts/Items/Consumables/Prefabs");
        FileInfo[] info = healingConsumablesdir.GetFiles("*.cs", SearchOption.AllDirectories);
        consumables.Add("None");
        foreach (FileInfo f in info)
            consumables.Add(f.Name.ToString().Split(".")[0]);

        DirectoryInfo equipmentsdir = new DirectoryInfo("Assets/Scripts/Items/Equipment/Prefabs");
        FileInfo[] healingConsumablesinfo = equipmentsdir.GetFiles("*.cs", SearchOption.AllDirectories);
        equipments.Add("None");
        foreach (FileInfo f in healingConsumablesinfo)
            equipments.Add(f.Name.ToString().Split(".")[0]);

        DirectoryInfo locusRunesdir = new DirectoryInfo("Assets/Scripts/Items/LocusRunes/Prefabs");
        FileInfo[] locusRunesinfo = locusRunesdir.GetFiles("*.cs", SearchOption.AllDirectories);
        locusRunes.Add("None");
        foreach (FileInfo f in locusRunesinfo)
            locusRunes.Add(f.Name.ToString().Split(".")[0]);
    }

    public override void OnInspectorGUI()
    {
        categoryToDisplay = (InventoryItem.ItemType)EditorGUILayout.EnumPopup("Item Category", categoryToDisplay);
        switch (categoryToDisplay)
        {
            case InventoryItem.ItemType.None:
                itemToLoadType.stringValue = "";
                break;
            case InventoryItem.ItemType.Basic:
                break;
            case InventoryItem.ItemType.Consumable:
                {
                    itemListIndex = EditorGUILayout.Popup("Consumables", itemListIndex, consumables.ToArray());
                    itemToLoadType.stringValue = consumables[itemListIndex];
                }
                break;
            case InventoryItem.ItemType.Ammo:
                break;
            case InventoryItem.ItemType.Equipment:
                {
                    itemListIndex = EditorGUILayout.Popup("Equipments", itemListIndex, equipments.ToArray());
                    itemToLoadType.stringValue = equipments[itemListIndex];
                }
                break;
            case InventoryItem.ItemType.LocusRune:
                {
                    itemListIndex = EditorGUILayout.Popup("Locus Runes", itemListIndex, locusRunes.ToArray());
                    itemToLoadType.stringValue = locusRunes[itemListIndex];
                }
                break;
            default:
                itemToLoadType.stringValue = "";
                break;
        }
        


        EditorGUILayout.Space();
        // Save all changes made on the Inspector
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}