using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseQuest
{
    public string questName = "";
    public int questId = 0;
    public int phase = 0;

    public virtual void AdvancePhase()
    {

    }
}