using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireModifiers
{
    List<ModifierGroup> Fire_Modifiers = new List<ModifierGroup>()
    {
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 01, RangeHigh = 03, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 04, RangeHigh = 07, DropWeight = 900 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 08, RangeHigh = 12, DropWeight = 800 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 13, RangeHigh = 18, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 19, RangeHigh = 25, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 26, RangeHigh = 33, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 34, RangeHigh = 42, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 43, RangeHigh = 52, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 53, RangeHigh = 63, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 64, RangeHigh = 75, DropWeight = 100 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .09f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .10f, RangeHigh = .14f, DropWeight = 9000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .15f, RangeHigh = .19f, DropWeight = 8000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .20f, RangeHigh = .24f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .29f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .30f, RangeHigh = .34f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .35f, RangeHigh = .39f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .40f, RangeHigh = .44f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .45f, RangeHigh = .49f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .50f, RangeHigh = .54f, DropWeight = 100 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .02f, RangeHigh = .04f, DropWeight = 1000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .05f, RangeHigh = .07f, DropWeight = 9000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .08f, RangeHigh = .10f, DropWeight = 8000 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .13f, DropWeight = 700 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .14f, RangeHigh = .16f, DropWeight = 600 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .17f, RangeHigh = .19f, DropWeight = 500 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .20f, RangeHigh = .22f, DropWeight = 400 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .23f, RangeHigh = .25f, DropWeight = 300 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .26f, RangeHigh = .28f, DropWeight = 200 },
        new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .29f, RangeHigh = .31f, DropWeight = 100 }
    };

    public List<ModifierGroup> GetAllModifiers()
    {
        return Fire_Modifiers;
    }
}