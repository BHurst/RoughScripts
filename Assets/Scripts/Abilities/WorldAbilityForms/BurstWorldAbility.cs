using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWorldAbility : BasicAbilityForm
{
    float activationTimer = 0;
    void Start()
    {
        InitialCreation();
        var main = pS.main;
        main.startSpeed = 15f * ability.GetAsBasic().formRune.formArea / 10f;
        if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            FaceOwnerTarget();
    }

    public void Trigger()
    {
        var areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position, transform.forward, ability.GetAsBasic().formRune.formArea, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).team);
        List<RootCharacter> targetList = new List<RootCharacter>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootCharacter)))
                targetList.Add(target.GetComponent<RootCharacter>());
        }

        foreach (RootCharacter target in targetList)
        {
            ApplyHit(target);
        }
    }

    void Update()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered)
        {
            if (targetPreference != null)
                transform.LookAt(targetPreference);
        }
        else
        {
            FaceOwnerTarget();
            PositionAtOwnerCastLocation();
        }
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.GetAsBasic().formRune.formInterval)
        {
            Trigger();
            activationTimer -= ability.GetAsBasic().formRune.formInterval;
        }
        Tick();
    }
}