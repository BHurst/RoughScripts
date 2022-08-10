using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITalentTree : MonoBehaviour
{
    public string talentTreeName;
    public List<UITrunkNode> trunkNodes;

    public void LoadTree(TalentTree tree)
    {
        for (int i = 0; i < tree.trunk.trunkNodes.Count; i++)
        {
            trunkNodes[i].LoadTree(tree.trunk.trunkNodes[i]);
        }
    }

    public void UnlockNextTrunk()
    {
        for (int i = 0; i < PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes.Count; i++)
        {
            if (PlayerCharacterUnit.player.level.currentLevel >= PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[i].levelAvailable)
                trunkNodes[i].SetActive();
        }
    }

    public TalentTree ConvertToTalentTree()
    {
        TalentTree newTT = new TalentTree();
        newTT.talentTreeName = talentTreeName;
        newTT.trunk = new TalentTrunk();
        newTT.trunk.trunkNodes = new List<TalentTrunkNode>();
        for (int i = 0; i < trunkNodes.Count; i++)
        {
            TalentTrunkNode newTrunkNode = new TalentTrunkNode();
            newTT.trunk.trunkNodes.Add(newTrunkNode);
            newTrunkNode.index = trunkNodes[i].index;
            newTrunkNode.levelAvailable = trunkNodes[i].levelAvailable;
            newTrunkNode.runeInNode = trunkNodes[i].runeInNode;
            newTrunkNode.connectedBranches = new List<TalentBranch>();
            for (int j = 0; j < trunkNodes[i].connectedBranches.Count; j++)
            {
                TalentBranch newTalentBranch = new TalentBranch();
                newTT.trunk.trunkNodes[i].connectedBranches.Add(newTalentBranch);
                newTalentBranch.index = trunkNodes[i].connectedBranches[j].index;
                newTalentBranch.trunkNodeIndex = trunkNodes[i].connectedBranches[j].trunkNodeIndex;
                newTalentBranch.talentBranchNodes = new List<TalentBranchNode>();
                for (int l = 0; l < trunkNodes[i].connectedBranches[j].talentBranchNodes.Count; l++)
                {
                    TalentBranchNode newBranchNode = ConvertBranchNode(trunkNodes[i].connectedBranches[j].talentBranchNodes[l]);
                    newTT.trunk.trunkNodes[i].connectedBranches[j].talentBranchNodes.Add(newBranchNode);
                }
            }
        }

        return newTT;
    }

    private TalentBranchNode ConvertBranchNode(UITalentBranchNode branchNode)
    {
        TalentBranchNode newBranchNode = new TalentBranchNode();
        newBranchNode.index = branchNode.index;
        newBranchNode.branchIndex = branchNode.branchIndex;
        newBranchNode.trunkNodeIndex = branchNode.trunkIndex;
        newBranchNode.runeInNode = branchNode.runeInNode;
        newBranchNode.connectedBranchNodes = new List<TalentBranchNode>();
        foreach (UITalentBranchNode connectedBranchNode in branchNode.connectedBranchNodes)
        {
            TalentBranchNode newConnectedBranchNode = ConvertBranchNode(connectedBranchNode);
            newConnectedBranchNode.priorNode = newBranchNode;
            newBranchNode.connectedBranchNodes.Add(newConnectedBranchNode);
        }

        return newBranchNode;
    }
}