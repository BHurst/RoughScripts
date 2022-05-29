using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        newT1.modifier = new ModifierGroup();
        newT1.modifier.Stat = ModifierGroup.RandomElement();
        newT1.modifier.Aspect = ModifierGroup.EAspect.Damage;
        newT1.modifier.Method = ModifierGroup.EMethod.Flat;
        newT1.modifier.Value = 10;

        newT1.talentName = newT1.modifier.ReadableName();

        return newT1;
    }
}