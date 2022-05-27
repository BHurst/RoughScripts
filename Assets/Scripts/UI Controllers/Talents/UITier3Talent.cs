using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier3Talent : UITalentBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
    }

    public void Initialize(Tier3Talent Tier3Talent)
    {
        talentInSlot = Tier3Talent;
        SetTooltipInfo();
    }

    public void SetTooltipInfo()
    {
        if(tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        Tier3Talent Tier3Talent = (Tier3Talent)talentInSlot;

        tooltipInfo.headerContent = Tier3Talent.talentName;
        tooltipInfo.shorthandContent = Tier3Talent.cost.ToString();
        tooltipInfo.bodyContent = Tier3Talent.talentDescription;

        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        Tier3Talent Tier3Talent = (Tier3Talent)talentInSlot;

        if (active)
        {
            GameWorldReferenceClass.GW_Player.Tier3Talents.Add(Tier3Talent);
            Tier3Talent.DeactivateTalent();
            characterTalents.UpdatePoints(Tier3Talent.cost);
            active = false;
            outline.enabled = false;
        }
        else
        {
            if(Tier3Talent.cost > GameWorldReferenceClass.GW_Player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                GameWorldReferenceClass.GW_Player.Tier3Talents.Remove(Tier3Talent);
                Tier3Talent.ActivateTalent();
                characterTalents.UpdatePoints(-Tier3Talent.cost);
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