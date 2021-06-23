using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 1;
        InitialCreation();
        CalculateAttackerStats();
        FaceOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Wave_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Wave_Damage_Increase_Add * unit.totalStats.Wave_Damage_Increase_Multiply;
    }

    public void Trigger(Collider collider)
    {
        var temp = collider.GetComponent<RootUnit>();

        if (temp != null && !wA.previousTargets.Contains(temp.unitID))
        {
            DamageManager.CalculateDamage(wA.abilityOwner, temp.unitID, wA);
            wA.previousTargets.Add(temp.unitID);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    private void Update()
    {
        skeleton.velocity = transform.forward * 10f;
        //Given an initial scale of 1,1,1: The float will be the the effective cumulative increase per second eg. 1 = 100%, 2 = 200%...
        var xScaleIncrease = 3.5f * Time.deltaTime;
        var yScaleIncrease = 0f * Time.deltaTime;
        var zScaleIncrease = 1.4f * Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x + xScaleIncrease, transform.localScale.y + yScaleIncrease, transform.localScale.z + zScaleIncrease);
        Tick();
    }
}