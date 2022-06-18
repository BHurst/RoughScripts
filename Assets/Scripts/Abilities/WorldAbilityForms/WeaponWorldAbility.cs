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

    public void Trigger(Collider collider)
    {
        RootCharacter target = collider.GetComponent<RootCharacter>();

        if (target != null)
        {
            ApplyHit(target);
            chaperone.previousTargets.Add(target);
            if (ability.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
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