using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandWorldAbility : BasicAbilityForm
{
    float activationTimer = 0;
    float interval = 3;

    void Start()
    {
        InitialCreation();
        PositionAtOwnerTarget();
        transform.position += new Vector3(0,1,0);
        var someNew = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.GetAsBasic().formRune.formArea, transform.position, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets);
        for (int i = 0; i < someNew.Count; i++)
        {
            if (someNew[i].unitID != ability.abilityOwner)
            {
                targetPreference = someNew[i].transform;
                i = someNew.Count;
            }

        }
    }

    public void Trigger()
    {
        if (ability.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, targetPreference, ability.ownerEntityType);
    }

    private void Update()
    {
        if (targetPreference != null)
            transform.LookAt(targetPreference);

        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer -= interval;
        }
        Tick();
    }
}