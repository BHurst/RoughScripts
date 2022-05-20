using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static void CalculateAbilityAttacker(WorldAbility Ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();
        RootCharacter attacker = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner);

        Ability.increasedProjectileSpeed = (1 + unit.totalStats.Projectile_Rate_AddPercent.value) * unit.totalStats.Projectile_Rate_MultiplyPercent.value;
        Ability.increasedArea = (1 + unit.totalStats.Ability_Area_AddPercent.value) * unit.totalStats.Ability_Area_MultiplyPercent.value;
        Ability.increasedChains = unit.totalStats.Ability_Chains_Flat.value;
        Ability.increasedProjectiles = unit.totalStats.Ability_Projectiles_Flat.value;

        if (Ability.harmful)
        {
            float total = Ability.overrideDamage > -1 ? Ability.overrideDamage : Ability.wSchoolRune.GetDamage();
            string form = Ability.wFormRune.formRuneType.ToString();
            string school = Ability.wSchoolRune.schoolRuneType.ToString();

            total += ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(unit.totalStats)).value;
            total *= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_Damage_AddPercent.value;
            total *= ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", form)).GetValue(unit.totalStats)).value * ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_Damage_MultiplyPercent.value;
            total *= Ability.wFormRune.formDamageMod;
            if (Ability.wCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
                total *= unit.totalStats.Channel_Current;
            Ability.calculatedDamage = total;
        }

        if (Ability.helpful)
        {
            float total = Ability.overrideDamage > -1 ? Ability.overrideDamage : Ability.wSchoolRune.GetDamage();

            //total += statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= 1 + statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= 1 + statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) * statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            Ability.calculatedHealing = total;
        }
    }

    public static void CalculateAbilityDefender(Guid DefenderID, WorldAbility Ability)
    {
        RootCharacter unit = GameWorldReferenceClass.GetUnitByID(DefenderID).GetComponent<RootCharacter>();
        Type statsTF = unit.totalStats.GetType();

        if (Ability.harmful)
        {
            float total = Ability.calculatedDamage;
            string form = Ability.wFormRune.formRuneType.ToString();
            string school = Ability.wSchoolRune.schoolRuneType.ToString();

            total += ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_Flat", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_Flat", school)).GetValue(unit.totalStats)).value;
            total *= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_AddPercent", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_DamageTaken_AddPercent.value;
            total *= ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_MultiplyPercent", form)).GetValue(unit.totalStats)).value * ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_DamageTaken_MultiplyPercent.value;

            unit.totalStats.Health_Current -= total;
            unit.ResolveHit(total, false);
        }

        if (Ability.helpful)
        {
            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(Ability.calculatedHealing * 100) / 100;
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

        total += ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", form)).GetValue(stats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(stats)).value;
        total *= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", form)).GetValue(stats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(stats)).value + stats.GlobalDamage_Damage_AddPercent.value;
        total *= ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", form)).GetValue(stats)).value * ((UnitStat)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(stats)).value * stats.GlobalDamage_Damage_MultiplyPercent.value;
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