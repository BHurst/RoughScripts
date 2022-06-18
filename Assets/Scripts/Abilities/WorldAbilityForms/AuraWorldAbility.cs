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

    public void Trigger()
    {
        var areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position - new Vector3(0, height / 2 * ability.snapshot.area, 0), new Vector3(0, height / 2 * ability.snapshot.area, 0), ability.GetAsBasic().formRune.formArea * ability.snapshot.area, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).team);
        List<RootCharacter> targetList = new List<RootCharacter>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootCharacter)))
                targetList.Add(target.GetComponent<RootCharacter>());
        }

        foreach (RootCharacter target in targetList)
        {
            ApplyAreaDoT(target);
        }
    }

    private void Update()
    {
        PositionAtOwner();
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.GetAsBasic().formRune.formInterval)
        {
            Trigger();
            activationTimer -= ability.GetAsBasic().formRune.formInterval;
        }
        Tick();
    }
}