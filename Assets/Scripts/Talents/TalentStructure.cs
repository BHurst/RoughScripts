using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentStructure
{
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();

    public UITrunkNode TrunkBase;

    public void FillFromSerialized(TalentStructure_Serialized talentStructure_Serialized)
    {
        TrunkBase.FillFromSerialized(talentStructure_Serialized.TrunkBase);
    }
}