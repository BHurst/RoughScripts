using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticModifiers
{
    List<ModifierGroup> kinetic_Modifiers = new List<ModifierGroup>();

    public List<ModifierGroup> GetModifer(int numOfMods)
    {
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 1, RangeHigh = 3, Weight = 1000 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 5, RangeHigh = 9, Weight = 750 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 10, RangeHigh = 17, Weight = 500 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 20, RangeHigh = 30, Weight = 250 });

        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .1f, Weight = 1000 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .19f, Weight = 750 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .38f, Weight = 500 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .5f, RangeHigh = .75f, Weight = 250 });
        
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .06f, Weight = 1000 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .10f, Weight = 750 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .14f, Weight = 500 });
        kinetic_Modifiers.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Kinetic, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .2f, Weight = 250 });

        return ModifierBase.SelectModifiers(kinetic_Modifiers, numOfMods);
    }
}