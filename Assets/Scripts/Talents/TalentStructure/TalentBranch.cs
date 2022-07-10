using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentBranch
{
    public int index;
    public int trunkNodeIndex;
    public List<TalentBranchNode> talentBranchNodes = new List<TalentBranchNode>();
}