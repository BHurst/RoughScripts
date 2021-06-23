using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWorldAbility : _WorldAbilityForm
{
    float length;
    float width;
    float interval;
    float activationTimer = 0;
    void Start()
    {
        duration = 2;
        length = 10;
        width = 1;
        interval = .25f;
        InitialCreation();
        CalculateAttackerStats();
        var main = pS.main;
        main.startSpeed = 15f * length / 10f;
        FaceOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Beam_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Beam_Damage_Increase_Add * unit.totalStats.Beam_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        var areaTargets = Physics.OverlapCapsule(transform.position, transform.position + transform.forward * length, width, 1 << 8 | 1 << 12);
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

    void Update()
    {
        FaceOwnerTarget();
        PositionAtOwnerCastLocation();
        activationTimer += Time.deltaTime;
        if(activationTimer > interval)
        {
            Trigger();
            activationTimer = 0;
        }
        Tick();
    }
}