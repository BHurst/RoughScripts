using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        var main = pS.main;
        main.startSpeed = 15f * wA.wFormRune.formArea / 10f;
        FaceOwnerTarget();
    }

    public void Trigger()
    {
        var areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position, transform.forward, wA.wFormRune.formArea, wA.previousTargets, wA.wFormRune.formMaxTargets, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).team);
        List<RootUnit> targetList = new List<RootUnit>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootUnit)))
                targetList.Add(target.GetComponent<RootUnit>());
        }

        foreach (RootUnit target in targetList)
        {
            ApplyHit(target);
        }
    }

    void Update()
    {
        if(wA.isTriggered)
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
        if(activationTimer > wA.wFormRune.formInterval)
        {
            Trigger();
            activationTimer = 0;
        }
        Tick();
    }
}