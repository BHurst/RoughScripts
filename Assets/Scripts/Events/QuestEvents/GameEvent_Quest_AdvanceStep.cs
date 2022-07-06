using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent_Quest_AdvanceStep : GameEvent
{
    public int questId = 0;

    public override void DoEvent()
    {
        QuestManager.GetQuestByID(questId).AdvancePhase();
    }
}