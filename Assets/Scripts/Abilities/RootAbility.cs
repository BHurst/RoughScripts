using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Custom/Ability")]
public class RootAbility : ScriptableObject
{
    public int abilityID;
    public SpellStats stats = new SpellStats();

    public void ConsolidateKeywordBonuses()
    {
        foreach (AbilityModifierKeyword keyword in stats.abilityKeywords)
        {
            //stats.weaponModifer += 0;
            //stats.spellModifer += 0;
            //stats.numberOfSpells += 1;
            //stats.abilityBaseCost += 0;
            //stats.abilityBaseRangeMinimum += 0;
            //stats.abilityBaseRangeMaximum += 0;
            //stats.abilityBaseCooldown += 0;
            //stats.abilityBasePulseTimer += 0;
            //stats.abilityBasePulseDamage += 0;
            //stats.abilityBaseDuration += 0;
            //stats.abilityBaseInterval += 0;
            //stats.abilityBaseCastTime += 0;
            //stats.abilityBaseArea += 0;
            //stats.abilityBaseForce += 0;
            //stats.randomLow *= 1;
            //stats.randomHigh *= 1;
        }
    }

    public RootAbility OutputCopy(RootAbility newCopy)
    {
        return new RootAbility();
    }
}