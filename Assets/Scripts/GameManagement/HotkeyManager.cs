using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.InputSystem.Interactions;

public class HotkeyManager : MonoBehaviour
{
    public PlayerCharacterUnit player;
    PlayerUnitController pUC;
    int pressedSlotNum = -1;
    [HideInInspector]
    public bool slot0StartedCharging = false;
    [HideInInspector]
    public bool slot1StartedCharging = false;
    [HideInInspector]
    public bool slot2StartedCharging = false;
    [HideInInspector]
    public bool slot3StartedCharging = false;
    [HideInInspector]
    public bool slot4StartedCharging = false;
    [HideInInspector]
    public bool slot5StartedCharging = false;
    [HideInInspector]
    public bool slot6StartedCharging = false;
    [HideInInspector]
    public bool slot7StartedCharging = false;
    [HideInInspector]
    public bool slot8StartedCharging = false;
    [HideInInspector]
    public bool slot9StartedCharging = false;

    private void Start()
    {
        player = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        pUC = GetComponent<PlayerUnitController>();
    }

    public void SetSlotNum(int slotNum)
    {
        pressedSlotNum = slotNum;
    }

    public void HotbarSlot(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack && !WorldInteract.conversationActive)
        {
            var slotStartedCharing = typeof(HotkeyManager).GetField(string.Format("slot{0}StartedCharging", pressedSlotNum));
            RootAbility hotbarSlot = (RootAbility)typeof(PlayerHotbarAbilities).GetField(string.Format("hotbarSlot{0}", pressedSlotNum)).GetValue(PlayerCharacterUnit.player.playerHotbar);

            if (!RootAbility.NullorUninitialized(hotbarSlot))
            {
                if (context.started)
                {
                    if ((bool)slotStartedCharing.GetValue(this) && hotbarSlot.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                    {
                        if (!RootAbility.NullorUninitialized(player.abilityPreparingToCast) && hotbarSlot.abilityID.Equals(player.abilityPreparingToCast.abilityID))
                        {
                            slotStartedCharing.SetValue(this, false);
                            player.ChargeCast();
                        }
                    }
                    else
                    {
                        if (player.StartCasting(hotbarSlot) && hotbarSlot.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                            slotStartedCharing.SetValue(this, true);
                    }
                }
            }
        }
        else if (WorldInteract.conversationActive && context.started)
        {
            UIManager.main.conversationSheet.ConvoStep(PlayerCharacterUnit.player, PlayerCharacterUnit.player.talkTarget, pressedSlotNum);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack)
            if (context.started)
                pUC.Jump();
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack)
            if (context.started)
                pUC.Interact();
    }

    public void QuickItem1(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack)
            if (context.started)
            {
                if (PlayerCharacterUnit.player.quickItem != null && PlayerCharacterUnit.player.quickItem.usable)
                    UIManager.main.quickItemSlot.UseQuickItem(PlayerCharacterUnit.player.quickItem);
            }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack)
        {
            pUC.Move(context.ReadValue<Vector2>());

            if (context.started)
                PlayerCharacterUnit.player.movementState = MovementState.Moving;
            else if (context.canceled)
                PlayerCharacterUnit.player.movementState = MovementState.Idle;
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (WorldInteract.canMoveAndAttack)
        {
            if (context.started)
                PlayerCharacterUnit.player.sprintState = SprintState.Sprinting;
            else if (context.canceled)
                PlayerCharacterUnit.player.sprintState = SprintState.Idle;
        }
    }

    public void Inventory(InputAction.CallbackContext context)
    {
        if (context.started)
            if (UIManager.main.inventorySheet.mainPanel.gameObject.activeInHierarchy)
                UIManager.main.CloseInventoryPane();
            else
                UIManager.main.OpenInventoryPane();
    }

    public void Resources(InputAction.CallbackContext context)
    {
        if (context.started)
            if (UIManager.main.resourceSheet.mainPanel.gameObject.activeInHierarchy)
                UIManager.main.CloseResourcePane();
            else
                UIManager.main.OpenResourcePane();
    }

    public void Runes(InputAction.CallbackContext context)
    {
        if (context.started)
            if (UIManager.main.abilityRuneSheet.mainPanel.gameObject.activeInHierarchy)
                UIManager.main.CloseRunePane();
            else
                UIManager.main.OpenRunePane();
    }

    public void Stats(InputAction.CallbackContext context)
    {
        if (context.started)
            if (UIManager.main.characterSheet.mainPanel.gameObject.activeInHierarchy)
                UIManager.main.CloseCharacterStatPane();
            else
                UIManager.main.OpenCharacterStatPane();
    }

    public void Talents(InputAction.CallbackContext context)
    {
        if (context.started)
            if (UIManager.main.talentSheet.mainPanel.gameObject.activeInHierarchy)
                UIManager.main.CloseTalentPane();
            else
                UIManager.main.OpenTalentPane();
    }

    public void ExitMenu(InputAction.CallbackContext context)
    {
        if (context.started)
            UIManager.main.OpenExitMenu();
    }

    public void ModKey(InputAction.CallbackContext context)
    {
        if (context.started)
            UIManager.main.inventorySheet.ShowHiddenText();
        if (context.canceled)
            UIManager.main.inventorySheet.HideHiddenText();
    }
}