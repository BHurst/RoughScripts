using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : _WorldAbilityForm
{
    List<RootUnit> chainGang = new List<RootUnit>();

    void Start()
    {
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

        Trigger();
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, wA.previousTargets, 1);
        Vector3 lastPos;

        if (targets.Count > 0)
        {
            wA.previousTargets.Add(targets[0]);
            chainGang.Add(targets[0]);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 1; jumps < wA.wFormRune.formMaxTargets; jumps++)
            {
                targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(wA.wFormRune.formArea, lastPos, wA.previousTargets, 1, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).team);
                if(targets.Count > 0)
                {
                    wA.previousTargets.Add(targets[0]);
                    chainGang.Add(targets[0]);
                    lastPos = targets[0].transform.position;
                    transform.position = lastPos;
                    TriggerParticleBurst(0);
                }
            }

            foreach (RootUnit target in chainGang)
            {
                ApplyHit(target);
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
}