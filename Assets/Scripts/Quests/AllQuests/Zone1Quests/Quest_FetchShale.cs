using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quest_FetchShale : BaseQuest
{
    public override int questId { get { return 00001; } }
    public Quest_FetchShale()
    {
        questName = "Fetch Shale";
        phase = 0;
    }

    public override void AdvancePhase()
    {
        phase++;

        if(phase == 1)
        {
            PlayerCharacterUnit.player.level.GainExperience(2000);
            GameStateFlags.CurrentState.Quest_GaveShale = true;
            completed = true;
        }
    }
}