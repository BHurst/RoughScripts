using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier2Talent : UITalentBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(Tier2Talent Tier1Talent)
    {
        talentInSlot = Tier1Talent;
        SetTooltipInfo();
        text.SetText("Mult");
        background.color = new Color(234, 221, 202);
    }

    public void SetTooltipInfo()
    {
        if (tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        Tier2Talent Tier2Talent = (Tier2Talent)talentInSlot;

        tooltipInfo.headerContent = Tier2Talent.talentName;
        tooltipInfo.shorthandContent = Tier2Talent.cost.ToString();
        tooltipInfo.bodyContent = "";
        foreach (var mod in Tier2Talent.modifiers)
            tooltipInfo.bodyContent += mod.ReadableName() + "\n";

        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        Tier2Talent Tier2Talent = (Tier2Talent)talentInSlot;

        if (active)
        {
            PlayerCharacterUnit.player.talents.Tier2Talents.Add(Tier2Talent);
            foreach (var mod in Tier2Talent.modifiers)
                PlayerCharacterUnit.player.totalStats.DecreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
            characterTalents.UpdatePoints(Tier2Talent.cost);
            parentRune.Divest();
            active = false;
            outline.enabled = false;
        }
        else
        {
            if (Tier2Talent.cost > PlayerCharacterUnit.player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                PlayerCharacterUnit.player.talents.Tier2Talents.Remove(Tier2Talent);
                foreach (var mod in Tier2Talent.modifiers)
                    PlayerCharacterUnit.player.totalStats.IncreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
                characterTalents.UpdatePoints(-Tier2Talent.cost);
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