using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : _WorldAbilityForm
{

    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetNewRootUnitInArea(5f, transform.position, wA.previousTargets, wA.wFormRune.maxTargets);
        pS.transform.localScale = new Vector3(wA.wFormRune.formArea, wA.wFormRune.formArea, wA.wFormRune.formArea);
        //TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootUnit target in targets)
            {
                if(target.unitID != wA.abilityOwner)
                {
                    ApplyHit(target);
                    if (wA.abilityToTrigger != null)
                        CreateTriggerAbility(target.transform.position, null);
                }
            }
            Terminate();
        }
        else
        {
            Terminate();
        }
    }
}