using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : _WorldAbilityForm
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
        else if (wA.creation == WorldAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(wA.wFormRune.formArea, transform.position, wA.previousTargets, wA.wFormRune.formMaxAdditionalTargets);
        TriggerParticleBurst(0);
        if(targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
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