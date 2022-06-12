using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static UnitStatsSnapshot CalculateAbilityAttacker(BaseAbility ability)
    {
        UnitStatsSnapshot snapshot = new UnitStatsSnapshot();
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        snapshot.damage = 0;

        ability.snapshot.increasedProjectileSpeed = (1 + unit.totalStats.Projectile_Rate_AddPercent.value) * unit.totalStats.Projectile_Rate_MultiplyPercent.value;
        ability.snapshot.area = (1 + unit.totalStats.Ability_Area_AddPercent.value) * unit.totalStats.Ability_Area_MultiplyPercent.value;
        ability.snapshot.increasedChains = unit.totalStats.Ability_Chains_Flat.value;
        ability.snapshot.increasedProjectiles = unit.totalStats.Ability_Projectiles_Flat.value;

        if (ability.harmful && ability.snapshot.overrideDamage == -1)
        {
            snapshot.damage = ability.GetDamage();
            string school = ability.schoolRune.schoolRuneType.ToString();

            snapshot.damage += (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(unit.totalStats)).value);
            snapshot.damage *= 1 + (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_Damage_AddPercent.value);

            if (ability.GetHitType() == FormRune.HitType.Hit)
                snapshot.damage *= 1 + unit.totalStats.GlobalHitDamage_Damage_AddPercent.value;
            else if (ability.GetHitType() == FormRune.HitType.DoT)
                snapshot.damage *= 1 + unit.totalStats.GlobalDoTDamage_Damage_AddPercent.value;

            snapshot.damage *= (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_Damage_MultiplyPercent.value);

            if (ability.GetHitType() == FormRune.HitType.Hit)
                snapshot.damage *= unit.totalStats.GlobalHitDamage_Damage_MultiplyPercent.value;
            else if (ability.GetHitType() == FormRune.HitType.DoT)
                snapshot.damage *= unit.totalStats.GlobalDoTDamage_Damage_MultiplyPercent.value;

            snapshot.damage *= ability.GetDamageMultipliers();


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
        ability.snapshot = snapshot;
        return snapshot;
    }

    public static void CalculateAbilityDefender(Guid DefenderID, BaseAbility ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(DefenderID).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        if (ability.harmful)
        {
            float total = ability.snapshot.damage;
            string school = ability.schoolRune.schoolRuneType.ToString();

            //total += ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_Flat", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_Flat", school)).GetValue(unit.totalStats)).value;
            total /= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_AddPercent", school)).GetValue(unit.totalStats)).value;
            total /= 1 + unit.totalStats.GlobalDamage_Resistance_AddPercent.value;

            unit.totalStats.Health_Current -= total;
            unit.ResolveHit(total, false);
        }

        if (ability.helpful)
        {
            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(ability.snapshot.calculatedHealing * 100) / 100;
            unit.totalStats.Health_Current += resolvedHealing;
            unit.ResolveHeal(resolvedHealing, false);

        }
    }

    public static void CalculateAbilityHazard(BaseAbility Ability)
    {
        Ability.snapshot.damage = Ability.snapshot.overrideDamage > -1 ? Ability.snapshot.overrideDamage : Ability.GetDamage();
    }

    public static void CalculateEnemyAbilityDefender(Guid DefenderID, float damage)
    {
        RootCharacter defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

        float resolvedDamage = Mathf.Round(damage * 100) / 100;
        defender.totalStats.Health_Current -= resolvedDamage;
        defender.ResolveHit(resolvedDamage, false);
    }

    public static void CalculateStatusDamage(RootCharacter unit, float totalStatusTick)
    {
        unit.totalStats.Health_Current += totalStatusTick;
        //unit.ResolveHit(totalStatusTick, true);
    }
}