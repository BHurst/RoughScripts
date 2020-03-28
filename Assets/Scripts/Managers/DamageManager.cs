using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager {
    
    public static DamageHitInfo CalculateDamage(RootUnit Attacker, RootUnit Defender, RootWorldAbility Ability)
    {
        DamageHitInfo hitInfo = new DamageHitInfo();

        float totalMinimumDamge = 0;
        float totalMaximumDamge = 0;

        foreach (Damage dmgComponent in Ability.stats.abilityDamageComponents)
        {
            float minimumDamageToDeal = dmgComponent.minimumDamage;
            float maximumDamageToDeal = dmgComponent.maximumDamage;

            minimumDamageToDeal *= Attacker.totalStats.BonusDamagePercent;
            minimumDamageToDeal *= Defender.totalStats.AllDamageReduction;

            maximumDamageToDeal *= Attacker.totalStats.BonusDamagePercent;
            maximumDamageToDeal *= Defender.totalStats.AllDamageReduction;

            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Air))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Area))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Arcane))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Astral))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Duration))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Ethereal))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Fire))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Attack))
            {
                minimumDamageToDeal *= Attacker.totalStats.BonusAttackDamagePercent;
                minimumDamageToDeal *= Defender.totalStats.Defence;

                maximumDamageToDeal *= Attacker.totalStats.BonusAttackDamagePercent;
                maximumDamageToDeal *= Defender.totalStats.Defence;
            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Nature))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Physical))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.SingleTarget))
            {

            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Spell))
            {
                minimumDamageToDeal *= Attacker.totalStats.BonusSpellDamagePercent;
                minimumDamageToDeal *= Defender.totalStats.AllResistance;

                maximumDamageToDeal *= Attacker.totalStats.BonusSpellDamagePercent;
                maximumDamageToDeal *= Defender.totalStats.AllResistance;
            }
            if (Ability.stats.abilityTags.Contains(AbilityTags.AbilityTag.Water))
            {

            }
            if(Ability.stats.abilityBaseCriticalChance > 0)
            {
                if (Random.Range(1, 100) > Ability.stats.abilityBaseCriticalChance)
                {
                    hitInfo.hitType = GameWorldReferenceClass.HitType.Crit;

                    minimumDamageToDeal *= Ability.stats.abilityBaseCriticalMultiplier;
                    maximumDamageToDeal *= Ability.stats.abilityBaseCriticalMultiplier;
                }
            }

            totalMinimumDamge += minimumDamageToDeal;
            totalMaximumDamge += maximumDamageToDeal;
        }

        hitInfo.damageToDeal = Random.Range(totalMinimumDamge, totalMaximumDamge);

        return hitInfo;
    }
}