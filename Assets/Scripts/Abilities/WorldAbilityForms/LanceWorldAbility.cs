using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 3;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered && wA.targetPreference == null)
        {
            var temp = GameWorldReferenceClass.GetInAreaRootUnit(10, transform.position);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (!wA.previousTargets.Contains(temp[i].unitID))
                    {
                        FaceNewTarget(temp[i].transform);
                        i = temp.Count;
                    }
                }
            }
            else
                Obliterate();
        }
        else if (wA.isTriggered && wA.targetPreference != null)
        {

        }
        else
            FaceOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Lance_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Lance_Damage_Increase_Add * unit.totalStats.Lance_Damage_Increase_Multiply;
    }

    void Trigger(Collider collider)
    {
        var enemy = collider.transform.GetComponent<RootUnit>();
        if (enemy != null)
        {
            DamageManager.CalculateDamage(wA.abilityOwner, enemy.unitID, wA);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null);
            Terminate();
        }
        else
            Terminate();
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    void Update()
    {
        skeleton.velocity = transform.forward * 150f;
        Tick();
    }
}