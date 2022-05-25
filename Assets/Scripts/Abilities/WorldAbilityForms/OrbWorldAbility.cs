using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference == null)
        {
            var temp = GameWorldReferenceClass.GetNewRootUnitInSphere(10, transform.position, wA.previousTargets, wA.wFormRune.formMaxAdditionalTargets);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if(temp[i].unitID != wA.abilityOwner)
                    {
                        FaceNewTarget(temp[i].transform);
                        i = temp.Count;
                    }
                }
            }
            else
                Obliterate();
        }
        else if(wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference != null)
        {
            FaceNewTarget(wA.targetPreference);
        }
        else if (wA.creation == WorldAbility.CreationMethod.Hazard)
        {

        }
        else
            FaceOwnerTarget();
    }

    void Trigger(Collider collider)
    {
        var target = collider.transform.GetComponent<RootCharacter>();
        if (target != null && target.unitID != wA.abilityOwner && target.isAlive && !wA.previousTargets.Contains(target))
            {
            wA.previousTargets.Add(target);
            ApplyHit(target);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, wA.ownerEntityType);
            Terminate();
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