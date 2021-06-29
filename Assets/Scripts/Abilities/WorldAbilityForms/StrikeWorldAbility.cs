using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered && wA.targetPreference != null)
        {
            PositionAtNewTarget(wA.targetPreference);
        }
        else if (wA.isTriggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Strike_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Strike_Damage_AddPercent * unit.totalStats.Strike_Damage_MultiplyPercent;
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(2f, transform.position);
        TriggerParticleBurst(0);
        if(targets.Count > 0)
        {
            foreach (RootUnit target in targets)
            {
                DamageManager.CalculateDamage(wA.abilityOwner, target.unitID, wA);
                if (wA.abilityToTrigger != null)
                    CreateTriggerAbility(target.transform.position, null);
            }
            Terminate();
        }
        else
        {
            Terminate();
        }
    }

    private void Update()
    {
        Trigger();
    }
}