using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWorldAbility : BasicAbilityForm
{
    float activationTimer = 0;
    RaycastHit toGround;

    void Start()
    {
        InitialCreation();
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(ability.formRune.formArea, ability.formRune.formArea, 1);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * ability.formRune.formArea * 2);
        if (ability.creation == RootAbility.CreationMethod.UnitCast)
        {
            PositionAtOwnerTarget();
        }
        else if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }


        Physics.Raycast(transform.position + transform.up, Vector3.down, out toGround, 20, 1 << 9);
        transform.position = toGround.point;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0,1,0), ability.formRune.formArea, 1 << 8 | 1 << 12);
        List<RootCharacter> targetList = new List<RootCharacter>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootCharacter)) && target.GetComponent<RootCharacter>().isAlive)
                targetList.Add(target.GetComponent<RootCharacter>());
        }

        foreach (var target in targetList)
        {
            ApplyAreaDoT(target);
        }
    }

    private void Update()
    {
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.formRune.formInterval)
        {
            Trigger();
            activationTimer -= ability.formRune.formInterval;
        }
        Tick();
    }
}