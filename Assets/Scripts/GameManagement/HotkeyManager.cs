using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Interactions;

public class HotkeyManager : MonoBehaviour
{
    public PlayerCharacterUnit player;
    PlayerUnitController pUC;
    CharacterPanelScripts characterPanelScripts;
    bool slot0StartedCharging = false;
    bool slot1StartedCharging = false;
    bool slot2StartedCharging = false;
    bool slot3StartedCharging = false;
    bool slot4StartedCharging = false;
    bool slot5StartedCharging = false;
    bool slot6StartedCharging = false;
    bool slot7StartedCharging = false;
    bool slot8StartedCharging = false;
    bool slot9StartedCharging = false;

    private void Start()
    {
        player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        pUC = GetComponent<PlayerUnitController>();
        characterPanelScripts = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
    }

    public void HotbarSlot0(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot0))
        {
            if (context.started)
            {
                if (slot0StartedCharging && player.playerHotbar.hotbarSlot0.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot0.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot0StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot0) && player.playerHotbar.hotbarSlot0.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot0StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot1(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot1))
        {
            if (context.started)
            {
                if (slot1StartedCharging && player.playerHotbar.hotbarSlot1.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot1.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot1StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot1) && player.playerHotbar.hotbarSlot1.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot1StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot2(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot2))
        {
            if (context.started)
            {
                if (slot2StartedCharging && player.playerHotbar.hotbarSlot2.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot2.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot2StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot2) && player.playerHotbar.hotbarSlot2.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot2StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot3(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot3))
        {
            if (context.started)
            {
                if (slot3StartedCharging && player.playerHotbar.hotbarSlot3.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot3.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot3StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot3) && player.playerHotbar.hotbarSlot3.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot3StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot4(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot4))
        {
            if (context.started)
            {
                if (slot4StartedCharging && player.playerHotbar.hotbarSlot4.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot4.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot4StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot4) && player.playerHotbar.hotbarSlot4.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot4StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot5(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot5))
        {
            if (context.started)
            {
                if (slot5StartedCharging && player.playerHotbar.hotbarSlot5.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot5.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot5StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot5) && player.playerHotbar.hotbarSlot5.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot5StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot6(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot6))
        {
            if (context.started)
            {
                if (slot6StartedCharging && player.playerHotbar.hotbarSlot6.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot6.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot6StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot6) && player.playerHotbar.hotbarSlot6.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot6StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot7(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot7))
        {
            if (context.started)
            {
                if (slot7StartedCharging && player.playerHotbar.hotbarSlot7.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot7.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot7StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot7) && player.playerHotbar.hotbarSlot7.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot7StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot8(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot8))
        {
            if (context.started)
            {
                if (slot8StartedCharging && player.playerHotbar.hotbarSlot8.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot8.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot8StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot8) && player.playerHotbar.hotbarSlot8.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot8StartedCharging = true;
                }
            }
        }
    }

    public void HotbarSlot9(InputAction.CallbackContext context)
    {
        if (!RootAbility.NullorUninitialized(player.playerHotbar.hotbarSlot9))
        {
            if (context.started)
            {
                if (slot9StartedCharging && player.playerHotbar.hotbarSlot9.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                {
                    if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && player.playerHotbar.hotbarSlot9.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                    {
                        slot9StartedCharging = false;
                        player.ChargeCast();
                    }
                }
                else
                {
                    if (player.StartCasting(player.playerHotbar.hotbarSlot9) && player.playerHotbar.hotbarSlot9.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                        slot9StartedCharging = true;
                }
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
            if (PlayerCharacterUnit.player.quickItem != null && PlayerCharacterUnit.player.quickItem.usable)
                GameWorldReferenceClass.GW_CharacterPanel.quickItemSlot.UseQuickItem(PlayerCharacterUnit.player.quickItem);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        pUC.Move(context.ReadValue<Vector2>());

        if (context.started)
            PlayerCharacterUnit.player.movementState = MovementState.Moving;
        else if (context.canceled)
            PlayerCharacterUnit.player.movementState = MovementState.Idle;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayerCharacterUnit.player.sprintState = SprintState.Sprinting;
        else if (context.canceled)
            PlayerCharacterUnit.player.sprintState = SprintState.Idle;
    }

    public void Inventory(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenInventoryPane();
    }

    public void Resources(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenResourcePane();
    }

    public void Runes(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenRunePane();
    }

    public void Stats(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenCharacterStatPane();
    }

    public void Talents(InputAction.CallbackContext context)
    {
        if (context.started)
            characterPanelScripts.OpenTalentPane();
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