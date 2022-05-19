using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastModifiers : MonoBehaviour
{
    List<ModifierGroup> Cast_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .01f, RangeHigh = .03f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .04f, RangeHigh = .07f, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .08f, RangeHigh = .12f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .13f, RangeHigh = .18f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .19f, RangeHigh = .25f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .26f, RangeHigh = .33f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .34f, RangeHigh = .42f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .43f, RangeHigh = .52f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .53f, RangeHigh = .63f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .64f, RangeHigh = .75f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .01f, RangeHigh = .02f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .04f, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .05f, RangeHigh = .06f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .08f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .09f, RangeHigh = .10f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .12f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .13f, RangeHigh = .14f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .16f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .17f, RangeHigh = .18f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Cast, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .19f, RangeHigh = .20f, DropWeight = 200 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Cast_Modifiers;
    }
}