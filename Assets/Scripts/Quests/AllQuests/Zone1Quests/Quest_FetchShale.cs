using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quest_FetchShale : BaseQuest
{
    public Quest_FetchShale()
    {
        questName = "Fetch Shale";
        questId = 00001;
        phase = 0;
    }

    public override void AdvancePhase()
    {
        phase++;
    }
}