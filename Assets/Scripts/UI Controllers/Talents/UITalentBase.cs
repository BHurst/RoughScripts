using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UITalentBase : MonoBehaviour
{
    public UILocusRune parentRune;
    public CharacterTalentsPane characterTalents;
    public UITooltipTrigger tooltipInfo;
    public BaseTalent talentInSlot;
    public Image background;
    public TextMeshProUGUI text;
    public Outline outline;
    public bool active;

    public virtual void Toggle()
    {

    }
}