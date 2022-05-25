using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        var main = pS.main;
        main.startSpeed = 15f * wA.wFormRune.formArea / 10f;
        if (wA.creation == WorldAbility.CreationMethod.Hazard)
        {

        }
        else
            FaceOwnerTarget();
    }

    public void Trigger()
    {
        var areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position, transform.forward, wA.wFormRune.formArea, wA.previousTargets, wA.wFormRune.formMaxAdditionalTargets, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).team);
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
        if (wA.creation == WorldAbility.CreationMethod.Triggered)
        {
            if (wA.targetPreference != null)
                transform.LookAt(wA.targetPreference);
        }
        else
        {
            FaceOwnerTarget();
            PositionAtOwnerCastLocation();
        }
        activationTimer += Time.deltaTime;
        if (activationTimer > wA.wFormRune.formInterval)
        {
            Trigger();
            activationTimer -= wA.wFormRune.formInterval;
        }
        Tick();
    }
}