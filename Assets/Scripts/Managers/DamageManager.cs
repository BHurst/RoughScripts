using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static float CalculateAbilityAttacker(WorldAbility ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();
        RootCharacter attacker = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner);

        float total = 0;

        ability.increasedProjectileSpeed = (1 + unit.totalStats.Projectile_Rate_AddPercent.value) * unit.totalStats.Projectile_Rate_MultiplyPercent.value;
        ability.increasedArea = (1 + unit.totalStats.Ability_Area_AddPercent.value) * unit.totalStats.Ability_Area_MultiplyPercent.value;
        ability.increasedChains = unit.totalStats.Ability_Chains_Flat.value;
        ability.increasedProjectiles = unit.totalStats.Ability_Projectiles_Flat.value;

        if (ability.harmful)
        {
            total = ability.overrideDamage > -1 ? ability.overrideDamage : ability.wSchoolRune.GetDamage();
            string form = ability.wFormRune.formRuneType.ToString();
            string school = ability.wSchoolRune.schoolRuneType.ToString();

            total += (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(unit.totalStats)).value);
            total *= 1 + (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_Damage_AddPercent.value);
            total *= (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_Damage_MultiplyPercent.value);
            total *= ability.wFormRune.formDamageMod;
            total *= ability.overrideMultiplier;
            if (ability.wCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
                total *= unit.totalStats.Channel_Current;
            else if (ability.wCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
                total *= ((CastModeRune_Charge)ability.wCastModeRune).chargeAmount * (1 + unit.totalStats.Charge_Max_AddPercent.value);
            ability.calculatedDamage = total;
        }

        return total;
    }

    public static void CalculateAbilityDefender(Guid DefenderID, WorldAbility ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(DefenderID).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        if (ability.harmful)
        {
            float total = ability.calculatedDamage;
            string school = ability.wSchoolRune.schoolRuneType.ToString();

            //total += ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_Flat", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_Flat", school)).GetValue(unit.totalStats)).value;
            total /= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_Resistance_AddPercent", school)).GetValue(unit.totalStats)).value;
            total /= 1 + unit.totalStats.GlobalDamage_Resistance_AddPercent.value;

            unit.totalStats.Health_Current -= total;
            unit.ResolveHit(total, false);
        }

        if (ability.helpful)
        {
            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(ability.calculatedHealing * 100) / 100;
            unit.totalStats.Health_Current += resolvedHealing;
            unit.ResolveHeal(resolvedHealing, false);

        }
    }

    public static float TooltipAbilityDamage(UnitStats stats, Ability ability)
    {
        Type statsTF = stats.GetType();

        float total = ability.aSchoolRune.GetDamage();
        string form = ability.aFormRune.formRuneType.ToString();
        string school = ability.aSchoolRune.schoolRuneType.ToString();

        total += (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(stats)).value);
        total *= 1 + (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(stats)).value + stats.GlobalDamage_Damage_AddPercent.value);
        total *= (((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(stats)).value * stats.GlobalDamage_Damage_MultiplyPercent.value);
        total *= ability.aFormRune.formDamageMod;

        return MathF.Round(total * 100) / 100;
    }

    public static void CalculateAbilityHazard(WorldAbility Ability)
    {
        Ability.calculatedDamage = Ability.overrideDamage > -1 ? Ability.overrideDamage : Ability.wSchoolRune.GetDamage();
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