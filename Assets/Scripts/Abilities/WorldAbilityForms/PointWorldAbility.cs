using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : BasicAbilityForm
{
    void Start()
    {
        InitialCreation();
        if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(.1f, transform.position, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            ApplyHit(targets[0]);
            chaperone.previousTargets.Add(targets[0]);
            if (ability.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
            Terminate();
        }
        else
            Terminate();
    }
}