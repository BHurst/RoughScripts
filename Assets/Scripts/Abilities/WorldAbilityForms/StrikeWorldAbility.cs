using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        if (ability.creation == Ability.CreationMethod.Triggered && targetPreference != null)
        {
            PositionAtNewTarget(targetPreference);
        }
        else if (ability.creation == Ability.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else if (ability.creation == Ability.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.formRune.formArea, transform.position, previousTargets, ability.formRune.formMaxAdditionalTargets);
        TriggerParticleBurst(0);
        if(targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
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