using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : _WorldAbilityForm
{
    int chainTargets = 2;
    List<RootUnit> ChainGang = new List<RootUnit>();

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

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(.1f, transform.position, wA.previousTargets);
        Vector3 lastPos;

        if(targets.Count > 0)
        {
            wA.previousTargets.Add(targets[0]);
            ChainGang.Add(targets[0]);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < chainTargets; jumps++)
            {
                targets = GameWorldReferenceClass.GetInAreaRootUnit(8f, lastPos, wA.previousTargets).ToList();
                for (int i = 0; i < targets.Count; i++)
                {
                    if(targets[i].unitID != wA.abilityOwner)
                    {
                        wA.previousTargets.Add(targets[i]);
                        ChainGang.Add(targets[i]);
                        lastPos = targets[i].transform.position;
                        transform.position = lastPos;
                        TriggerParticleBurst(0);
                        i = targets.Count;
                    }
                }
            }

            foreach (RootUnit target in ChainGang)
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

    private void Update()
    {
        Trigger();
    }
}