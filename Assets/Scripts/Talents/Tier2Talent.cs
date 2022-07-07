using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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
            Method = ModifierGroup.RandomMethod()
        });
        if (newT2.modifiers[0].Method == ModifierGroup.EMethod.Flat)
            newT2.modifiers[0].Value = 10;
        else if (newT2.modifiers[0].Method == ModifierGroup.EMethod.AddPercent)
            newT2.modifiers[0].Value = .1f;
        else if (newT2.modifiers[0].Method == ModifierGroup.EMethod.MultiplyPercent)
            newT2.modifiers[0].Value = .05f;
        newT2.modifiers.Add(new ModifierGroup()
        {
            Stat = ModifierGroup.RandomElement(),
            Aspect = ModifierGroup.EAspect.Damage,
            Method = ModifierGroup.RandomMethod()
        });
        if (newT2.modifiers[1].Method == ModifierGroup.EMethod.Flat)
            newT2.modifiers[1].Value = 10;
        else if (newT2.modifiers[1].Method == ModifierGroup.EMethod.AddPercent)
            newT2.modifiers[1].Value = .1f;
        else if (newT2.modifiers[1].Method == ModifierGroup.EMethod.MultiplyPercent)
            newT2.modifiers[1].Value = .05f;
        newT2.modifiers.Add(new ModifierGroup()
        {
            Stat = ModifierGroup.RandomElement(),
            Aspect = ModifierGroup.EAspect.Damage,
            Method = ModifierGroup.RandomMethod()
        });
        if (newT2.modifiers[2].Method == ModifierGroup.EMethod.Flat)
            newT2.modifiers[2].Value = 10;
        else if (newT2.modifiers[2].Method == ModifierGroup.EMethod.AddPercent)
            newT2.modifiers[2].Value = .1f;
        else if (newT2.modifiers[2].Method == ModifierGroup.EMethod.MultiplyPercent)
            newT2.modifiers[2].Value = .05f;

        newT2.talentName = "It's complicated";

        return newT2;
    }
}