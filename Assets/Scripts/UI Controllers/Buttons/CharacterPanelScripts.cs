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
    public CharacterResourcesPane resourceSheet;
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
            inventorySheet.Hide();
            resourceSheet.Hide();
            abilityRuneSheet.Hide();
            talentSheet.Hide();
        }

        EmptyHand();
        YieldControl();
    }

    public void OpenCharacterStatPane()
    {
        if (characterSheet.mainPanel.activeInHierarchy)
        {
            characterSheet.Hide();
        }
        else
        {
            characterSheet.Show();
        }
        inventorySheet.Hide();
        resourceSheet.Hide();
        abilityRuneSheet.Hide();
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenInventoryPane()
    {
        characterSheet.Hide();
        if(inventorySheet.mainPanel.activeInHierarchy)
        {
            inventorySheet.Hide();
        }
        else
        {
            inventorySheet.Show();
        }
        resourceSheet.Hide();
        abilityRuneSheet.Hide();
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenResourcePane()
    {
        characterSheet.Hide();
        inventorySheet.Hide();
        if (resourceSheet.mainPanel.activeInHierarchy)
        {
            resourceSheet.Hide();
        }
        else
        {
            resourceSheet.Show();
        }
        abilityRuneSheet.Hide();
        talentSheet.Hide();

        EmptyHand();
        YieldControl();
    }

    public void OpenRunePane()
    {
        characterSheet.Hide();
        inventorySheet.Hide();
        resourceSheet.Hide();
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

    public void OpenTalentPane()
    {
        characterSheet.Hide();
        inventorySheet.Hide();
        resourceSheet.Hide();
        abilityRuneSheet.Hide();
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
        if (!characterSheet.mainPanel.activeInHierarchy && !inventorySheet.mainPanel.activeInHierarchy && !resourceSheet.mainPanel.activeInHierarchy && !abilityRuneSheet.mainPanel.activeInHierarchy && !talentSheet.mainPanel.activeInHierarchy && !exitMenuSheet.mainPanel.activeInHierarchy)
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