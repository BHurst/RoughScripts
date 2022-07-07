using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TalentStructure_Serialized
{
    public UITrunkNode_Serialized Trunk1;
    public UITrunkNode_Serialized Trunk2;
    public UITrunkNode_Serialized Trunk3;
    public UITrunkNode_Serialized Trunk4;
    public UITrunkNode_Serialized Trunk5;
    public UITrunkNode_Serialized Trunk6;
    public UITrunkNode_Serialized Trunk7;

    public void FillFromUnserialized(TalentStructure talentStructure)
    {
        Trunk1 = new UITrunkNode_Serialized();
        Trunk1.FillFromUnserialized(talentStructure.Trunk1);
        Trunk2 = new UITrunkNode_Serialized();
        Trunk2.FillFromUnserialized(talentStructure.Trunk2);
        Trunk3 = new UITrunkNode_Serialized();
        Trunk3.FillFromUnserialized(talentStructure.Trunk3);
        Trunk4 = new UITrunkNode_Serialized();
        Trunk4.FillFromUnserialized(talentStructure.Trunk4);
        Trunk5 = new UITrunkNode_Serialized();
        Trunk5.FillFromUnserialized(talentStructure.Trunk5);
        Trunk6 = new UITrunkNode_Serialized();
        Trunk6.FillFromUnserialized(talentStructure.Trunk6);
        Trunk7 = new UITrunkNode_Serialized();
        Trunk7.FillFromUnserialized(talentStructure.Trunk7);
    }
}