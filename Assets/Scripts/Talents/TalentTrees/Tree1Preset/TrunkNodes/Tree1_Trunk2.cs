using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1_Trunk2 : TrunkPresetBase
{
    public override TalentTrunkNode Preset()
    {
        TalentTrunkNode preset = new TalentTrunkNode();
        preset.runeInNode = new LocusRune()
        {
            locusRuneName = "Trunk 2",
            Tier1Talents = new List<Tier1Talent>()
            {
                new Tier1Talent(){ cost = 1, talentName = "Flat Air Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Flat Earth Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Earth, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Flat Electricity Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Electricity, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Flat Fire Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Flat Ice Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Ice, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 5 } }
            },
            Tier2Talents = new List<Tier2Talent>()
            {
                new Tier2Talent(){ cost = 2, talentName = "Flow", modifiers = new List<ModifierGroup>(){
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, Value = .10f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Cost, Method = ModifierGroup.EMethod.AddPercent, Value = .10f },
                } }
            },
            Tier3Talents = new List<Tier3Talent>()
            {

            }
        };
        return preset;
    }
}