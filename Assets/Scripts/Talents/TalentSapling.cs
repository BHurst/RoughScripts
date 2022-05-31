using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentSapling
{
    public List<LocusRune> locusRunes = new List<LocusRune>();

    public TalentSapling()
    {
        locusRunes.Add(new LocusRune()
        {
            Tier1Talents = new List<Tier1Talent>() {
                new Tier1Talent() { talentName = "talent1", cost = 1, modifier = new ModifierGroup() { Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 }  },
                new Tier1Talent() { talentName = "talent2", cost = 1, modifier = new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 }  },
                new Tier1Talent() { talentName = "talent3", cost = 1, modifier = new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } }
                
            },
            Tier3Talents = new List<Tier3Talent>()
            {
                new T3_DotConvert(),
                new T3_HotColdSwap()
            }
        });
    }
}