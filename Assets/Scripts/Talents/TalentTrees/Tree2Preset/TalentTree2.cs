using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentTree2 : TalentTree
{
    public TalentTree2()
    {
        talentTreeName = "TalentTree2";
        treeType = TalentTreeType.Tree2;
        trunk = new TalentTrunk();
        trunk.trunkNodes = new List<TalentTrunkNode>();
        trunk.trunkNodes.Add(new Tree1_Trunk1().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk2().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk3().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk4().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk5().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk6().Preset());
        trunk.trunkNodes.Add(new Tree1_Trunk7().Preset());
    }
}