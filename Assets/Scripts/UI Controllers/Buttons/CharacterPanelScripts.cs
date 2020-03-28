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

    public static void CreateDamageText(int text, GameWorldReferenceClass.HitType hitType, Vector3 location)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text.ToString();

        if (hitType == GameWorldReferenceClass.HitType.Hit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, .92f, .016f, 1); //Yellow
        }
        else if (hitType == GameWorldReferenceClass.HitType.Crit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, .72f, .016f, 1); //Yellow-Orange
        }

        newDamageText.transform.position = location + new Vector3(0, 1, 0);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Damage);
    }

    public static void CreateHealText(int text, GameWorldReferenceClass.HitType hitType, Vector3 location)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text.ToString();

        if (hitType == GameWorldReferenceClass.HitType.Hit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 1f, 1); //Blue
        }
        else if (hitType == GameWorldReferenceClass.HitType.Crit)
        {
            newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(.1f, .1f, 1f, 1); //Light Blue
        }

        newDamageText.transform.position = location + new Vector3(0, 1, 0);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Heal);
    }

    public static void CreatePopupText(string text, Vector3 location)
    {
        GameObject newDamageText = ResourceManager.RestoreDamageText();
        newDamageText.GetComponent<TextMeshProUGUI>().text = text;
        newDamageText.GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 1); //White
        newDamageText.transform.position = location + new Vector3(0, 20, -20);
        newDamageText.GetComponent<FloatingDamage>().DetermineType(FloatingDamage.FloatingTextType.Buff);
    }
}

//REORGANIZE ALL UI COMPONENTS
//This should be turned into a canvas manager
//Each canvas should control all elements inside rather than have some kind of mixed control in here or the Conversation manager