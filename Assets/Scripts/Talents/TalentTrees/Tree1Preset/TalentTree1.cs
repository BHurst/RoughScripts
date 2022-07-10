using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentTree1 : TalentTree
{
    public TalentTree1()
    {
        talentTreeName = "TalentTree1";
        //talentTreeType = TalentTreeType.TalentTree3;
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