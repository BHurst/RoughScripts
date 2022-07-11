using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1_Trunk6 : TrunkPresetBase
{
    public override TalentTrunkNode Preset()
    {
        TalentTrunkNode preset = new TalentTrunkNode();
        preset.runeInNode = new LocusRune()
        {
            locusRuneName = "Trunk 6",
            Tier1Talents = new List<Tier1Talent>()
            {
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } }
            },
            Tier2Talents = new List<Tier2Talent>()
            {
                new Tier2Talent(){ cost = 2, talentName = "Vigor", modifiers = new List<ModifierGroup>(){
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 10 },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Value = .10f },
                } }
            },
            Tier3Talents = new List<Tier3Talent>()
            {

            }
        };
        preset.index = 0;
        preset.connectedBranches = new List<TalentBranch>();
        preset.connectedBranches.Add(new TalentBranch() { index = 0, talentBranchNodes = new List<TalentBranchNode>() { new TalentBranchNode() { index = 0 } } });

        preset.levelAvailable = 2;

        return preset;
    }
}