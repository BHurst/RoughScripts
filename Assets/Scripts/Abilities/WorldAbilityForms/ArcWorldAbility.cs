using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : BasicAbilityForm
{
    public ArcWorldAbility()
    {
        formType = FormType.None;
    }

    void Start()
    {
        TriggerParticleBurst(0);
        if (ability.creation == RootAbility.CreationMethod.Hazard)
        {
            PositionAtNewTarget(targetPreference);
        }
        if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, chaperone.previousTargets, 1);
        Vector3 lastPos;

        if (targets.Count > 0)
        {
            chaperone.previouslyTargeted.Add(targets[0]);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < ability.snapshot.chains; jumps++)
            {
                targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(ability.GetAsBasic().formRune.formArea * ability.snapshot.area, lastPos, chaperone.previouslyTargeted, 1, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).team);
                if (targets.Count > 0)
                {
                    chaperone.previouslyTargeted.Add(targets[0]);
                    lastPos = targets[0].transform.position;
                    transform.position = lastPos;
                    TriggerParticleBurst(0);
                }
            }

            foreach (RootCharacter target in chaperone.previouslyTargeted)
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