using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitMenuPane : MonoBehaviour
{
    public Button SaveButton;
    public Button LoadButton;
    public Button CloseButton;

    public void SaveGame()
    {
        SaveLoadManager.SaveData();
    }

    public void LoadGame()
    {
        SaveLoadManager.LoadData();
    }
}