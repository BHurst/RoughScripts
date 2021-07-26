using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class HotkeyManager : MonoBehaviour
{
    PlayerUnitController pUC;
    CharacterPanelScripts characterPanelScripts;

    private void Start()
    {
        pUC = GetComponent<PlayerUnitController>();
        characterPanelScripts = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
    }

    public void HotbarSlot1(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot0").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot2(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot1").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot3(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot2").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot4(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot3").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot5(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot4").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot6(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot5").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot7(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot6").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot8(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot7").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot9(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot8").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
    }

    public void HotbarSlot0(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.StartCasting(GameObject.Find("HotbarSlot9").GetComponent<SingleAbilitySlotScript>().abilityInSlot);
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
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.movementState = MovementState.Sprinting;
        else if (context.canceled)
            GameWorldReferenceClass.GW_Player.movementState = MovementState.Idle;
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
}