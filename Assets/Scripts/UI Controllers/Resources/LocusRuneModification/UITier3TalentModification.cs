using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITier3TalentModification : UITalentModificationBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterResources = GameObject.Find("CharacterResourceCanvas").GetComponent<CharacterResourcesPane>();
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(Tier3Talent Tier3Talent)
    {
        talentInSlot = Tier3Talent;
        SetTooltipInfo();
    }

    public void SetTooltipInfo()
    {
        if (tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        Tier3Talent Tier3Talent = (Tier3Talent)talentInSlot;

        tooltipInfo.headerContent = Tier3Talent.talentName;
        tooltipInfo.shorthandContent = Tier3Talent.cost.ToString();
        tooltipInfo.bodyContent = Tier3Talent.talentDescription;

        tooltipInfo.tertiaryContent = "";
    }

    public override void Select()
    {
        characterResources.selectedTalent = this;
        outline.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }
}