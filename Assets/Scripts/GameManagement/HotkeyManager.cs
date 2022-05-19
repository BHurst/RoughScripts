using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Interactions;

public class HotkeyManager : MonoBehaviour
{
    public PlayerCharacterUnit player;
    PlayerUnitController pUC;
    CharacterPanelScripts characterPanelScripts;

    private void Start()
    {
        player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        pUC = GetComponent<PlayerUnitController>();
        characterPanelScripts = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
    }

    public void HotbarSlot0(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot0 != null && player.playerHotbar.hotbarSlot0.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot0.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot0.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot0;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot0);
            }
        }
    }

    public void HotbarSlot1(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot1 != null && player.playerHotbar.hotbarSlot1.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot1.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot1.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot1;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot1);
            }
        }
    }

    public void HotbarSlot2(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot2 != null && player.playerHotbar.hotbarSlot2.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot2.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot2.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot2;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot2);
            }
        }
    }

    public void HotbarSlot3(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot3 != null && player.playerHotbar.hotbarSlot3.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot3.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot3.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot3;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot3);
            }
        }
    }

    public void HotbarSlot4(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot4 != null && player.playerHotbar.hotbarSlot4.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot4.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot4.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot4;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot4);
            }
        }
    }

    public void HotbarSlot5(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot5 != null && player.playerHotbar.hotbarSlot5.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot5.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot5.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot5;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot5);
            }
        }
    }

    public void HotbarSlot6(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot6 != null && player.playerHotbar.hotbarSlot6.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot6.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot6.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot6;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot6);
            }
        }
    }

    public void HotbarSlot7(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot7 != null && player.playerHotbar.hotbarSlot7.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot7.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot7.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot7;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot7);
            }
        }
    }

    public void HotbarSlot8(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot8 != null && player.playerHotbar.hotbarSlot8.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot8.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot8.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot8;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot8);
            }
        }
    }

    public void HotbarSlot9(InputAction.CallbackContext context)
    {
        if (player.playerHotbar.hotbarSlot9 != null && player.playerHotbar.hotbarSlot9.initialized)
        {
            if (context.interaction is HoldInteraction)
            {
                if (context.performed)
                {
                    if (player.unitAbilityCharges.CheckCharge(player.playerHotbar.hotbarSlot9.aSchoolRune.schoolRuneType) < player.unitAbilityCharges.CheckMaxCharge(player.playerHotbar.hotbarSlot9.aSchoolRune.schoolRuneType))
                        player.abilityCharging = player.playerHotbar.hotbarSlot9;
                }
            }
            else if (context.interaction is PressInteraction)
            {
                if (context.performed)
                    player.StartCasting(player.playerHotbar.hotbarSlot9);
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
            pUC.Jump();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started)
            pUC.Interact();
    }

    public void QuickItem1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (GameWorldReferenceClass.GW_Player.quickItem != null && GameWorldReferenceClass.GW_Player.quickItem.usable)
                GameWorldReferenceClass.GW_CharacterPanel.quickItemSlot.UseQuickItem(GameWorldReferenceClass.GW_Player.quickItem);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        pUC.Move(context.ReadValue<Vector2>());

        if (context.started)
            GameWorldReferenceClass.GW_Player.movementState = MovementState.Moving;
        else if (context.canceled)
            GameWorldReferenceClass.GW_Player.movementState = MovementState.Idle;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.sprintState = SprintState.Sprinting;
        else if (context.canceled)
            GameWorldReferenceClass.GW_Player.sprintState = SprintState.Idle;
    }

    public void Inventory(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenInventory();
    }

    public void Runes(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenRunePane();
    }

    public void Stats(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenCharacterSheet();
    }

    public void ExitMenu(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenExitMenu();
    }

    public void ModKey(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.inventorySheet.ShowHiddenText();
        if (context.canceled)
            characterPanelScripts.inventorySheet.HideHiddenText();
    }
}