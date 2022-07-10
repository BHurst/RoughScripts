using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTree_Trunk3
{
    public static TalentTrunkNode Preset()
    {
        TalentTrunkNode preset = new TalentTrunkNode();
        preset.runeInNode = new LocusRune()
        {
            locusRuneName = "Trunk 1",
            Tier1Talents = new List<Tier1Talent>()
            {
                new Tier1Talent(){ cost = 1, talentName = "Large Additional Health", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 50 } },
                new Tier1Talent(){ cost = 1, talentName = "Large Additional Mana", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 50 } },
                new Tier1Talent(){ cost = 1, talentName = "Large Additional Health", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 50 } },
                new Tier1Talent(){ cost = 1, talentName = "Large Additional Mana", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 50 } }
            },
            Tier2Talents = new List<Tier2Talent>()
            {
                
            },
            Tier3Talents = new List<Tier3Talent>()
            {

            }
        };
        preset.index = 2;
        preset.connectedBranches = new List<TalentBranch>();
        preset.connectedBranches.Add(new TalentBranch() { index = 0, talentBranchNodes = new List<TalentBranchNode>() { new TalentBranchNode() { index = 0 } } });
        preset.connectedBranches.Add(new TalentBranch() { index = 1, talentBranchNodes = new List<TalentBranchNode>() { new TalentBranchNode() { index = 0 } } });

        preset.levelAvailable = 6;

        return preset;
    }
}