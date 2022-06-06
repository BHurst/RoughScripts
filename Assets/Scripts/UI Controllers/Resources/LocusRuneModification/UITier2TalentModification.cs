using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier2TalentModification : UITalentModificationBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterResources = GameObject.Find("CharacterResourceCanvas").GetComponent<CharacterResourcesPane>();
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(Tier2Talent Tier2Talent)
    {
        talentInSlot = Tier2Talent;
        SetTooltipInfo();
        text.SetText("Mult");
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