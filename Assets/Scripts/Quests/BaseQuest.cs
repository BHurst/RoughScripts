using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseQuest
{
    public string questName = "";
    public virtual int questId { get { return 0; } }// TODO: find way to get a quest id without needing an instance first.
    public int phase = 0;
    public bool completed = false;
    public bool repeatable = false;

    public virtual void AdvancePhase()
    {

    }
}