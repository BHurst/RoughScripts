using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered && wA.targetPreference != null)
        {

        }
        else if (wA.isTriggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwner();
    }

    public void Trigger()
    {
        TriggerParticleBurst(0);
        ApplyHit(GameWorldReferenceClass.GetUnitByID(wA.abilityOwner));
        if (wA.specialEffect != null)
            wA.specialEffect.Effect(wA.abilityOwner);
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, null);
        Terminate();
    }

    private void Update()
    {
        Trigger();
    }
}