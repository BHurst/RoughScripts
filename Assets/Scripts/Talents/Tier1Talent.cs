using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tier1Talent : BaseTalent
{
    public ModifierGroup modifier = new ModifierGroup();

    public static Tier1Talent NewRandomTier1Talent()
    {
        Tier1Talent newT1 = new Tier1Talent();

        newT1.TalentId = System.Guid.NewGuid();
        newT1.itemLevel = 1;
        newT1.quality = 0;
        newT1.cost = 1;
        newT1.tier = Tier.tier1;
        newT1.modifier = new ModifierGroup();
        newT1.modifier.Stat = ModifierGroup.RandomElement();
        newT1.modifier.Aspect = ModifierGroup.EAspect.Damage;
        newT1.modifier.Method = ModifierGroup.RandomMethod();
        if(newT1.modifier.Method == ModifierGroup.EMethod.Flat)
        newT1.modifier.Value = 10;
        else if (newT1.modifier.Method == ModifierGroup.EMethod.AddPercent)
            newT1.modifier.Value = .1f;
        else if (newT1.modifier.Method == ModifierGroup.EMethod.MultiplyPercent)
            newT1.modifier.Value = .05f;

        newT1.talentName = newT1.modifier.ReadableName();

        return newT1;
    }
}