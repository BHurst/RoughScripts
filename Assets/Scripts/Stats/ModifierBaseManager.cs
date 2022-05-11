using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBaseManager
{
    AirModifiers AirModifiers = new AirModifiers();
    ArcaneModifiers ArcaneModifiers = new ArcaneModifiers();
    AstralModifiers AstralModifiers = new AstralModifiers();
    EarthModifiers EarthModifiers = new EarthModifiers();
    EtherealModifiers EtherealModifiers = new EtherealModifiers();
    FireModifiers FireModifiers = new FireModifiers();
    IceModifiers IceModifiers = new IceModifiers();
    KineticModifiers KineticModifiers = new KineticModifiers();
    LifeModifiers LifeModifiers = new LifeModifiers();
    WaterModifiers WaterModifiers = new WaterModifiers();

    public List<ModifierGroup> GetGeneralModifier(int numOfMods)
    {
        List<ModifierGroup> mods = new List<ModifierGroup>();

        mods.AddRange(AirModifiers.GetModifer());
        mods.AddRange(ArcaneModifiers.GetModifer());
        mods.AddRange(AstralModifiers.GetModifer());
        mods.AddRange(EarthModifiers.GetModifer());
        mods.AddRange(EtherealModifiers.GetModifer());
        mods.AddRange(FireModifiers.GetModifer());
        mods.AddRange(IceModifiers.GetModifer());
        mods.AddRange(KineticModifiers.GetModifer());
        mods.AddRange(LifeModifiers.GetModifer());
        mods.AddRange(WaterModifiers.GetModifer());

        return mods;
    }

    public List<ModifierGroup> SelectModifiers(List<ModifierGroup> modifierList, int numOfMods)
    {
        
        float randWholePool = 0;
        float randIncrementPool = 0;
        ModifierGroup.EStat usedStatMod = ModifierGroup.EStat.None;
        ModifierGroup.EMethod usedMethodMod = ModifierGroup.EMethod.None;
        ModifierGroup.EAspect usedAspectMod = ModifierGroup.EAspect.None;
        List<ModifierGroup> newMods = new List<ModifierGroup>();

        for (int i = 0; i < numOfMods; i++)
        {
            randWholePool = 0;
            randIncrementPool = 0;
            foreach (var item in modifierList)
            {
                randWholePool += item.DropWeight;
            }

            float randPick = Random.Range(0, randWholePool);

            foreach (var item in modifierList)
            {
                if (randPick <= item.DropWeight + randIncrementPool)
                {
                    ModifierGroup newMod = new ModifierGroup()
                    {
                        Stat = item.Stat,
                        Aspect = item.Aspect,
                        Method = item.Method,
                        RangeLow = item.RangeLow,
                        RangeHigh = item.RangeHigh
                    };
                    if (newMod.Method == ModifierGroup.EMethod.AddPercent || newMod.Method == ModifierGroup.EMethod.MultiplyPercent)
                        newMod.Value = (int)Random.Range(item.RangeLow * 100, item.RangeHigh * 100) / 100f;
                    else
                        newMod.Value = Random.Range((int)item.RangeLow, (int)item.RangeHigh);

                    newMods.Add(newMod);
                    usedStatMod = item.Stat;
                    usedMethodMod = item.Method;
                    usedAspectMod = item.Aspect;
                    break;
                }
                else
                    randIncrementPool += item.DropWeight;
            }
            modifierList.RemoveAll(x => x.Stat == usedStatMod && x.Method == usedMethodMod && x.Aspect == usedAspectMod);
        }

        return newMods;
    }
}