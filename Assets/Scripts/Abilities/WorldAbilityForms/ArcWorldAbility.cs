using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : _WorldAbilityForm
{
    int chainTargets = 2;

    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        TriggerParticleBurst(0);
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

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Arc_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Arc_Damage_AddPercent * unit.totalStats.Arc_Damage_MultiplyPercent;
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(.1f, transform.position);
        Vector3 lastPos;

        if(targets.Count > 0)
        {
            wA.previousTargets.Add(targets[0].unitID);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < chainTargets; jumps++)
            {
                targets = GameWorldReferenceClass.GetInAreaRootUnit(8f, lastPos).ToList();
                for (int i = 0; i < targets.Count; i++)
                {
                    if(!wA.previousTargets.Contains(targets[i].unitID) && targets[i].unitID != wA.abilityOwner)
                    {
                        wA.previousTargets.Add(targets[i].unitID);
                        lastPos = targets[i].transform.position;
                        transform.position = lastPos;
                        TriggerParticleBurst(0);
                        i = targets.Count;
                    }
                }
            }

            foreach (Guid target in wA.previousTargets)
            {
                DamageManager.CalculateAbilityDefender(target, wA);
                if (wA.abilityToTrigger != null)
                    CreateTriggerAbility(GameWorldReferenceClass.GetUnitByID(target).transform.position, null);
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