using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWorldAbility : _WorldAbilityForm
{
    BoxCollider bC;
    public Transform weaponModel;

    void Start()
    {
        InitialCreation();
        CalculateAttackerStats();
        bC = GetComponent<BoxCollider>();
        weaponModel = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).mainhandWeapon;
        transform.SetPositionAndRotation(weaponModel.position, weaponModel.rotation);
        bC.center = weaponModel.GetComponentInChildren<BoxCollider>().center;
        bC.size = weaponModel.GetComponentInChildren<BoxCollider>().size;
    }

    public void Trigger(Collider collider)
    {
        RootUnit target = collider.GetComponent<RootUnit>();

        if (target != null && target.unitID != wA.abilityOwner && target.isAlive && !wA.previousTargets.Contains(target))
        {
            ApplyHit(target);
            wA.previousTargets.Add(target);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    private void Update()
    {
        transform.SetPositionAndRotation(weaponModel.position, weaponModel.rotation);

        Tick();
    }
}