using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBaseManager
{
    public List<ModifierGroup> AllModifiers = new List<ModifierGroup>();

    public ModifierBaseManager()
    {
        AllModifiers.AddRange(new AirModifiers().GetAllModifiers());
        AllModifiers.AddRange(new ArcaneModifiers().GetAllModifiers());
        AllModifiers.AddRange(new AstralModifiers().GetAllModifiers());
        AllModifiers.AddRange(new EarthModifiers().GetAllModifiers());
        AllModifiers.AddRange(new EtherealModifiers().GetAllModifiers());
        AllModifiers.AddRange(new FireModifiers().GetAllModifiers());
        AllModifiers.AddRange(new IceModifiers().GetAllModifiers());
        AllModifiers.AddRange(new KineticModifiers().GetAllModifiers());
        AllModifiers.AddRange(new LifeModifiers().GetAllModifiers());
        AllModifiers.AddRange(new WaterModifiers().GetAllModifiers());
        AllModifiers.AddRange(new HealthModifiers().GetAllModifiers());
        AllModifiers.AddRange(new ManaModifiers().GetAllModifiers());
        AllModifiers.AddRange(new MovementModifiers().GetAllModifiers());
        AllModifiers.AddRange(new CastModifiers().GetAllModifiers());
    }

    public List<ModifierGroup> GetModifiersBy(ModifierGroup.EStat eStat = ModifierGroup.EStat.None, ModifierGroup.EAspect eAspect = ModifierGroup.EAspect.None, ModifierGroup.EMethod eMethod = ModifierGroup.EMethod.None)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (eStat != ModifierGroup.EStat.None && x.Stat == eStat) && (eAspect != ModifierGroup.EAspect.None && x.Aspect == eAspect) && (eMethod != ModifierGroup.EMethod.None && x.Method == eMethod));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> SelectRandomModifiers(List<ModifierGroup> modifierList, int numOfMods)
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
                    if (item.RangeLow % 1 != 0)
                        newMod.Value = (int)Random.Range(item.RangeLow * 100, item.RangeHigh * 100) / 100f;
                    else
                        newMod.Value = (int)Random.Range((int)item.RangeLow, (int)item.RangeHigh);

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