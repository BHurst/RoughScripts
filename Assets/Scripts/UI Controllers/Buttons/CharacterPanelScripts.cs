using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CharacterPanelScripts : MonoBehaviour
{
    public GameObject charSheet;
    public CharacterInventoryPane inventorySheet;
    public AbilityRunePane abilityRunePane;
    public GameObject journalSheet;
    public QuickItemSlot quickItemSlot;
    public GameObject crosshair;

    private void Start()
    {
        inventorySheet.RigEvents();
    }

    public void OpenInventory()
    {
        inventorySheet.gameObject.SetActive(!inventorySheet.gameObject.activeInHierarchy);
        inventorySheet.CloseContext();
        //charSheet.SetActive(false);
        //journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenRunePane()
    {
        abilityRunePane.gameObject.SetActive(!abilityRunePane.gameObject.activeInHierarchy);
        inventorySheet.gameObject.SetActive(false);
        inventorySheet.CloseContext();
        //charSheet.SetActive(false);
        //journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenCharacterSheet()
    {
        inventorySheet.gameObject.SetActive(false);
        charSheet.SetActive(!charSheet.activeInHierarchy);
        journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenJournal()
    {
        inventorySheet.gameObject.SetActive(false);
        charSheet.SetActive(false);
        journalSheet.SetActive(!journalSheet.activeInHierarchy);
        YieldControl();
    }

    void YieldControl()
    {
        if (/*!journalSheet.activeInHierarchy && !charSheet.activeInHierarchy && */!inventorySheet.gameObject.activeInHierarchy && !abilityRunePane.gameObject.activeInHierarchy)
        {
            WorldInteract.cameraLocked = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            crosshair.SetActive(true);
        }
        else
        {
            WorldInteract.cameraLocked = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            crosshair.SetActive(false);
        }
    }
}

//REORGANIZE ALL UI COMPONENTS
//This should be turned into a canvas manager
//Each canvas should control all elements inside rather than have some kind of mixed control in here or the Conversation manager