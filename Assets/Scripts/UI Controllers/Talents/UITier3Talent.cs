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
            PlayerCharacterUnit.player.talents.Tier3Talents.Add(Tier3Talent);
            Tier3Talent.DeactivateTalent();
            characterTalents.UpdatePoints(Tier3Talent.cost);
            parentRune.Divest();
            active = false;
            outline.enabled = false;
        }
        else
        {
            if(Tier3Talent.cost > PlayerCharacterUnit.player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                PlayerCharacterUnit.player.talents.Tier3Talents.Remove(Tier3Talent);
                Tier3Talent.ActivateTalent();
                characterTalents.UpdatePoints(-Tier3Talent.cost);
                parentRune.Invest();
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