using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraWorldAbility : BasicAbilityForm
{
    float activationTimer;
    float height;

    public AuraWorldAbility()
    {
        formType = FormType.Area;
        activationTimer = 0;
    }

    void Start()
    {
        height = GameWorldReferenceClass.GetUnitByID(ability.GetAsBasic().abilityOwner).size;
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(ability.GetAsBasic().formRune.formArea, ability.GetAsBasic().formRune.formArea, height);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * ability.GetAsBasic().formRune.formArea * 2);
        if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            PositionAtOwner();
    }

    private void Update()
    {
        PositionAtOwner();
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.GetAsBasic().formRune.formInterval)
        {
            PersistentAreaTrigger();
            activationTimer -= ability.GetAsBasic().formRune.formInterval;
        }
        Tick();
    }
}