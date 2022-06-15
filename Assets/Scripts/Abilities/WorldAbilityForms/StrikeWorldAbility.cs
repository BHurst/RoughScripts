using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : BasicAbilityForm
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
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.formRune.formArea, transform.position, chaperone.previousTargets, ability.formRune.formMaxAdditionalTargets);
        TriggerParticleBurst(0);
        if(targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
            {
                if (ability.createdWithStatus)
                    ApplyDoT(target);
                else
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