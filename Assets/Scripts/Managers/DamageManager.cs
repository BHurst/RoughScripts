using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static CalculatedAbilityStats CalculateAbilityAttacker(RootAbility ability)
    {
        CalculatedAbilityStats snapshot = new CalculatedAbilityStats();
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        snapshot.damage = 0;

        snapshot.projectileSpeed = (1 + unit.totalStats.Projectile_Rate_AddPercent.value) * unit.totalStats.Projectile_Rate_MultiplyPercent.value;
        snapshot.area = ability.GetArea() * (1 + unit.totalStats.Ability_Area_AddPercent.value) * unit.totalStats.Ability_Area_MultiplyPercent.value;
        snapshot.chains = ability.GetChains() + unit.totalStats.Ability_Chains_Flat.value;
        snapshot.projectiles = unit.totalStats.Ability_Projectiles_Flat.value;

        if (ability.harmful && ability.snapshot.overrideDamage == -1)
        {
            snapshot.damage = ability.GetDamage();
            string school = ability.schoolRune.schoolRuneType.ToString();

            snapshot.damage += ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(unit.totalStats)).value;
            snapshot.damage *= 1 + (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_Damage_AddPercent.value);

            if (ability.GetHitType() == RootAbility.HitType.Hit)
                snapshot.damage *= 1 + unit.totalStats.GlobalHitDamage_Damage_AddPercent.value;
            else if (ability.GetHitType() == RootAbility.HitType.DoT)
                snapshot.damage *= 1 + unit.totalStats.GlobalDoTDamage_Damage_AddPercent.value;

            snapshot.damage *= ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_Damage_MultiplyPercent.value;

            if (ability.GetHitType() == RootAbility.HitType.Hit)
                snapshot.damage *= unit.totalStats.GlobalHitDamage_Damage_MultiplyPercent.value;
            else if (ability.GetHitType() == RootAbility.HitType.DoT)
                snapshot.damage *= unit.totalStats.GlobalDoTDamage_Damage_MultiplyPercent.value;

            snapshot.damage *= ability.GetDamageMultipliers();

            if (ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Electricity && unit.state.Overcharged)
                snapshot.damage *= State_Overcharge.overchargeBonus;


            if (ability.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
            {
                snapshot.chargeAndChannelMinimum = snapshot.damage * unit.totalStats.Channel_Default;
                snapshot.chargeAndChannelMaximum = snapshot.damage * unit.totalStats.Channel_Max;
                snapshot.damage *= unit.totalStats.Channel_Current;
            }
            else if (ability.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
            {
                snapshot.chargeAndChannelMinimum = 0;
                snapshot.chargeAndChannelMaximum = snapshot.damage * (1 + unit.totalStats.Charge_Max_AddPercent.value);
                snapshot.damage *= ((CastModeRune_Charge)ability.castModeRune).chargeAmount * (1 + unit.totalStats.Charge_Max_AddPercent.value);
            }

            snapshot.duration *= (1 + unit.totalStats.Ability_Duration_AddPercent.value) * unit.totalStats.Ability_Duration_MultiplyPercent.value;
        }
        else
        {
            snapshot.duration *= (1 + unit.totalStats.Ability_Duration_AddPercent.value) * unit.totalStats.Ability_Duration_MultiplyPercent.value;
            snapshot.damage = ability.snapshot.overrideDamage;
        }

        CalculatedStateStats cSS = new CalculatedStateStats();

        cSS.bleedStrength = ((1 + unit.totalStats.Bleed_Strength_AddPercent.value) * unit.totalStats.Bleed_Strength_MultiplyPercent.value) * snapshot.damage;
        cSS.burnStrength = (1 + unit.totalStats.Burn_Strength_AddPercent.value) * unit.totalStats.Burn_Strength_MultiplyPercent.value;
        cSS.decayStrength = (1 + unit.totalStats.Decay_Strength_AddPercent.value) * unit.totalStats.Decay_Strength_MultiplyPercent.value;
        cSS.distortionStrength = snapshot.damage;
        cSS.frostbiteStrength = (1 + unit.totalStats.Frostbite_Strength_AddPercent.value) * unit.totalStats.Frostbite_Strength_MultiplyPercent.value;
        cSS.overchargeStrength = 20;
        cSS.rimeguardStrength = ability.GetCost();
        cSS.soulrotStrength = ability.GetCost();
        
        ability.abilityStateManager.PickState(ability, unit);
        ability.abilityStateManager.snapshot = cSS;

        ability.snapshot = snapshot;
        return snapshot;
    }

    public static void CalculateAbilityDefender(Guid DefenderID, RootAbility ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(DefenderID).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        if (ability.harmful)
        {
            float total = ability.snapshot.damage;
            string school = ability.schoolRune.schoolRuneType.ToString();

            total /= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_AddPercent", school)).GetValue(unit.totalStats)).value;
            total /= 1 + unit.totalStats.GlobalDamage_Resistance_AddPercent.value;

            if(unit.state.RimeGuard && (ability.GetHitType() == RootAbility.HitType.Hit || ability.GetHitType() == RootAbility.HitType.MultiHit))
            {
                total *= State_RimeGuard.frostguardDamageReduction;
                unit.state.rimeGuardCharges--;
            }

            unit.ResolveHit(total, false);
        }

        if (ability.helpful)
        {
            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(ability.snapshot.calculatedHealing * 100) / 100;

            unit.ResolveHeal(resolvedHealing, false);

        }
    }

    public static void CalculateStatusDamage(RootCharacter unit, float totalStatusTick)
    {
        //unit.totalStats.Health_Current += totalStatusTick;
        //unit.ResolveHit(totalStatusTick, true);
    }
}