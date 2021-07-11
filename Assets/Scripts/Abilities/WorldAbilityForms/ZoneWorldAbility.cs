using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval = 1;
    float radius = 8;
    RaycastHit toGround;

    void Start()
    {
        duration = 8;
        InitialCreation();
        CalculateAttackerStats();
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(radius, radius, 1);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * radius * 2);
        if (wA.isTriggered && wA.targetPreference == null)
        {
            
        }
        else
            PositionAtOwnerTarget();

        Physics.Raycast(transform.position + transform.up, Vector3.down, out toGround, 20, ~(1 << 9));
        transform.position = toGround.point;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0,1,0), radius, 1 << 8 | 1 << 12);
        List<RootUnit> targetList = new List<RootUnit>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootUnit)) && target.GetComponent<RootUnit>().isAlive)
                targetList.Add(target.GetComponent<RootUnit>());
        }

        foreach (var target in targetList)
        {
            ApplyHit(target);
        }
    }

    private void Update()
    {
        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer -= interval;
        }
        Tick();
    }
}