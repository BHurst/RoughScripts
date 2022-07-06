using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent_OpenTalkTargetStore : GameEvent
{
    public override void DoEvent()
    {
        UIManager.main.OpenStoreFront(PlayerCharacterUnit.player.talkTarget.storeFrontData);
    }
}