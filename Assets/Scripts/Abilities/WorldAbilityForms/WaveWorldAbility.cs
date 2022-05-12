using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference == null)
        {
            var temp = GameWorldReferenceClass.GetNewRootUnitInSphere(10, transform.position, wA.previousTargets, wA.wFormRune.formMaxTargets);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    FaceNewTarget(temp[i].transform);
                    i = temp.Count;
                }
            }
            else
                Obliterate();
        }
        else if (wA.creation == WorldAbility.CreationMethod.Triggered && wA.targetPreference != null)
        {

        }
        else
            FaceOwnerTarget();
    }

    public void Trigger(Collider collider)
    {
        RootCharacter target = collider.GetComponent<RootCharacter>();

        if (target != null && target.unitID != wA.abilityOwner && target.isAlive && !wA.previousTargets.Contains(target))
        {
            ApplyHit(target);
            wA.previousTargets.Add(target);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    private void Update()
    {
        skeleton.velocity = transform.forward * 10f;
        //Given an initial scale of 1,1,1: The float will be the the effective cumulative increase per second eg. 1 = 100%, 2 = 200%...
        var xScaleIncrease = 3.5f * Time.deltaTime;
        var yScaleIncrease = 0f * Time.deltaTime;
        var zScaleIncrease = 1.4f * Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x + xScaleIncrease, transform.localScale.y + yScaleIncrease, transform.localScale.z + zScaleIncrease);
        Tick();
    }
}