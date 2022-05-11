using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralModifiers
{
    List<ModifierGroup> Astral_Modifiers = new List<ModifierGroup>();

    ModifierGroup T1_Flat_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 1, RangeHigh = 3, DropWeight = 1000 };
    ModifierGroup T2_Flat_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 5, RangeHigh = 9, DropWeight = 750 };
    ModifierGroup T3_Flat_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 10, RangeHigh = 17, DropWeight = 500 };
    ModifierGroup T4_Flat_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, RangeLow = 20, RangeHigh = 30, DropWeight = 250 };

    ModifierGroup T1_AddPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .05f, RangeHigh = .1f, DropWeight = 1000 };
    ModifierGroup T2_AddPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .12f, RangeHigh = .19f, DropWeight = 750 };
    ModifierGroup T3_AddPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .25f, RangeHigh = .38f, DropWeight = 500 };
    ModifierGroup T4_AddPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, RangeLow = .5f, RangeHigh = .75f, DropWeight = 250 };

    ModifierGroup T1_MultiplyPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .03f, RangeHigh = .06f, DropWeight = 1000 };
    ModifierGroup T2_MultiplyPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .07f, RangeHigh = .10f, DropWeight = 750 };
    ModifierGroup T3_MultiplyPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .11f, RangeHigh = .14f, DropWeight = 500 };
    ModifierGroup T4_MultiplyPercent_Damage = new ModifierGroup() { Stat = ModifierGroup.EStat.Astral, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.MultiplyPercent, RangeLow = .15f, RangeHigh = .2f, DropWeight = 250 };


    public List<ModifierGroup> GetModifer()
    {
        GetFlatDamageModifers();
        GetAddPercentDamageModifers();
        GetMultiplyPercentDamageModifers();

        return Astral_Modifiers;
    }

    public List<ModifierGroup> GetFlatDamageModifers()
    {
        Astral_Modifiers.Add(T1_Flat_Damage);
        Astral_Modifiers.Add(T2_Flat_Damage);
        Astral_Modifiers.Add(T3_Flat_Damage);
        Astral_Modifiers.Add(T4_Flat_Damage);

        return Astral_Modifiers;
    }

    public List<ModifierGroup> GetAddPercentDamageModifers()
    {
        Astral_Modifiers.Add(T1_AddPercent_Damage);
        Astral_Modifiers.Add(T2_AddPercent_Damage);
        Astral_Modifiers.Add(T3_AddPercent_Damage);
        Astral_Modifiers.Add(T4_AddPercent_Damage);

        return Astral_Modifiers;
    }

    public List<ModifierGroup> GetMultiplyPercentDamageModifers()
    {
        Astral_Modifiers.Add(T1_MultiplyPercent_Damage);
        Astral_Modifiers.Add(T2_MultiplyPercent_Damage);
        Astral_Modifiers.Add(T3_MultiplyPercent_Damage);
        Astral_Modifiers.Add(T4_MultiplyPercent_Damage);

        return Astral_Modifiers;
    }
}