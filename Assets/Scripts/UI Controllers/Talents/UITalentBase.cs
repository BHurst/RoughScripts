using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UITalentBase : MonoBehaviour
{
    public CharacterTalentsPane characterTalents;
    public UITooltipTrigger tooltipInfo;
    public BaseTalent talentInSlot;
    public Outline outline;
    public bool active;

    public virtual void Toggle()
    {

    }
}