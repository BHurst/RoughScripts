using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierBase
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

        int airMods = 0;
        int arcaneMods = 0;
        int astralMods = 0;
        int earthMods = 0;
        int etherealMods = 0;
        int fireMods = 0;
        int iceMods = 0;
        int kineticMods = 0;
        int lifeMods = 0;
        int waterMods = 0;

        for (int i = 0; i < numOfMods; i++)
        {
            int temp = Random.Range(0, 10);

            switch (temp)
            {
                case 0:
                    airMods++;
                    break;
                case 1:
                    arcaneMods++;
                    break;
                case 2:
                    astralMods++;
                    break;
                case 3:
                    earthMods++;
                    break;
                case 4:
                    etherealMods++;
                    break;
                case 5:
                    fireMods++;
                    break;
                case 6:
                    iceMods++;
                    break;
                case 7:
                    kineticMods++;
                    break;
                case 8:
                    lifeMods++;
                    break;
                case 9:
                    waterMods++;
                    break;
                default:
                    break;
            }
        }

        mods.AddRange(AirModifiers.GetModifer(airMods));
        mods.AddRange(ArcaneModifiers.GetModifer(arcaneMods));
        mods.AddRange(AstralModifiers.GetModifer(astralMods));
        mods.AddRange(EarthModifiers.GetModifer(earthMods));
        mods.AddRange(EtherealModifiers.GetModifer(etherealMods));
        mods.AddRange(FireModifiers.GetModifer(fireMods));
        mods.AddRange(IceModifiers.GetModifer(iceMods));
        mods.AddRange(KineticModifiers.GetModifer(kineticMods));
        mods.AddRange(LifeModifiers.GetModifer(lifeMods));
        mods.AddRange(WaterModifiers.GetModifer(waterMods));

        return mods;
    }

    public static List<ModifierGroup> SelectModifiers(List<ModifierGroup> modifierList, int numOfMods)
    {
        float randPool = 0;
        ModifierGroup.EMethod usedMod = ModifierGroup.EMethod.None;
        List<ModifierGroup> newMods = new List<ModifierGroup>();

        for (int i = 0; i < numOfMods; i++)
        {

            foreach (var item in modifierList)
            {
                randPool += item.Weight;
            }

            float randPick = Random.Range(0, randPool);
            randPool = 0;

            foreach (var item in modifierList)
            {
                if (randPick <= item.Weight + randPool)
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
                    usedMod = item.Method;
                    break;
                }
                else
                    randPool += item.Weight;
            }
            modifierList.RemoveAll(x => x.Method == usedMod);
        }

        return newMods;
    }
}