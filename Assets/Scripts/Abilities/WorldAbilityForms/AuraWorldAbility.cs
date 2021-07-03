using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval = .5f;
    float radius = 3f;
    float height;

    void Start()
    {
        duration = 15;
        InitialCreation();
        CalculateAttackerStats();
        height = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).size;
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(radius, radius, height);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * radius * 2);
        PositionAtOwner();
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0, height, 0), radius, 1 << 8 | 1 << 12);
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

    private void Update()
    {
        PositionAtOwner();
        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer = 0;
        }
        Tick();
    }
}