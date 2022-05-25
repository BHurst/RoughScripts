using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : _WorldAbilityForm
{

    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        if (wA.creation == WorldAbility.CreationMethod.Triggered)
        {

        }
        else if (wA.creation == WorldAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(wA.wFormRune.formArea, transform.position, wA.previousTargets, wA.wFormRune.formMaxAdditionalTargets);
        pS.transform.localScale = new Vector3(wA.wFormRune.formArea, wA.wFormRune.formArea, wA.wFormRune.formArea);
        //TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
            {
                if(target.unitID != wA.abilityOwner)
                {
                    ApplyHit(target);
                    if (wA.abilityToTrigger != null)
                        CreateTriggerAbility(target.transform.position, null, wA.ownerEntityType);
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