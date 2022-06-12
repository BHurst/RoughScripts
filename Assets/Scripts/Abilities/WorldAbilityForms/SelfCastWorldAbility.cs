using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        if (ability.creation == BaseAbility.CreationMethod.Triggered && targetPreference != null)
        {

        }
        else if (ability.creation == BaseAbility.CreationMethod.Triggered && targetPreference == null)
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
        if (ability.overrideHitToDot)
            ApplyDoT(owner);
        else
            ApplyHit(owner);
        if (ability.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
        Terminate();
    }
}