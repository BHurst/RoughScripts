using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2Talent : BaseTalent
{
    public List<ModifierGroup> modifiers = new List<ModifierGroup>();

    public static Tier2Talent NewRandomTier2Talent()
    {
        Tier2Talent newT2 = new Tier2Talent();

        newT2.TalentId = System.Guid.NewGuid();
        newT2.itemLevel = 1;
        newT2.quality = 0;
        newT2.cost = 2;
        newT2.tier = Tier.tier2;
        newT2.modifiers.Add(new ModifierGroup()
        {
            Stat = ModifierGroup.RandomElement(),
            Aspect = ModifierGroup.EAspect.Damage,
            Method = ModifierGroup.RandomMethod(),
            Value = 10
        });
        newT2.modifiers.Add(new ModifierGroup()
        {
            Stat = ModifierGroup.RandomElement(),
            Aspect = ModifierGroup.EAspect.Damage,
            Method = ModifierGroup.RandomMethod(),
            Value = 10
        });
        newT2.modifiers.Add(new ModifierGroup()
        {
            Stat = ModifierGroup.RandomElement(),
            Aspect = ModifierGroup.EAspect.Damage,
            Method = ModifierGroup.RandomMethod(),
            Value = 10
        });

        return newT2;
    }
}