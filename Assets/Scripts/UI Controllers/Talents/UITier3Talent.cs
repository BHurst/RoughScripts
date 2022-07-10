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
        parentBranchRune = transform.GetComponentInParent<UITalentBranchNode>();
        parentTrunkRune = transform.GetComponentInParent<UITrunkNode>();
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
            PlayerCharacterUnit.player.talents.Tier3Talents.Remove(Tier3Talent);
            Tier3Talent.DeactivateTalent();
            characterTalents.UpdatePoints(Tier3Talent.cost);
            if (parentBranchRune != null && parentBranchRune.active)
            {
                parentBranchRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier3Talents[index].active = false;
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier3TalentNames[index].active = false;
            }
            else if (parentTrunkRune != null && parentTrunkRune.active)
            {
                parentTrunkRune.Divest();
                PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier3Talents[index].active = false;
            }
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
                PlayerCharacterUnit.player.talents.Tier3Talents.Add(Tier3Talent);
                Tier3Talent.ActivateTalent();
                characterTalents.UpdatePoints(-Tier3Talent.cost);
                if (parentBranchRune != null && parentBranchRune.active)
                {
                    parentBranchRune.Invest();
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier3Talents[index].active = true;
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentBranchRune.trunkIndex].connectedBranches[parentBranchRune.branchIndex].talentBranchNodes[parentBranchRune.index].runeInNode.Tier3TalentNames[index].active = true;
                }
                else if (parentTrunkRune != null && parentTrunkRune.active)
                {
                    parentTrunkRune.Invest();
                    PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[parentTrunkRune.index].runeInNode.Tier3Talents[index].active = true;
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