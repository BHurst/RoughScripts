using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWorldAbility : _WorldAbilityForm
{
    float length = 10;
    float width = 1;
    float interval = .25f;
    float activationTimer = 0;
    void Start()
    {
        duration = 2;
        InitialCreation();
        CalculateAttackerStats();
        var main = pS.main;
        main.startSpeed = 15f * length / 10f;
        FaceOwnerTarget();
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + transform.forward * length, width, 1 << 8 | 1 << 12);
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
        if(activationTimer > interval)
        {
            Trigger();
            activationTimer = 0;
        }
        Tick();
    }
}