using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager {
    
    public static void CalculateDamage(Guid AttackerID, Guid DefenderID, WorldAbility Ability)
    {
        if (Ability.harmRune != null)
        {
            if (AttackerID == DefenderID && !Ability.harmRune.selfHarm)
            {

            }
            else
            {
                //RootUnit attacker = GameWorldReferenceClass.GetUnitByID(AttackerID);
                RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

                //DamageHitInfo hitInfo = new DamageHitInfo();
                float resolvedDamage = Ability.caculatedDamage;
                defender.unitHealth -= resolvedDamage;
                defender.ResolveHit(resolvedDamage);
            }
        }


        //float totalMinimumDamge = 0;
        //float totalMaximumDamge = 0;

        //foreach (Damage dmgComponent in Ability.abilityDamageComponents)
        //{
        //    float minimumDamageToDeal = dmgComponent.minimumDamage;
        //    float maximumDamageToDeal = dmgComponent.maximumDamage;

        //    minimumDamageToDeal *= Attacker.totalStats.BonusDamagePercent;
        //    minimumDamageToDeal *= Defender.totalStats.AllDamageReduction;

        //    maximumDamageToDeal *= Attacker.totalStats.BonusDamagePercent;
        //    maximumDamageToDeal *= Defender.totalStats.AllDamageReduction;

        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Air))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Area))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Arcane))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Astral))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Duration))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Ethereal))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Fire))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Attack))
        //    {
        //        minimumDamageToDeal *= Attacker.totalStats.BonusAttackDamagePercent;
        //        minimumDamageToDeal *= Defender.totalStats.Defence;

        //        maximumDamageToDeal *= Attacker.totalStats.BonusAttackDamagePercent;
        //        maximumDamageToDeal *= Defender.totalStats.Defence;
        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Nature))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Physical))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.SingleTarget))
        //    {

        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Spell))
        //    {
        //        minimumDamageToDeal *= Attacker.totalStats.BonusSpellDamagePercent;
        //        minimumDamageToDeal *= Defender.totalStats.AllResistance;

        //        maximumDamageToDeal *= Attacker.totalStats.BonusSpellDamagePercent;
        //        maximumDamageToDeal *= Defender.totalStats.AllResistance;
        //    }
        //    if (Ability.abilityTags.Contains(SpellStats.AbilityTag.Water))
        //    {

        //    }
        //    if(Ability.abilityBaseCriticalChance > 0)
        //    {
        //        if (Random.Range(1, 100) > Ability.abilityBaseCriticalChance)
        //        {
        //            hitInfo.hitType = GameWorldReferenceClass.HitType.Crit;

        //            minimumDamageToDeal *= Ability.abilityBaseCriticalMultiplier;
        //            maximumDamageToDeal *= Ability.abilityBaseCriticalMultiplier;
        //        }
        //    }

        //    totalMinimumDamge += minimumDamageToDeal;
        //    totalMaximumDamge += maximumDamageToDeal;
        //}

        //hitInfo.damageToDeal = Random.Range(totalMinimumDamge, totalMaximumDamge);

    }
}