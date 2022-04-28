using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    RaycastHit toGround;

    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(wA.wFormRune.formArea, wA.wFormRune.formArea, 1);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * wA.wFormRune.formArea * 2);
        if (wA.isTriggered && wA.targetPreference == null)
        {
            
        }
        else
            PositionAtOwnerTarget();

        Physics.Raycast(transform.position + transform.up, Vector3.down, out toGround, 20, 1 << 9);
        transform.position = toGround.point;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0,1,0), wA.wFormRune.formArea, 1 << 8 | 1 << 12);
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
        if (activationTimer > wA.wFormRune.formInterval)
        {
            Trigger();
            activationTimer -= wA.wFormRune.formInterval;
        }
        Tick();
    }
}