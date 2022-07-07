using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentStructure_Serialized
{
    public UITrunkNode_Serialized TrunkBase;

    public void FillFromUnserialized(TalentStructure talentStructure)
    {
        TrunkBase = new UITrunkNode_Serialized();
        TrunkBase.FillFromUnserialized(talentStructure.TrunkBase);
    }
}