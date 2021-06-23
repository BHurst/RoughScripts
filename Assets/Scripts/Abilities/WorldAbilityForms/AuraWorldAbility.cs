using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval;
    float radius;
    float height;

    void Start()
    {
        duration = 15;
        radius = 3f;
        interval = .5f;
        InitialCreation();
        CalculateAttackerStats();
        height = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).size;
        var particleShape = pS.shape;
        particleShape.scale = new Vector3(radius, radius, height);
        var particleEmission = pS.emission;
        particleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(particleEmission.rateOverTime.constant * radius * 2);
        PositionAtOwner();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Aura_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Aura_Damage_Increase_Add * unit.totalStats.Aura_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0, height, 0), radius, 1 << 8 | 1 << 12);
        List<Guid> targetList = new List<Guid>();

        foreach (var target in areaTargets)
        {
            if (target.GetComponent(typeof(RootUnit)))
                targetList.Add(target.GetComponent<RootUnit>().unitID);
        }

        foreach (var targetID in targetList)
        {
            DamageManager.CalculateDamage(wA.abilityOwner, targetID, wA);
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