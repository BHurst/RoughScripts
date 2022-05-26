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
    public CharacterTalentsPane talentSheet;
    public QuickItemSlot quickItemSlot;
    public GameObject crosshair;
    public HeldAbility heldAbility;

    private void Start()
    {
        inventorySheet.RigEvents();
    }

    public void OpenExitMenu()
    {
        if (exitMenuSheet.mainPanel.gameObject.activeInHierarchy)
            exitMenuSheet.Hide();
        else if (!characterSheet.mainPanel.activeInHierarchy && !inventorySheet.mainPanel.activeInHierarchy && !abilityRuneSheet.mainPanel.activeInHierarchy && !talentSheet.mainPanel.activeInHierarchy)
            exitMenuSheet.Show();
        else
        {
            characterSheet.Hide();
            abilityRuneSheet.Hide();
            inventorySheet.Hide();
            inventorySheet.CloseContext();
            talentSheet.Hide();
        }

        EmptyHand();
        YieldControl();
    }

    public void OpenInventory()
    {
        characterSheet.Hide();
        abilityRuneSheet.Hide();
        if(inventorySheet.mainPanel.activeInHierarchy)
        {
            inventorySheet.Hide();
        }
        else
        {
            inventorySheet.Show();
        }
        inventorySheet.CloseContext();
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenRunePane()
    {
        inventorySheet.Hide();
        inventorySheet.CloseContext();
        characterSheet.Hide();
        if (abilityRuneSheet.mainPanel.activeInHierarchy)
        {
            abilityRuneSheet.Hide();
        }
        else
        {
            abilityRuneSheet.Show();
        }
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenCharacterSheet()
    {
        inventorySheet.Hide();
        inventorySheet.CloseContext();
        abilityRuneSheet.Hide();
        if (characterSheet.mainPanel.activeInHierarchy)
        {
            characterSheet.Hide();
        }
        else
        {
            characterSheet.Show();
        }
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenTalents()
    {
        inventorySheet.Hide();
        inventorySheet.CloseContext();
        abilityRuneSheet.Hide();
        characterSheet.Hide();
        if (talentSheet.mainPanel.activeInHierarchy)
        {
            talentSheet.Hide();
        }
        else
        {
            talentSheet.Show();
        }

        EmptyHand();
        YieldControl();
    }

    void YieldControl()
    {
        if (!talentSheet.mainPanel.activeInHierarchy && !characterSheet.mainPanel.activeInHierarchy && !inventorySheet.mainPanel.activeInHierarchy && !abilityRuneSheet.mainPanel.activeInHierarchy && !exitMenuSheet.mainPanel.activeInHierarchy)
        {
            WorldInteract.cameraLocked = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            crosshair.SetActive(true);
            UITooltipController.Hide();
        }
        else
        {
            WorldInteract.cameraLocked = true;
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