using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModifiers : MonoBehaviour
{
    List<ModifierGroup> Movement_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .1f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .19f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .38f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .5f, RangeHigh = .75f, DropWeight = 250 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .06f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .10f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .14f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .2f, DropWeight = 250 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .03f, RangeHigh = .06f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .07f, RangeHigh = .10f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .11f, RangeHigh = .14f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Sprint, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .15f, RangeHigh = .2f, DropWeight = 250 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Movement_Modifiers;
    }
}