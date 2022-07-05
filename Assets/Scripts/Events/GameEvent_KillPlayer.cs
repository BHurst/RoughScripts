using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent_KillPlayer : GameEvent
{
    public override void DoEvent()
    {
        PlayerCharacterUnit.player.PlayerKill();
    }
}