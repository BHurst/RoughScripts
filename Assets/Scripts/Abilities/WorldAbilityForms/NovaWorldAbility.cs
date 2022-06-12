using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : _WorldAbilityForm
{

    void Start()
    {
        InitialCreation();
        if (ability.creation == BaseAbility.CreationMethod.Triggered)
        {

        }
        else if (ability.creation == BaseAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.formRune.formArea, transform.position, previousTargets, ability.formRune.formMaxAdditionalTargets);
        pS.transform.localScale = new Vector3(ability.formRune.formArea, ability.formRune.formArea, ability.formRune.formArea);
        //TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
            {
                if(target.unitID != ability.abilityOwner)
                {
                    if (ability.overrideHitToDot)
                        ApplyDoT(target);
                    else
                        ApplyHit(target);
                    if (ability.abilityToTrigger != null)
                        CreateTriggerAbility(target.transform.position, null, ability.ownerEntityType);
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