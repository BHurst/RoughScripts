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
        duration = 1;
        InitialCreation();
        CalculateAttackerStats();
        bC = GetComponent<BoxCollider>();
        weaponModel = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).mainhandWeapon;
        transform.position = weaponModel.position;
        transform.rotation = weaponModel.rotation;
        bC.center = weaponModel.GetComponent<BoxCollider>().center;
        bC.size = weaponModel.GetComponent<BoxCollider>().size;
    }

    public void Trigger(Collider collider)
    {
        RootUnit target = collider.GetComponent<RootUnit>();

        if (target != null && !wA.previousTargets.Contains(target))
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
        transform.position = weaponModel.position;
        transform.rotation = weaponModel.rotation;

        Tick();
    }
}