using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWorldAbility : BasicAbilityForm
{
    float activationTimer = 0;
    RaycastHit toGround;

    public ZoneWorldAbility()
    {
        formType = FormType.Area;
        activationTimer = 0;
    }

    void Start()
    {
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(ability.snapshot.area, ability.snapshot.area, 1);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * ability.GetAsBasic().formRune.formArea * 2);
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

    

    private void Update()
    {
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.GetAsBasic().formRune.formInterval)
        {
            PersistentAreaTrigger();
            activationTimer -= ability.GetAsBasic().formRune.formInterval;
        }
        Tick();
    }
}