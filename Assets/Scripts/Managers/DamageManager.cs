using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{

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
                float resolvedDamage = Mathf.Round(Ability.caculatedDamage * 100) / 100;
                defender.unitHealth -= resolvedDamage;
                Mathf.Clamp(defender.unitHealth, 0, defender.unitMaxHealth);
                defender.ResolveHit(resolvedDamage, false);
            }
        }

        if (Ability.healRune != null)
        {
            //RootUnit attacker = GameWorldReferenceClass.GetUnitByID(AttackerID);
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