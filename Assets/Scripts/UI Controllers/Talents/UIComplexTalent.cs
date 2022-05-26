using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIComplexTalent : UITalentBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
    }

    public void Initialize(ComplexTalent complexTalent)
    {
        talentInSlot = complexTalent;
        SetTooltipInfo();
    }

    public void SetTooltipInfo()
    {
        if(tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        ComplexTalent complexTalent = (ComplexTalent)talentInSlot;

        tooltipInfo.headerContent = complexTalent.talentName;
        tooltipInfo.shorthandContent = complexTalent.cost.ToString();
        tooltipInfo.bodyContent = complexTalent.talentDescription;

        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        ComplexTalent complexTalent = (ComplexTalent)talentInSlot;

        if (active)
        {
            GameWorldReferenceClass.GW_Player.complexTalents.Add(complexTalent);
            complexTalent.DeactivateTalent();
            characterTalents.UpdatePoints(complexTalent.cost);
            active = false;
            outline.enabled = false;
        }
        else
        {
            if(complexTalent.cost > GameWorldReferenceClass.GW_Player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                GameWorldReferenceClass.GW_Player.complexTalents.Remove(complexTalent);
                complexTalent.ActivateTalent();
                characterTalents.UpdatePoints(-complexTalent.cost);
                active = true;
                outline.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }
}