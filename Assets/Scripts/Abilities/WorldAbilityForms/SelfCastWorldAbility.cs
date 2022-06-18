using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastWorldAbility : BasicAbilityForm
{
    public SelfCastWorldAbility()
    {
        formType = FormType.None;
    }

    void Start()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference != null)
        {

        }
        else if (ability.creation == RootAbility.CreationMethod.Triggered && targetPreference == null)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        var owner = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner);
        TriggerParticleBurst(0);
        ApplyHit(owner);
        if (ability.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
        Terminate();
    }
}