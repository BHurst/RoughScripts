using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent_Quest_GiveShale : GameEvent
{
    public override void DoEvent()
    {
        PlayerCharacterUnit.player.level.GainExperience(2000);
        GameStateFlags.CurrentState.Quest_GaveShale = true;
    }
}