using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CharacterPanelScripts : MonoBehaviour
{

    public static GameObject charSheet;
    public static GameObject inventorySheet;
    public static GameObject journalSheet;
    static List<GameObject> sheetList = new List<GameObject>();

    //public static char1HealthBar

    // Use this for initialization
    void Start()
    {
        charSheet = GameObject.Find("UserInterface/CharacterSheetCanvas/CharacterSheet");
        sheetList.Add(charSheet);
        inventorySheet = GameObject.Find("UserInterface/CharacterInventoryCanvas/CharacterInventory");
        sheetList.Add(inventorySheet);
        journalSheet = GameObject.Find("UserInterface/PlayerJournalCanvas/PlayerJournal");
        sheetList.Add(journalSheet);
    }

    public void ThisCallsInventory()
    {
        WindowManager("CharacterInventory");
    }

    public void ThisCallsInfoSheet()
    {
        WindowManager("CharacterSheet");
    }

    public void ThisCallsJournal()
    {
        WindowManager("PlayerJournal");
    }

    //Opens the windows that corresponds with the button that was pressed.
    static void SwitchMethod(string passBtn)
    {
        switch (passBtn)
        {
            case "CharacterSheet":
                charSheet.SetActive(true);
                WorldInteract.worldInteractionAllowed = false;
                break;
            case "CharacterInventory":
                inventorySheet.SetActive(true);
                WorldInteract.worldInteractionAllowed = false;
                break;
            case "PlayerJournal":
                journalSheet.SetActive(true);
                WorldInteract.worldInteractionAllowed = false;
                break;
            default:
                break;
        }
    }

    //Assures that there is no more than one window open at a time.
    public static void WindowManager(string buttonPressed)
    {
        if (WorldInteract.worldInteractionAllowed == true)
        {
            SwitchMethod(buttonPressed);
        }
        else if (WorldInteract.worldInteractionAllowed == false)
        {
            GameObject temp = sheetList.Find(x => x.activeSelf == true);
            if (temp.name == buttonPressed)
            {
                charSheet.SetActive(false);
                inventorySheet.SetActive(false);
                journalSheet.SetActive(false);

                WorldInteract.worldInteractionAllowed = true;
            }
            else
            {
                charSheet.SetActive(false);
                inventorySheet.SetActive(false);
                journalSheet.SetActive(false);

                SwitchMethod(buttonPressed);
            }
        }
    }
}

//REORGANIZE ALL UI COMPONENTS
//This should be turned into a canvas manager
//Each canvas should control all elements inside rather than have some kind of mixed control in here or the Conversation manager