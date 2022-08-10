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
        parentBranchRune = transform.GetComponentInParent<UITalentBranchNode>();
        parentTrunkRune = transform.GetComponentInParent<UITrunkNode>();
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
        tooltipInfo.shorthandContent = Tier1Talent.cost.ToString() + " tp";
        tooltipInfo.bodyContent = "";
        tooltipInfo.bodyContent += Tier1Talent.modifier.ReadableName();

        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        Tier1Talent Tier1Talent = (Tier1Talent)talentInSlot;

        if (active)
        {
            PlayerCharacterUnit.player.talents.Tier1Talents.Remove(Tier1Talent);
            PlayerCharacterUnit.player.totalStats.DecreaseStat(Tier1Talent.modifier.Stat, Tier1Talent.modifier.Aspect, Tier1Talent.modifier.Method, Tier1Talent.modifier.Value);
            characterTalents.UpdatePoints(Tier1Talent.cost);
            if (parentBranchRune != null && parentBranchRune.active)
            {
                parentBranchRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier1Talents[index].active = false;
            }
            else if (parentTrunkRune != null && parentTrunkRune.active)
            {
                parentTrunkRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier1Talents[index].active = false;
            }
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
                PlayerCharacterUnit.player.talents.Tier1Talents.Add(Tier1Talent);
                PlayerCharacterUnit.player.totalStats.IncreaseStat(Tier1Talent.modifier.Stat, Tier1Talent.modifier.Aspect, Tier1Talent.modifier.Method, Tier1Talent.modifier.Value);
                characterTalents.UpdatePoints(-Tier1Talent.cost);
                if (parentBranchRune != null && parentBranchRune.active)
                {
                    parentBranchRune.Invest();
                    PlayerCharacterUnit.player.talents.ActivateTalent(parentBranchRune.trunkIndex, parentBranchRune.branchIndex, parentBranchRune.index, index, 1);
                }
                else if (parentTrunkRune != null && parentTrunkRune.active)
                {
                    parentTrunkRune.Invest();
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier1Talents[index].active = true;
                }
                active = true;
                outline.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((parentBranchRune != null && parentBranchRune.active) || (parentTrunkRune != null && parentTrunkRune.active))
            Toggle();
    }
}