using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITalentTree : MonoBehaviour
{
    public List<UITrunkNode> trunkNodes;
    public TalentTreeType talentTreeType;

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

    public enum TalentTreeType
    {
        Basic,
        TalentTree1,
        TalentTree2,
        TalentTree3
    }
}