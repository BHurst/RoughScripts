using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;

public class WorldInteract : MonoBehaviour
{
    public static Vector3 location;
    public static PlayerCharacterUnit activeChar;
    public static bool pause = false;
    public static bool worldInteractionAllowed = true;
    public static bool menuOpen = false;
    public static bool cameraLocked = false;
    public static RootCharacter currentConversationNPC;

    public enum InteractState
    {
        Move,
        Attack,
        Talk,
        Cast
    }

    //Clears the PlayerCharacter's targets
    public static void ClearPlayerPreferences(bool goingToCast)
    {
        //if (activeChar.isAlive == true)
        //{
        //    if (activeChar.abilityBeingCast != null && activeChar.abilityBeingCast.stats.abilityTags.Contains(SpellStats.AbilityTag.CastTime))
        //        activeChar.abilityBeingCast = null;
        //}
    }

    public void CameraLock()
    {
        cameraLocked = !cameraLocked;
    }
}