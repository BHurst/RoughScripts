using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UITalentBase : MonoBehaviour
{
    public UITalentBranchNode parentBranchRune;
    public UITrunkNode parentTrunkRune;
    public CharacterTalentsPane characterTalents;
    public UITooltipTrigger tooltipInfo;
    public BaseTalent talentInSlot;
    public Image background;
    public TextMeshProUGUI text;
    public Outline outline;
    public bool active;
    public int index;

    public virtual void Toggle()
    {

    }
}