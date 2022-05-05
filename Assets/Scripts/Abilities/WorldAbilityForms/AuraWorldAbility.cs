using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float height;

    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        height = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).size;
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(wA.wFormRune.formArea, wA.wFormRune.formArea, height);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * wA.wFormRune.formArea * 2);
        PositionAtOwner();
    }

    public void Trigger()
    {
        var areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position - new Vector3(0, height/2*wA.increasedArea, 0), new Vector3(0, height/2*wA.increasedArea, 0), wA.wFormRune.formArea * wA.increasedArea, wA.previousTargets, wA.wFormRune.formMaxTargets, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).team);
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
        if (activationTimer > wA.wFormRune.formInterval)
        {
            Trigger();
            activationTimer = 0;
        }
        Tick();
    }
}