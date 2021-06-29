using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandWorldAbility : _WorldAbilityForm
{
    float activationTimer = 0;
    float interval;

    void Start()
    {
        duration = 15;
        interval = 3;
        InitialCreation();
        CalculateAttackerStats();
        PositionAtOwnerTarget();
        transform.position += new Vector3(0,1,0);
        var someNew = GameWorldReferenceClass.GetInAreaRootUnit(25, transform.position);
        for (int i = 0; i < someNew.Count; i++)
        {
            if (someNew[i].unitID != wA.abilityOwner)
            {
                wA.targetPreference = someNew[i].transform;
                i = someNew.Count;
            }

        }
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Zone_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Zone_Damage_AddPercent * unit.totalStats.Zone_Damage_MultiplyPercent;
    }

    public void Trigger()
    {
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, wA.targetPreference);
    }

    private void Update()
    {
        if (wA.targetPreference != null)
            transform.LookAt(wA.targetPreference);

        activationTimer += Time.deltaTime;
        if (activationTimer > interval)
        {
            Trigger();
            activationTimer -= interval;
        }
        Tick();
    }
}