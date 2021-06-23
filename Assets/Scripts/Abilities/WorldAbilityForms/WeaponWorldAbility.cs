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

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Weapon_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Weapon_Damage_Increase_Add * unit.totalStats.Weapon_Damage_Increase_Multiply;
    }

    public void Trigger(Collider collider)
    {
        var temp = collider.GetComponent<RootUnit>();

        if (temp != null && !wA.previousTargets.Contains(temp.unitID))
        {
            DamageManager.CalculateDamage(wA.abilityOwner, temp.unitID, wA);
            wA.previousTargets.Add(temp.unitID);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position);
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