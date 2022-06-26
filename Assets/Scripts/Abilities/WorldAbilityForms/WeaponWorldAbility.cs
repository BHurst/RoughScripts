using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWorldAbility : BasicAbilityForm
{
    BoxCollider bC;
    public Transform weaponModel;

    public WeaponWorldAbility()
    {
        formType = FormType.None;
    }

    void Start()
    {
        bC = GetComponent<BoxCollider>();
        weaponModel = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).mainhandWeapon;
        transform.SetPositionAndRotation(weaponModel.position, weaponModel.rotation);
        bC.center = weaponModel.GetComponentInChildren<BoxCollider>().center;
        bC.size = weaponModel.GetComponentInChildren<BoxCollider>().size;
    }

    void OnTriggerEnter(Collider collider)
    {
        CollisionTrigger(collider);
    }

    private void Update()
    {
        transform.SetPositionAndRotation(weaponModel.position, weaponModel.rotation);

        Tick();
    }
}