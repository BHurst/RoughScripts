using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSigil
{
    public List<LocusRune> locusRunes = new List<LocusRune>();

    public WebSigil()
    {
        locusRunes.Add(new LocusRune()
        {
            simpleTalents = new List<SimpleTalent>() {
                new SimpleTalent() { talentName = "talent1", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Air, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent2", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Fire, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } },
                new SimpleTalent() { talentName = "talent3", cost = 1, modifiers = new List<ModifierGroup>() { new ModifierGroup() { Stat = ModifierGroup.EStat.Water, Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.Flat, Value = 10 } } }
                
            },
            complexTalents = new List<ComplexTalent>()
            {
                new CT_ExplosiveFireOrb(),
                new CT_HotColdSwap()
            }
        });
    }
}