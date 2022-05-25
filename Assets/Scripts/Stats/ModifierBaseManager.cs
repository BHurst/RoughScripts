using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBaseManager
{
    class PickedModiferSet
    {
        public ModifierGroup.EStat usedStatMod;
        public ModifierGroup.EMethod usedMethodMod;
        public ModifierGroup.EAspect usedAspectMod;
    }

    public List<ModifierGroup> AllModifiers = new List<ModifierGroup>();
    public System.Random rng = new System.Random();

    List<PickedModiferSet> usedStatMod = new List<PickedModiferSet>();

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

        int n = AllModifiers.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            ModifierGroup value = AllModifiers[k];
            AllModifiers[k] = AllModifiers[n];
            AllModifiers[n] = value;
        }
    }

    public List<ModifierGroup> GetModifiersByStat(ModifierGroup.EStat eStat = ModifierGroup.EStat.None)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (eStat != ModifierGroup.EStat.None && x.Stat == eStat));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> GetModifiersByAspect(ModifierGroup.EAspect eAspect = ModifierGroup.EAspect.None)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (eAspect != ModifierGroup.EAspect.None && x.Aspect == eAspect));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> GetModifiersByMethod(ModifierGroup.EMethod eMethod = ModifierGroup.EMethod.None)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (eMethod != ModifierGroup.EMethod.None && x.Method == eMethod));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> GetModifiersBySlot(EquipmentSlot.SlotType slot = EquipmentSlot.SlotType.Any)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (x.availableOn.Contains(EquipmentSlot.SlotType.Any) || x.availableOn.Exists(y => y.Equals(slot))));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> GetModifiersByAll(ModifierGroup.EStat eStat = ModifierGroup.EStat.None, ModifierGroup.EAspect eAspect = ModifierGroup.EAspect.None, ModifierGroup.EMethod eMethod = ModifierGroup.EMethod.None, EquipmentSlot.SlotType slot = EquipmentSlot.SlotType.Any)
    {
        List<ModifierGroup> filtered_Modifiers = new List<ModifierGroup>();

        filtered_Modifiers = AllModifiers.FindAll(x => (eStat != ModifierGroup.EStat.None && x.Stat == eStat)
        && (eAspect != ModifierGroup.EAspect.None && x.Aspect == eAspect)
        && (eMethod != ModifierGroup.EMethod.None && x.Method == eMethod)
        && (x.availableOn.Contains(EquipmentSlot.SlotType.Any) || x.availableOn.Exists(y => y.Equals(slot))));

        return filtered_Modifiers;
    }

    public List<ModifierGroup> SelectRandomModifiers(List<ModifierGroup> modifierList, int numOfMods)
    {

        float randWholePool = 0;
        float randIncrementPool = 0;
        usedStatMod.Clear();
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
                if (randPick <= item.DropWeight + randIncrementPool && !usedStatMod.Exists(x => x.usedStatMod == item.Stat && x.usedMethodMod == item.Method && x.usedAspectMod == item.Aspect))
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
                    usedStatMod.Add(new PickedModiferSet() { usedStatMod = item.Stat, usedMethodMod = item.Method, usedAspectMod = item.Aspect });
                    break;
                }
                else
                    randIncrementPool += item.DropWeight;
            }
            //modifierList.RemoveAll(x => x.Stat == usedStatMod && x.Method == usedMethodMod && x.Aspect == usedAspectMod);
        }

        return newMods;
    }
}