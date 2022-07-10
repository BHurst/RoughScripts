using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentTrunkNode
{
    public int index;
    public int levelAvailable;
    public LocusRune runeInNode;
    public List<TalentBranch> connectedBranches = new List<TalentBranch>();
}