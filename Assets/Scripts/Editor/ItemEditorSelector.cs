using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldItem))]
public class ItemEditorSelector : Editor
{
    List<string> types = new List<string>();
    SerializedProperty itemListIndex;
    SerializedProperty itemToLoadType;

    private void OnEnable()
    {
        types = new List<string>();
        itemListIndex = serializedObject.FindProperty("itemListIndex");
        itemToLoadType = serializedObject.FindProperty("itemToLoadType");

        DirectoryInfo dir = new DirectoryInfo("Assets/Scripts/Items/Consumables/HealingConsumables");
        FileInfo[] info = dir.GetFiles("*.cs");
        types.Add("None");
        foreach (FileInfo f in info)
            types.Add(f.Name.ToString().Split(".")[0]);
    }

    public override void OnInspectorGUI()
    {
        itemListIndex.intValue = EditorGUILayout.Popup("Item Type", itemListIndex.intValue, types.ToArray());
        itemToLoadType.stringValue = types[itemListIndex.intValue];
        EditorGUILayout.Space();
        // Save all changes made on the Inspector
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}