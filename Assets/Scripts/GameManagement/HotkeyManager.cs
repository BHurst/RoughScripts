using UnityEngine;
using System.Collections;

public class HotkeyManager : MonoBehaviour
{
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
         KeyCode.Alpha0,
    };

    void Update()
    {
        if (Input.anyKeyDown)
        {
            HotKeyCheck();
            WorldInteraction();
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    WorldInteract.pause = !WorldInteract.pause;
            //    if (WorldInteract.pause)
            //    {
            //        Time.timeScale = 0;
            //    }
            //    else
            //    {
            //        Time.timeScale = 1;
            //    }
            //}
        }

        if (Input.anyKey)
        {
            CameraMovement();
        }
    }

    void WorldInteraction()
    {
        if (WorldInteract.menuOpen == false)
        {
            if (Input.GetAxis("Cancel") == 1)
            {
                GameWorldReferenceClass.GW_Player.StopCast();
            }

            if (Input.GetAxis("Hotbar Slot 1") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[0].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 2") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[1].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 3") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[2].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 4") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[3].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 5") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[4].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 6") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[5].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 7") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[6].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 8") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[7].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 9") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[8].abilityInSlotId)));
            }
            else if (Input.GetAxis("Hotbar Slot 10") == 1)
            {
                GameWorldReferenceClass.GW_Player.CastCheck((GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, GameWorldReferenceClass.GW_Player.hotbarAbilities[9].abilityInSlotId)));
            }
        }
        else if (WorldInteract.menuOpen == true)
        {
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    ConversationManager.ConvoStep(GameWorldReferenceClass.GW_Player, WorldInteract.currentConversationNPC, i);
                }
            }
        }
    }

    void HotKeyCheck()
    {
        if (Input.GetAxis("Inventory") > 0)
        {
            CharacterPanelScripts.WindowManager("CharacterInventory");
        }

        if (Input.GetAxis("CharacterSheet") > 0)
        {
            CharacterPanelScripts.WindowManager("CharacterSheet");
        }

        if (Input.GetAxis("Journal") > 0)
        {
            CharacterPanelScripts.WindowManager("PlayerJournal");
        }

        if (Input.GetAxis("Debug Button") > 0)
        {
            GameObject.Find("NPCFriend").GetComponent<NPCUnit>().GetSpeech();
        }
    }

    void CameraMovement()
    {
        
    }
}