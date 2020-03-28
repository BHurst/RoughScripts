using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadUI : MonoBehaviour
{
    public GameObject slPanePub;
    static GameObject slPane;

    void Start()
    {
        slPane = slPanePub;
    }

    public void OpenSavePane()
    {
        slPane.SetActive(true);
        WorldInteract.worldInteractionAllowed = false;
    }

    public void CloseSavePane()
    {
        slPane.SetActive(false);
        WorldInteract.worldInteractionAllowed = true;
    }

    public void Save()
    {
        SaveLoadManager.SaveData();
    }

    public void Load()
    {
        SaveLoadManager.LoadData();
    }
}