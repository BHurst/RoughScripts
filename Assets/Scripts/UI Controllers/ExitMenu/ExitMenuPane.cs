using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExitMenuPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Button SaveButton;
    public Button LoadButton;
    public Button CloseButton;

    public void Show()
    {
        mainPanel.SetActive(true);
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
    }

    public void SaveGame()
    {
        SaveLoadManager.SaveData();
    }

    public void LoadGame()
    {
        SaveLoadManager.LoadData();
    }
}