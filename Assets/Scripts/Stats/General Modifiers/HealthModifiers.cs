using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifiers : MonoBehaviour
{
    List<ModifierGroup> Health_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=01, RangeLow = 01, RangeHigh = 05, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=02, RangeLow = 06, RangeHigh = 10, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=03, RangeLow = 11, RangeHigh = 15, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=04, RangeLow = 16, RangeHigh = 20, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=05, RangeLow = 21, RangeHigh = 25, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=06, RangeLow = 26, RangeHigh = 30, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=07, RangeLow = 31, RangeHigh = 35, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=08, RangeLow = 36, RangeHigh = 40, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=09, RangeLow = 41, RangeHigh = 45, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, Tier=10, RangeLow = 46, RangeHigh = 50, DropWeight = 100 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Tier=01, RangeLow = .01f, RangeHigh = .03f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Tier=02, RangeLow = .04f, RangeHigh = .06f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Tier=03, RangeLow = .07f, RangeHigh = .09f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Tier=04, RangeLow = .10f, RangeHigh = .12f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, Tier=05, RangeLow = .13f, RangeHigh = .15f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=01, RangeLow = .01f, RangeHigh = .02f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=02, RangeLow = .03f, RangeHigh = .04f, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=03, RangeLow = .05f, RangeHigh = .06f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=04, RangeLow = .07f, RangeHigh = .08f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=05, RangeLow = .09f, RangeHigh = .10f, DropWeight = 600 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=01, RangeLow = .100f, RangeHigh = .200f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=02, RangeLow = .300f, RangeHigh = .400f, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=03, RangeLow = .500f, RangeHigh = .600f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=04, RangeLow = .700f, RangeHigh = .800f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=05, RangeLow = .900f, RangeHigh = 1.00f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=06, RangeLow = 1.10f, RangeHigh = 1.20f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=07, RangeLow = 1.30f, RangeHigh = 1.40f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=08, RangeLow = 1.50f, RangeHigh = 1.60f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=09, RangeLow = 1.70f, RangeHigh = 1.80f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, Tier=10, RangeLow = 1.90f, RangeHigh = 2.00f, DropWeight = 100 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, Tier=01, RangeLow = .02f, RangeHigh = .04f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, Tier=02, RangeLow = .06f, RangeHigh = .08f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, Tier=03, RangeLow = .10f, RangeHigh = .12f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, Tier=04, RangeLow = .14f, RangeHigh = .16f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, Tier=05, RangeLow = .18f, RangeHigh = .20f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=01, RangeLow = .02f, RangeHigh = .03f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=02, RangeLow = .04f, RangeHigh = .05f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=03, RangeLow = .06f, RangeHigh = .07f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=04, RangeLow = .08f, RangeHigh = .09f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Health, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, Tier=05, RangeLow = .10f, RangeHigh = .11f, DropWeight = 200 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Health_Modifiers;
    }
}