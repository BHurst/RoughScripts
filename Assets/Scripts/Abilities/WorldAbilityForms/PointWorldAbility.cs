using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered && wA.targetPreference != null)
        {
            PositionAtNewTarget(wA.targetPreference);
        }
        else if (wA.isTriggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwnerTarget();

        Trigger();
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(.1f, transform.position, wA.previousTargets);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            ApplyHit(targets[0]);
            wA.previousTargets.Add(targets[0]);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null);
            Terminate();
        }
        else
            Terminate();
    }
}