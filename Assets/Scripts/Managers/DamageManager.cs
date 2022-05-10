﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static void CalculateAbilityAttacker(WorldAbility Ability)
    {
        RootUnit unit = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner).GetComponent<RootUnit>();
        Type statsTF = unit.totalStats.GetType();
        RootUnit attacker = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner);

        Ability.increasedProjectileSpeed = (1 + unit.totalStats.Projectile_Speed_AddPercent.value) * unit.totalStats.Projectile_Speed_MultiplyPercent.value;
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
            Ability.calculatedDamage = total;
        }

        if (Ability.helpful)
        {
            float total = Ability.overrideDamage > -1 ? Ability.overrideDamage : Ability.wSchoolRune.GetDamage();

            //total += (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= 1 + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) * (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            Ability.calculatedHealing = total;
        }
    }

    public static void CalculateAbilityDefender(Guid DefenderID, WorldAbility Ability)
    {
        RootUnit unit = GameWorldReferenceClass.GetUnitByID(DefenderID).GetComponent<RootUnit>();
        Type statsTF = unit.totalStats.GetType();

        if (Ability.harmful)
        {
            float total = Ability.calculatedDamage;
            string form = Ability.wFormRune.formRuneType.ToString();
            string school = Ability.wSchoolRune.schoolRuneType.ToString();

            total += ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_Flat", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_Flat", school)).GetValue(unit.totalStats)).value;
            total *= 1 + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_AddPercent", form)).GetValue(unit.totalStats)).value + ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_AddPercent", school)).GetValue(unit.totalStats)).value + unit.totalStats.GlobalDamage_DamageTaken_AddPercent.value;
            total *= ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_MultiplyPercent", form)).GetValue(unit.totalStats)).value * ((UnitStat)statsTF.GetField(string.Format("{0}_DamageTaken_MultiplyPercent", school)).GetValue(unit.totalStats)).value * unit.totalStats.GlobalDamage_DamageTaken_MultiplyPercent.value;

            float resolvedDamage = Mathf.Round(total * 100) / 100;
            unit.totalStats.Health_Current.value -= resolvedDamage;
            unit.ResolveHit(resolvedDamage, false);
        }

        if (Ability.helpful)
        {
            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(Ability.calculatedHealing * 100) / 100;
            unit.totalStats.Health_Current.value += resolvedHealing;
            unit.ResolveHeal(resolvedHealing);

        }
    }

    public static void CalculateEnemyAbilityDefender(Guid DefenderID, float damage)
    {
        RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

        float resolvedDamage = Mathf.Round(damage * 100) / 100;
        defender.totalStats.Health_Current.value -= resolvedDamage;
        defender.ResolveHit(resolvedDamage, false);
    }

    public static void CalculateStatusDamage(RootUnit unit, float totalStatusTick)
    {
        unit.totalStats.Health_Current.value += totalStatusTick;
        //unit.ResolveHit(totalStatusTick, true);
    }
}