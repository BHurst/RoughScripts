using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public static void CalculateAbilityAttacker(WorldAbility Ability)
    {
        var unit = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner).GetComponent<PlayerCharacterUnit>();
        var statsTF = unit.totalStats.GetType();
        RootUnit attacker = GameWorldReferenceClass.GetUnitByID(Ability.abilityOwner);

        if (Ability.harmRune != null)
        {
            float total = Ability.harmRune.damage;

            total += (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            total *= 1 + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats) + unit.totalStats.GlobalDamage_Damage_AddPercent;
            total *= (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) * (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats) * unit.totalStats.GlobalDamage_Damage_MultiplyPercent;
            Ability.caculatedDamage = total;
        }

        if (Ability.healRune != null)
        {
            float total = Ability.healRune.healing;

            //total += (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_Flat", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= 1 + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) + (float)statsTF.GetField(string.Format("{0}_Damage_AddPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            //total *= (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.formRune.form.ToString())).GetValue(unit.totalStats) * (float)statsTF.GetField(string.Format("{0}_Damage_MultiplyPercent", Ability.schoolRunes[0].school.ToString())).GetValue(unit.totalStats);
            Ability.caculatedHealing = total;
        }
    }

    public static void CalculateAbilityDefender(Guid DefenderID, WorldAbility Ability)
    {
        if (Ability.harmRune != null)
        {
                RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

                float resolvedDamage = Mathf.Round(Ability.caculatedDamage * 100) / 100;
                defender.unitHealth -= resolvedDamage;
                Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
                defender.ResolveHit(resolvedDamage, false);
        }

        if (Ability.healRune != null)
        {
            RootUnit defender = GameWorldReferenceClass.GetUnitByID(DefenderID);

            //DamageHitInfo hitInfo = new DamageHitInfo();
            float resolvedHealing = Mathf.Round(Ability.caculatedHealing * 100) / 100;
            defender.unitHealth += resolvedHealing;
            Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
            defender.ResolveHeal(resolvedHealing);

        }
    }

    public static void CalculateStatusDamage(RootUnit unit, float totalStatusTick)
    {
        unit.unitHealth += totalStatusTick;
        Mathf.Clamp(unit.unitHealth, 0, unit.unitMaxHealth);
        //unit.ResolveHit(totalStatusTick, true);
    }
}