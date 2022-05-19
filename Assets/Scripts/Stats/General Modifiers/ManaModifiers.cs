using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaModifiers : MonoBehaviour
{
    List<ModifierGroup> Mana_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, RangeLow = 1, RangeHigh = 3, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, RangeLow = 5, RangeHigh = 9, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, RangeLow = 10, RangeHigh = 17, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.Flat, RangeLow = 20, RangeHigh = 30, DropWeight = 250 },
                                                                                              
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .1f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .19f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .38f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .5f, RangeHigh = .75f, DropWeight = 250 },
                                                                                              
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .06f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .10f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .14f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Max, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .2f, DropWeight = 250 },

        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, RangeLow = 1, RangeHigh = 3, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, RangeLow = 5, RangeHigh = 9, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, RangeLow = 10, RangeHigh = 17, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.Flat, RangeLow = 20, RangeHigh = 30, DropWeight = 250 },
                                                                                              
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .1f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .19f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .38f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .5f, RangeHigh = .75f, DropWeight = 250 },
                                                                                              
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .06f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .10f, DropWeight = 750 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .14f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Mana, Aspect = ModifierGroup.EAspect.Regeneration, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .2f, DropWeight = 250 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Mana_Modifiers;
    }
}