using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval;
    float radius;
    RaycastHit toGround;

    void Start()
    {
        duration = 8;
        radius = 8f;
        interval = 1;
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

        Physics.Raycast(transform.position, Vector3.down, out toGround, 20, 1 << 9);
        transform.position = toGround.point;
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Zone_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Zone_Damage_AddPercent * unit.totalStats.Zone_Damage_MultiplyPercent;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + new Vector3(0,1,0), radius, 1 << 8 | 1 << 12);
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
        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer -= interval;
        }
        Tick();
    }
}