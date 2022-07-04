using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager main;
    public ExitMenuPane exitMenuSheet;
    public CharacterStatPane characterSheet;
    public CharacterInventoryPane inventorySheet;
    public CharacterResourcesPane resourceSheet;
    public AbilityRunePane abilityRuneSheet;
    public CharacterTalentsPane talentSheet;
    public StoreFrontPane storeSheet;
    public ConversationPane conversationSheet;
    public List<GameObject> mainPanels;
    public QuickItemSlot quickItemSlot;
    public GameObject crosshair;
    public HeldAbility heldAbility;
    public ContextMenu contextMenu;

    bool aPaneWasOpen = false;

    private void Start()
    {
        main = this;
        inventorySheet.RigEvents();
        mainPanels = new List<GameObject>();
        mainPanels.Add(characterSheet.transform.GetChild(0).gameObject);
        mainPanels.Add(inventorySheet.transform.GetChild(0).gameObject);
        mainPanels.Add(resourceSheet.transform.GetChild(0).gameObject);
        mainPanels.Add(abilityRuneSheet.transform.GetChild(0).gameObject);
        mainPanels.Add(talentSheet.transform.GetChild(0).gameObject);
        mainPanels.Add(storeSheet.transform.GetChild(0).gameObject);
        mainPanels.Add(conversationSheet.transform.GetChild(0).gameObject);
    }

    public void OpenExitMenu()
    {
        foreach (GameObject panel in mainPanels)
        {
            if (panel.activeInHierarchy)
                aPaneWasOpen = true;
        }

        if (exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            AllowControl(true);
            exitMenuSheet.Hide();
        }
        else if (aPaneWasOpen)
        {
            AllowControl(true);
            characterSheet.Hide();
            inventorySheet.Hide();
            resourceSheet.Hide();
            abilityRuneSheet.Hide();
            talentSheet.Hide();
            storeSheet.Hide();
        }
        else
        {
            AllowControl(false);
            exitMenuSheet.Show();
        }

        EmptyHand();
        aPaneWasOpen = false;
    }

    public void OpenCharacterStatPane()
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            AllowControl(false);
            characterSheet.Show();

            inventorySheet.Hide();
            resourceSheet.Hide();
            abilityRuneSheet.Hide();
            talentSheet.Hide();
            storeSheet.Hide();

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseCharacterStatPane();
    }

    public void CloseCharacterStatPane()
    {
        AllowControl(true);
        characterSheet.Hide();
    }

    public void OpenInventoryPane()
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            characterSheet.Hide();

            AllowControl(false);
            inventorySheet.Show();

            resourceSheet.Hide();
            abilityRuneSheet.Hide();
            talentSheet.Hide();
            storeSheet.Hide();

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseInventoryPane();
    }

    public void CloseInventoryPane()
    {
        AllowControl(true);
        inventorySheet.Hide();
    }

    public void OpenResourcePane()
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            characterSheet.Hide();
            inventorySheet.Hide();

            AllowControl(false);
            resourceSheet.Show();

            abilityRuneSheet.Hide();
            talentSheet.Hide();
            storeSheet.Hide();

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseResourcePane();
    }

    public void CloseResourcePane()
    {
        AllowControl(true);
        resourceSheet.Hide();
    }

    public void OpenRunePane()
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            characterSheet.Hide();
            inventorySheet.Hide();
            resourceSheet.Hide();

            AllowControl(false);
            abilityRuneSheet.Show();

            talentSheet.Hide();
            storeSheet.Hide();

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseRunePane();
    }

    public void CloseRunePane()
    {
        AllowControl(true);
        abilityRuneSheet.Hide();
    }

    public void OpenTalentPane()
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            characterSheet.Hide();
            inventorySheet.Hide();
            resourceSheet.Hide();
            abilityRuneSheet.Hide();

            AllowControl(false);
            talentSheet.Show();

            storeSheet.Hide();

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseTalentPane();
    }

    public void CloseTalentPane()
    {
        AllowControl(true);
        talentSheet.Hide();
    }

    public void OpenStoreFront(StoreFrontData storeFrontData)
    {
        if (!exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
        {
            characterSheet.Hide();
            inventorySheet.Hide();
            resourceSheet.Hide();
            abilityRuneSheet.Hide();
            talentSheet.Hide();

            AllowControl(false);
            storeSheet.Show(storeFrontData);

            EmptyHand();
            aPaneWasOpen = false;
        }
        else
            CloseStoreFront();
    }

    public void CloseStoreFront()
    {
        AllowControl(true);
        storeSheet.Hide();
    }

    public void OpenConversation(RootCharacter rootCharacter)
    {
        conversationSheet.Show(rootCharacter);
    }

    public void CloseConversation()
    {
        AllowControl(true);
        conversationSheet.Hide();
    }

    void AllowControl(bool control)
    {
        if (control)
        {
            WorldInteract.cameraLocked = false;
            WorldInteract.canMoveAndAttack = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            crosshair.SetActive(true);
            UITooltipController.Hide();
        }
        else
        {
            WorldInteract.cameraLocked = true;
            WorldInteract.canMoveAndAttack = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            crosshair.SetActive(false);
        }
    }

    void EmptyHand()
    {
        heldAbility.ability = null;
        heldAbility.ClearImage();
    }
}