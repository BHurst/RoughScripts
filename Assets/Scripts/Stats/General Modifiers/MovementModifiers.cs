using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModifiers : MonoBehaviour
{
    List<ModifierGroup> Movement_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .04f, RangeHigh = .05f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .06f, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .06f, RangeHigh = .07f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .07f, RangeHigh = .08f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .08f, RangeHigh = .09f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .09f, RangeHigh = .10f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .10f, RangeHigh = .11f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .11f, RangeHigh = .12f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .13f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .13f, RangeHigh = .14f, DropWeight = 100 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .03f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .04f, RangeHigh = .04f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .05f, RangeHigh = .05f, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .06f, RangeHigh = .06f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .07f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .08f, RangeHigh = .08f, DropWeight = 200 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .05f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .08f, RangeHigh = .08f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .11f, RangeHigh = .11f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .15f, RangeHigh = .15f, DropWeight = 250 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Movement_Modifiers;
    }
}