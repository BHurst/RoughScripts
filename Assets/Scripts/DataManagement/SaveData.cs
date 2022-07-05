using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public GameStateFlags gameStateFlags;
    public List<BaseQuest> questProgress;
    public float playerHealth;
}