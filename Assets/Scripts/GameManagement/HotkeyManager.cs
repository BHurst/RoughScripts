using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class HotkeyManager : MonoBehaviour
{
    PlayerUnitController pUC;

    private void Start()
    {
        pUC = GetComponent<PlayerUnitController>();
    }

    public void OnHotbarSlot1()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow1);
    }

    public void OnHotbarSlot2()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow2);
    }

    public void OnHotbarSlot3()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow3);
    }

    public void OnHotbarSlot4()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow4);
    }

    public void OnHotbarSlot5()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow5);
    }

    public void OnHotbarSlot6()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow6);
    }

    public void OnHotbarSlot7()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow7);
    }

    public void OnHotbarSlot8()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow8);
    }

    public void OnHotbarSlot9()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow9);
    }

    public void OnHotbarSlot0()
    {
        GameWorldReferenceClass.GW_Player.Cast(GameWorldReferenceClass.GW_Player.abilityIKnow10);
    }

    public void OnJump()
    {
        pUC.Jump();
    }

    public void OnInteract()
    {
        pUC.Interact();
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