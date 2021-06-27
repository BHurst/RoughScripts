﻿using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class HotkeyManager : MonoBehaviour
{
    PlayerUnitController pUC;

    private void Start()
    {
        pUC = GetComponent<PlayerUnitController>();
    }

    public void HotbarSlot1(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow1;
    }

    public void HotbarSlot2(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow2;
    }

    public void HotbarSlot3(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow3;
    }

    public void HotbarSlot4(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow4;
    }

    public void HotbarSlot5(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow5;
    }

    public void HotbarSlot6(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow6;
    }

    public void HotbarSlot7(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow7;
    }

    public void HotbarSlot8(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow8;
    }

    public void HotbarSlot9(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow9;
    }

    public void HotbarSlot0(InputAction.CallbackContext context)
    {
        if (context.started)
            GameWorldReferenceClass.GW_Player.currentAbilityToUse = GameWorldReferenceClass.GW_Player.abilityIKnow10;
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

    public void Move(InputAction.CallbackContext context)
    {
        pUC.Move(context.ReadValue<Vector2>());
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.started)
            GameWorldReferenceClass.GW_Player.movementState = RootUnit.MovementState.Sprinting;
        else if(context.canceled)
            GameWorldReferenceClass.GW_Player.movementState = RootUnit.MovementState.Idle;
    }

    //void HotKeyCheck()
    //{
    //    if (Input.GetAxis("Inventory") > 0)
    //    {
    //        CharacterPanelScripts.WindowManager("CharacterInventory");
    //    }

    //    if (Input.GetAxis("CharacterSheet") > 0)
    //    {
    //        CharacterPanelScripts.WindowManager("CharacterSheet");
    //    }

    //    if (Input.GetAxis("Journal") > 0)
    //    {
    //        CharacterPanelScripts.WindowManager("PlayerJournal");
    //    }

    //    if (Input.GetAxis("Debug Button") > 0)
    //    {
    //        GameObject.Find("NPCFriend").GetComponent<NPCUnit>().GetSpeech();
    //    }
    //}
}