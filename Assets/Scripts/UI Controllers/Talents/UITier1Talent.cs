using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier1Talent : UITalentBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(Tier1Talent Tier1Talent)
    {
        talentInSlot = Tier1Talent;
        SetTooltipInfo();
        if (Tier1Talent.modifier.Method == ModifierGroup.EMethod.Flat)
        text.SetText("+");
        else if (Tier1Talent.modifier.Method == ModifierGroup.EMethod.AddPercent)
            text.SetText("%");
        else if (Tier1Talent.modifier.Method == ModifierGroup.EMethod.MultiplyPercent)
            text.SetText("%");

        background.sprite = Resources.Load<Sprite>("Abilities/Runes/Schools/" + Tier1Talent.modifier.Stat.ToString());
    }

    public void SetTooltipInfo()
    {
        if (tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        Tier1Talent Tier1Talent = (Tier1Talent)talentInSlot;

        tooltipInfo.headerContent = Tier1Talent.talentName;
        tooltipInfo.shorthandContent = Tier1Talent.cost.ToString();
        tooltipInfo.bodyContent = "";
        tooltipInfo.bodyContent += Tier1Talent.modifier.ReadableName();
        
        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        Tier1Talent Tier1Talent = (Tier1Talent)talentInSlot;

        if (active)
        {
            PlayerCharacterUnit.player.Tier1Talents.Add(Tier1Talent);
            PlayerCharacterUnit.player.totalStats.DecreaseStat(Tier1Talent.modifier.Stat, Tier1Talent.modifier.Aspect, Tier1Talent.modifier.Method, Tier1Talent.modifier.Value);
            characterTalents.UpdatePoints(Tier1Talent.cost);
            active = false;
            outline.enabled = false;
        }
        else
        {
            if (Tier1Talent.cost > PlayerCharacterUnit.player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                PlayerCharacterUnit.player.Tier1Talents.Remove(Tier1Talent);
                PlayerCharacterUnit.player.totalStats.IncreaseStat(Tier1Talent.modifier.Stat, Tier1Talent.modifier.Aspect, Tier1Talent.modifier.Method, Tier1Talent.modifier.Value);
                characterTalents.UpdatePoints(-Tier1Talent.cost);
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