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
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(wA.wFormRune.formArea, wA.wFormRune.formArea, 1);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * wA.wFormRune.formArea * 2);
        if (wA.creation == WorldAbility.CreationMethod.UnitCast)
        {
            PositionAtOwnerTarget();
        }
        else if (wA.creation == WorldAbility.CreationMethod.Hazard)
        {

        }


        Physics.Raycast(transform.position + transform.up, Vector3.down, out toGround, 20, 1 << 9);
        transform.position = toGround.point;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0,1,0), wA.wFormRune.formArea, 1 << 8 | 1 << 12);
        List<RootCharacter> targetList = new List<RootCharacter>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootCharacter)) && target.GetComponent<RootCharacter>().isAlive)
                targetList.Add(target.GetComponent<RootCharacter>());
        }

        foreach (var target in targetList)
        {
            ApplyDoT(target);
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