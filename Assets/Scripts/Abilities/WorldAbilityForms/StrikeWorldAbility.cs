using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : _WorldAbilityForm
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
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(2f, transform.position, wA.previousTargets);
        TriggerParticleBurst(0);
        if(targets.Count > 0)
        {
            foreach (RootUnit target in targets)
            {
                ApplyHit(target);
                if (wA.abilityToTrigger != null)
                    CreateTriggerAbility(target.transform.position, null);
            }
            Terminate();
        }
        else
        {
            Terminate();
        }
    }

    private void Update()
    {
        Trigger();
    }
}