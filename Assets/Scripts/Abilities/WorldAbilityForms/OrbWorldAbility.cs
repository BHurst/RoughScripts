using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWorldAbility : BasicAbilityForm
{
    void Start()
    {
        InitialCreation();
        if (ability.creation == RootAbility.CreationMethod.Triggered && !ability.predictProjectileLocation)
        {
            var temp = GameWorldReferenceClass.GetNewRootUnitInSphere(10, transform.position, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].unitID != ability.abilityOwner)
                    {
                        FaceNewTarget(temp[i].transform);
                        i = temp.Count;
                    }
                }
            }
            else
                Obliterate();
        }
        else if (ability.predictProjectileLocation)
        {
            FaceNewTarget(targetPreference);
        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            FaceOwnerTarget();
    }

    void Trigger(Collider collider)
    {
        var target = collider.transform.GetComponent<RootCharacter>();
        if (target != null)
        {
            if(ApplyHit(target))
            {
                if (ability.abilityToTrigger != null)
                    CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
                Terminate();
            }
        }
        else if (collider.gameObject.layer == 9)
            Terminate();
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    void Update()
    {
        skeleton.velocity = transform.forward * 15f;
        Tick();
    }
}