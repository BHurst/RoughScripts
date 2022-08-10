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
        parentBranchRune = transform.GetComponentInParent<UITalentBranchNode>();
        parentTrunkRune = transform.GetComponentInParent<UITrunkNode>();
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
        tooltipInfo.shorthandContent = Tier2Talent.cost.ToString() + " tp";
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
            PlayerCharacterUnit.player.talents.Tier2Talents.Remove(Tier2Talent);
            foreach (var mod in Tier2Talent.modifiers)
                PlayerCharacterUnit.player.totalStats.DecreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
            characterTalents.UpdatePoints(Tier2Talent.cost);
            if (parentBranchRune != null && parentBranchRune.active)
            {
                parentBranchRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier2Talents[index].active = false;
            }
            else if (parentTrunkRune != null && parentTrunkRune.active)
            {
                parentTrunkRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier2Talents[index].active = false;
            }
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
                PlayerCharacterUnit.player.talents.Tier2Talents.Add(Tier2Talent);
                foreach (var mod in Tier2Talent.modifiers)
                    PlayerCharacterUnit.player.totalStats.IncreaseStat(mod.Stat, mod.Aspect, mod.Method, mod.Value);
                characterTalents.UpdatePoints(-Tier2Talent.cost);
                if (parentBranchRune != null && parentBranchRune.active)
                {
                    parentBranchRune.Invest();
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier2Talents[index].active = true;
                }
                else if (parentTrunkRune != null && parentTrunkRune.active)
                {
                    parentTrunkRune.Invest();
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier2Talents[index].active = true;
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