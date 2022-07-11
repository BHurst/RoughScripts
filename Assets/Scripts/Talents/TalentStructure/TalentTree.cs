using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentTree
{
    public string talentTreeName;
    public TalentTreeType treeType;
    public TalentTrunk trunk = new TalentTrunk();

    public enum TalentTreeType
    {
        Basic,
        Tree1,
        Tree2,
        Tree3
    }
}