using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : _WorldAbilityForm
{
    List<RootCharacter> chainGang = new List<RootCharacter>();

    void Start()
    {
        InitialCreation();
        TriggerParticleBurst(0);
        if(wA.creation == WorldAbility.CreationMethod.Hazard)
        {
            PositionAtNewTarget(wA.targetPreference);
        }
        if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference != null)
        {
            PositionAtNewTarget(wA.targetPreference);
        }
        else if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, wA.previousTargets, 1);
        Vector3 lastPos;

        if (targets.Count > 0)
        {
            wA.previousTargets.Add(targets[0]);
            chainGang.Add(targets[0]);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < wA.wFormRune.formMaxAdditionalTargets + wA.increasedChains; jumps++)
            {
                targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(wA.wFormRune.formArea * wA.increasedArea, lastPos, wA.previousTargets, 1, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).team);
                if(targets.Count > 0)
                {
                    wA.previousTargets.Add(targets[0]);
                    chainGang.Add(targets[0]);
                    lastPos = targets[0].transform.position;
                    transform.position = lastPos;
                    TriggerParticleBurst(0);
                }
            }

            foreach (RootCharacter target in chainGang)
            {
                ApplyHit(target);
                if (wA.abilityToTrigger != null)
                    CreateTriggerAbility(target.transform.position, null, wA.ownerEntityType);
            }

            Terminate();
        }
        else
        {
            Terminate();
        }
    }
}