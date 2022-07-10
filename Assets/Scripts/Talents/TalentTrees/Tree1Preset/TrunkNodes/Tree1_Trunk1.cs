using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1_Trunk1 : TrunkPresetBase
{
    public override TalentTrunkNode Preset()
    {
        TalentTrunkNode preset = new TalentTrunkNode();
        preset.runeInNode = new LocusRune()
        {
            locusRuneName = "Trunk 1",
            Tier1Talents = new List<Tier1Talent>()
            {
                new Tier1Talent(){ cost = 1, talentName = "Small Additional Health", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Additional Mana", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Additional Health", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } },
                new Tier1Talent(){ cost = 1, talentName = "Small Additional Mana", modifier = new ModifierGroup(){ Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 5 } }
            },
            Tier2Talents = new List<Tier2Talent>()
            {
                new Tier2Talent(){ cost = 2, talentName = "Vigor", modifiers = new List<ModifierGroup>(){ 
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Value = 10 },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Value = .10f },
                } },
                new Tier2Talent(){ cost = 2, talentName = "Speckled Armor", modifiers = new List<ModifierGroup>(){
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Arcane, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Earth, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Electricity, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Ethereal, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Ice, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Life, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                    new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Resistance, Method = ModifierGroup.EMethod.AddPercent, Value = .05f },
                } }
            },
            Tier3Talents = new List<Tier3Talent>()
            {

            }
        };

        return preset;
    }
}