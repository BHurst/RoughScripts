using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        if (ability.creation == BaseAbility.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == BaseAbility.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else if (ability.creation == BaseAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, previousTargets, ability.formRune.formMaxAdditionalTargets);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            if (ability.overrideHitToDot)
                ApplyDoT(targets[0]);
            else
                ApplyHit(targets[0]);
            previousTargets.Add(targets[0]);
            if (ability.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
            Terminate();
        }
        else
            Terminate();
    }
}