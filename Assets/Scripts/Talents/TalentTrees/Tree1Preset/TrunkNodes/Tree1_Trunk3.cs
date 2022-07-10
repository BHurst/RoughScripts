using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1_Trunk3 : TrunkPresetBase
{
    public override TalentTrunkNode Preset()
    {
        TalentTrunkNode preset = new TalentTrunkNode();
        preset.runeInNode = new LocusRune()
        {
            locusRuneName = "Trunk 3",
            Tier1Talents = new List<Tier1Talent>()
            {
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Orb, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Value = .1f } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Nova, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Value = .1f } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Arc, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Value = .1f } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Strike, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Value = .1f } },
                new Tier1Talent(){ cost = 1, talentName = "Small Health Increase", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Zone, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Value = .1f } }
            },
            Tier2Talents = new List<Tier2Talent>()
            {
                new Tier2Talent(){ cost = 2, talentName = "Mental Frame", modifiers = new List<ModifierGroup>(){
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Ability, Aspect = ModifierGroup.EAspect.Area, Method = ModifierGroup.EMethod.AddPercent, Value = .2f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Ability, Aspect = ModifierGroup.EAspect.Duration, Method = ModifierGroup.EMethod.AddPercent, Value = .25f },
                } }
            },
            Tier3Talents = new List<Tier3Talent>()
            {

            }
        };
        return preset;
    }
}