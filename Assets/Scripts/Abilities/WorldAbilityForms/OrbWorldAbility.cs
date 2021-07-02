using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 5;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered && wA.targetPreference == null)
        {
            var temp = GameWorldReferenceClass.GetInAreaRootUnit(10, transform.position);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if(!wA.previousTargets.Contains(temp[i].unitID) && temp[i].unitID != wA.abilityOwner)
                    {
                        FaceNewTarget(temp[i].transform);
                        i = temp.Count;
                    }
                }
            }
            else
                Obliterate();
        }
        else if(wA.isTriggered && wA.targetPreference != null)
        {

        }
        else
            FaceOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        DamageManager.CalculateAbilityAttacker(wA);
    }

    void Trigger(Collider collider)
    {
        var enemy = collider.transform.GetComponent<RootUnit>();
        if (enemy != null && !wA.previousTargets.Contains(enemy.unitID))
        {
            DamageManager.CalculateAbilityDefender(enemy.unitID, wA);
            if (wA.debuffRune != null)
                ApplyStatus(enemy);
            wA.previousTargets.Add(enemy.unitID);
            if(wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null);
            Terminate();
        }
        else if (collider.gameObject.layer == 9)
            Terminate();
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    void Update()
    {
        skeleton.velocity = transform.forward * 15f;
        Tick();
    }
}