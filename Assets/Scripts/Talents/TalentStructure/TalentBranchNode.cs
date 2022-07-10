using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentBranchNode
{
    public int index;
    public int branchIndex;
    public int trunkNodeIndex;
    public TalentBranchNode priorNode;
    public LocusRune runeInNode;
    public List<TalentBranchNode> connectedBranchNodes = new List<TalentBranchNode>();
}