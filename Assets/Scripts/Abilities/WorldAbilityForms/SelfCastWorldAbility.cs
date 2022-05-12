using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference != null)
        {

        }
        else if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        var owner = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner);
        TriggerParticleBurst(0);
        ApplyHit(owner);
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, null, wA.ownerEntityType);
        Terminate();
    }
}