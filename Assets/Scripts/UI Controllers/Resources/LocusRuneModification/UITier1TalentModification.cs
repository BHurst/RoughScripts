using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier1TalentModification : UITalentModificationBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterResources = GameObject.Find("CharacterResourceCanvas").GetComponent<CharacterResourcesPane>();
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

    public override void Select()
    {
        outline.enabled = true;
        characterResources.SetSelectedTalent(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }
}