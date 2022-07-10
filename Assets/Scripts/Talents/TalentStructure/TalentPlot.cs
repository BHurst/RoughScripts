using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentPlot
{
    public TalentTree activeTalentTree;
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();

    public void Setup(TalentTree preset)
    {
        activeTalentTree = preset;
        foreach (var trunk in preset.trunk.trunkNodes)
        {
            trunk.runeInNode.FillOutTier3Talents();
            foreach (var branch in trunk.connectedBranches)
            {
                foreach (var branchNode in branch.talentBranchNodes)
                {
                    if (branchNode.runeInNode != null)
                        branchNode.runeInNode.FillOutTier3Talents();
                }
            }
        }
        UIManager.main.talentSheet.SetTalentTree();
    }

    public void UnlockNextTrunk(int level)
    {
        foreach (var item in activeTalentTree.trunk.trunkNodes)
        {
            //if(level >= item.levelAvailable)

        }
    }

    public void ActivateTalent(int TrunkIndex, int BranchIndex, int BranchNodeIndex, int TalentIndex, int tier)
    {
        switch (tier)
        {
            case 1:
                activeTalentTree.trunk.trunkNodes[TrunkIndex].connectedBranches[BranchIndex].talentBranchNodes[BranchNodeIndex].runeInNode.Tier1Talents[TalentIndex].active = true;
                break;
            case 2:
                activeTalentTree.trunk.trunkNodes[TrunkIndex].connectedBranches[BranchIndex].talentBranchNodes[BranchNodeIndex].runeInNode.Tier2Talents[TalentIndex].active = true;
                break;
            case 3:
                activeTalentTree.trunk.trunkNodes[TrunkIndex].connectedBranches[BranchIndex].talentBranchNodes[BranchNodeIndex].runeInNode.Tier3Talents[TalentIndex].active = true;
                break;
            default:
                break;
        }
    }
}