using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval = 3;

    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        PositionAtOwnerTarget();
        transform.position += new Vector3(0,1,0);
        var someNew = GameWorldReferenceClass.GetNewRootUnitInSphere(wA.wFormRune.formArea, transform.position, wA.previousTargets, wA.wFormRune.formMaxTargets);
        for (int i = 0; i < someNew.Count; i++)
        {
            if (someNew[i].unitID != wA.abilityOwner)
            {
                wA.targetPreference = someNew[i].transform;
                i = someNew.Count;
            }

        }
    }

    public void Trigger()
    {
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, wA.targetPreference);
    }

    private void Update()
    {
        if (wA.targetPreference != null)
            transform.LookAt(wA.targetPreference);

        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer -= interval;
        }
        Tick();
    }
}