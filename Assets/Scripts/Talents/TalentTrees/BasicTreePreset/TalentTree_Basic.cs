using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentTree_Basic : TalentTree
{
    public TalentTree_Basic()
    {
        talentTreeName = "BasicTree";
        treeType = TalentTreeType.Basic;
        trunk = new TalentTrunk();
        trunk.trunkNodes = new List<TalentTrunkNode>();
        trunk.trunkNodes.Add(BasicTree_Trunk1.Preset());
        trunk.trunkNodes.Add(BasicTree_Trunk2.Preset());
        trunk.trunkNodes.Add(BasicTree_Trunk3.Preset());
    }
}