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
        PlayerCharacterUnit.player.totalStats.Health_Current = save.playerHealth;
        GameStateFlags.CurrentState = save.gameStateFlags;
        QuestManager.QuestList = save.questProgress;
    }

    public void SetSaveObject(SaveData save)
    {
        save.playerHealth = PlayerCharacterUnit.player.totalStats.Health_Current;
        save.gameStateFlags = GameStateFlags.CurrentState;
        save.questProgress = QuestManager.QuestList;
    }
}