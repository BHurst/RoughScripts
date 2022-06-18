using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : BasicAbilityForm
{
    public NovaWorldAbility()
    {
        formType = FormType.Area;
    }

    void Start()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered)
        {

        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwner();

        Trigger();
    }

    public void Trigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.GetAsBasic().formRune.formArea, transform.position, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets);
        pS.transform.localScale = new Vector3(ability.GetAsBasic().formRune.formArea, ability.GetAsBasic().formRune.formArea, ability.GetAsBasic().formRune.formArea);
        //TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
            {
                if(target.unitID != ability.abilityOwner)
                {
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