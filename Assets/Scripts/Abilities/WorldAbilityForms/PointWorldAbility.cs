using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
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
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, wA.previousTargets, wA.wFormRune.formMaxTargets);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            ApplyHit(targets[0]);
            wA.previousTargets.Add(targets[0]);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, wA.ownerEntityType);
            Terminate();
        }
        else
            Terminate();
    }
}