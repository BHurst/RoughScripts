using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeWorldAbility : _WorldAbilityForm
{
    void Start()
    {
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
        List<RootUnit> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(wA.wFormRune.formArea, transform.position, wA.previousTargets, wA.wFormRune.formMaxTargets);
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
}