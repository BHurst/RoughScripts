using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadManager {
   
    public static void SaveData()
    {
        Data save = new Data();

        BinaryFormatter bf = new BinaryFormatter();
        SetSaveObject(save);
        FileStream file = File.Create(Application.persistentDataPath + "/save.weeb");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Saved to " + Application.persistentDataPath + "/save.weeb");
    }

    public static void LoadData()
    {
        Data save = new Data();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.weeb", FileMode.Open);
        save = (Data)bf.Deserialize(file);
        file.Close();
        SetWorld(save);
        Debug.Log("Loaded from " + Application.persistentDataPath + "/save.weeb");
    }

    public static void SetWorld(Data save)
    {
        GameObject.Find("Player").GetComponent<PlayerCharacterUnit>().totalStats.Health_Current.value = save.playerHealth;
    }

    public static void SetSaveObject(Data save)
    {
        save.playerHealth = GameObject.Find("Player").GetComponent<PlayerCharacterUnit>().totalStats.Health_Current.value;
    }
}