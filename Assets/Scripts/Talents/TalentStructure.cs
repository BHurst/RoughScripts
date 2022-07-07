using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentStructure
{
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();

    public UITrunkNode Trunk1;
    public UITrunkNode Trunk2;
    public UITrunkNode Trunk3;
    public UITrunkNode Trunk4;
    public UITrunkNode Trunk5;
    public UITrunkNode Trunk6;
    public UITrunkNode Trunk7;

    public void RigTree()
    {
        Trunk1 = UIManager.main.talentSheet.talentContent.transform.GetChild(0).GetComponent<UITrunkNode>();
        Trunk2 = UIManager.main.talentSheet.talentContent.transform.GetChild(1).GetComponent<UITrunkNode>();
        Trunk3 = UIManager.main.talentSheet.talentContent.transform.GetChild(2).GetComponent<UITrunkNode>();
        Trunk4 = UIManager.main.talentSheet.talentContent.transform.GetChild(3).GetComponent<UITrunkNode>();
        Trunk5 = UIManager.main.talentSheet.talentContent.transform.GetChild(4).GetComponent<UITrunkNode>();
        Trunk6 = UIManager.main.talentSheet.talentContent.transform.GetChild(5).GetComponent<UITrunkNode>();
        Trunk7 = UIManager.main.talentSheet.talentContent.transform.GetChild(6).GetComponent<UITrunkNode>();
    }

    public void FillFromSerialized(TalentStructure_Serialized talentStructure_Serialized)
    {
        Trunk1.FillFromSerialized(talentStructure_Serialized.Trunk1);
        Trunk2.FillFromSerialized(talentStructure_Serialized.Trunk2);
        Trunk3.FillFromSerialized(talentStructure_Serialized.Trunk3);
        Trunk4.FillFromSerialized(talentStructure_Serialized.Trunk4);
        Trunk5.FillFromSerialized(talentStructure_Serialized.Trunk5);
        Trunk6.FillFromSerialized(talentStructure_Serialized.Trunk6);
        Trunk7.FillFromSerialized(talentStructure_Serialized.Trunk7);
    }
}