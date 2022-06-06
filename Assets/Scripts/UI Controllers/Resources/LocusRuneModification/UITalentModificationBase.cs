using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITalentModificationBase : MonoBehaviour
{
    public UILocusRune parentRune;
    public CharacterResourcesPane characterResources;
    public UITooltipTrigger tooltipInfo;
    public BaseTalent talentInSlot;
    public Image background;
    public TextMeshProUGUI text;
    public Outline outline;
    public bool active;

    public virtual void Select()
    {
        
    }

    public void Deselect()
    {
        outline.enabled = false;
    }
}