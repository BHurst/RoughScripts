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
        if(ability.creation == Ability.CreationMethod.Hazard)
        {
            PositionAtNewTarget(targetPreference);
        }
        if (ability.creation == Ability.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == Ability.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, previousTargets, 1);
        Vector3 lastPos;

        if (targets.Count > 0)
        {
            previousTargets.Add(targets[0]);
            chainGang.Add(targets[0]);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < ability.formRune.formMaxAdditionalTargets + ability.increasedChains; jumps++)
            {
                targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(ability.formRune.formArea * ability.increasedArea, lastPos, previousTargets, 1, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).team);
                if(targets.Count > 0)
                {
                    previousTargets.Add(targets[0]);
                    chainGang.Add(targets[0]);
                    lastPos = targets[0].transform.position;
                    transform.position = lastPos;
                    TriggerParticleBurst(0);
                }
            }

            foreach (RootCharacter target in chainGang)
            {
                ApplyHit(target);
                if (ability.abilityToTrigger != null)
                    CreateTriggerAbility(target.transform.position, null, ability.ownerEntityType);
            }

            Terminate();
        }
        else
        {
            Terminate();
        }
    }
}