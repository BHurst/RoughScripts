using System;
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

        if (Ability.harmRune != null && Ability.harmRune.active)
        {
            float total = Ability.harmRune.Value();
            string form = Ability.formRune.form.ToString();
            string school = Ability.schoolRune.school.ToString();

            total += (float)statsTF.GetField(string.Format("{0}_Damage_Flat", form)).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_Flat", school)).GetValue(unit.totalStats);
            total *= 1 + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", form)).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", school)).GetValue(unit.totalStats) + unit.totalStats.GlobalDamage_Damage_AddPercent;
            total *= (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", form)).GetValue(unit.totalStats) * (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", school)).GetValue(unit.totalStats) * unit.totalStats.GlobalDamage_Damage_MultiplyPercent;
            Ability.calculatedDamage = total;
        }

        if (Ability.healRune != null && Ability.healRune.active)
        {
            float total = Ability.healRune.Value();

            //total += (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= 1 + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) * (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            Ability.calculatedHealing = total;
        }
    }

    public static void CalculateAbilityDefender(Guid DefenderID, WorldAbility Ability)
    {
        if (Ability.harmRune != null && Ability.harmRune.active)
        {
            RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

            float resolvedDamage = Mathf.Round(Ability.calculatedDamage * 100) / 100;
            defender.unitHealth -= resolvedDamage;
            Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
            defender.ResolveHit(resolvedDamage, false);
        }

        if (Ability.healRune != null && Ability.healRune.active)
        {
            RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(Ability.calculatedHealing * 100) / 100;
            defender.unitHealth += resolvedHealing;
            Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
            defender.ResolveHeal(resolvedHealing);

        }
    }

    public static void CalculateEnemyAbilityDefender(Guid DefenderID, float damage)
    {
        RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

        float resolvedDamage = Mathf.Round(damage * 100) / 100;
        defender.unitHealth -= resolvedDamage;
        Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
        defender.ResolveHit(resolvedDamage, false);
    }

    public static void CalculateStatusDamage(RootUnit unit, float totalStatusTick)
    {
        unit.unitHealth += totalStatusTick;
        Mathf.Clamp(unit.unitHealth, 0, unit.unitMaxHealth);
        //unit.ResolveHit(totalStatusTick, true);
    }
}