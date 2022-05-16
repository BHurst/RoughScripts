using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CharacterPanelScripts : MonoBehaviour
{
    public ExitMenuPane exitMenuSheet;
    public CharacterStatPane characterSheet;
    public CharacterInventoryPane inventorySheet;
    public AbilityRunePane abilityRuneSheet;
    public GameObject journalSheet;
    public QuickItemSlot quickItemSlot;
    public GameObject crosshair;
    public HeldAbility heldAbility;

    private void Start()
    {
        inventorySheet.RigEvents();
    }

    public void OpenExitMenu()
    {
        if(exitMenuSheet.gameObject.activeInHierarchy)
            exitMenuSheet.gameObject.SetActive(false);
        else if (!characterSheet.gameObject.activeInHierarchy && !inventorySheet.gameObject.activeInHierarchy && !abilityRuneSheet.gameObject.activeInHierarchy)
            exitMenuSheet.gameObject.SetActive(true);
        else
        {
            characterSheet.gameObject.SetActive(false);
            abilityRuneSheet.gameObject.SetActive(false);
            inventorySheet.gameObject.SetActive(false);
            inventorySheet.CloseContext();
            //journalSheet.SetActive(false);
        }
        YieldControl();
    }

    public void OpenInventory()
    {
        characterSheet.gameObject.SetActive(false);
        abilityRuneSheet.gameObject.SetActive(false);
        inventorySheet.gameObject.SetActive(!inventorySheet.gameObject.activeInHierarchy);
        inventorySheet.CloseContext();
        //journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenRunePane()
    {
        inventorySheet.gameObject.SetActive(false);
        inventorySheet.CloseContext();
        characterSheet.gameObject.SetActive(false);
        abilityRuneSheet.gameObject.SetActive(!abilityRuneSheet.gameObject.activeInHierarchy);
        //journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenCharacterSheet()
    {
        inventorySheet.gameObject.SetActive(false);
        inventorySheet.CloseContext();
        abilityRuneSheet.gameObject.SetActive(false);
        characterSheet.gameObject.SetActive(!characterSheet.gameObject.activeInHierarchy);
        //journalSheet.SetActive(false);
        YieldControl();
    }

    public void OpenJournal()
    {
        
        YieldControl();
    }

    void YieldControl()
    {
        if (/*!journalSheet.activeInHierarchy && */!characterSheet.gameObject.activeInHierarchy && !inventorySheet.gameObject.activeInHierarchy && !abilityRuneSheet.gameObject.activeInHierarchy && !exitMenuSheet.gameObject.activeInHierarchy)
        {
            WorldInteract.cameraLocked = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            crosshair.SetActive(true);
            TooltipController.Hide();
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