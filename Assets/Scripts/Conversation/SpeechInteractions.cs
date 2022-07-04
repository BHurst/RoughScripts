using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechInteractions
{
    public enum Interaction
    {
        None,
        GiveExperience,
        KillPlayer,
        OpenStore
    }

    public static void Interact(Interaction interaction)
    {
        switch (interaction)
        {
            case Interaction.None:
                break;
            case Interaction.GiveExperience:
                PlayerCharacterUnit.player.level.GainExperience(2000);
                break;
            case Interaction.KillPlayer:
                PlayerCharacterUnit.player.PlayerKill();
                break;
            case Interaction.OpenStore:
                UIManager.main.OpenStoreFront(PlayerCharacterUnit.player.talkTarget.storeFrontData);
                break;
            default:
                break;
        }
    }
}