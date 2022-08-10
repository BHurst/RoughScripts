using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITalentBranch : MonoBehaviour
{
    public int index;
    public int trunkNodeIndex;
    public List<UITalentBranchNode> talentBranchNodes;
    public List<UITalentBranch> connectedBranches;
    bool loaded;

    void OnDrawGizmosSelected()
    {
        if (connectedBranches.Count > 0)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, connectedBranches[0].transform.position);
        }
        if (connectedBranches.Count > 1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, connectedBranches[1].transform.position);
        }
        if (connectedBranches.Count > 2)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, connectedBranches[2].transform.position);
        }
        if (connectedBranches.Count > 3)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, connectedBranches[3].transform.position);
        }
    }

    public void LoadTree(TalentBranch branch)
    {
        for (int i = 0; i < branch.talentBranchNodes.Count; i++)
        {
            talentBranchNodes[i].LoadTree(branch.talentBranchNodes[i]);
        }
    }

    public void StartCheck()
    {
        
    }
}