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
            var temp = GameWorldReferenceClass.GetInAreaRootUnit(10, transform.position, wA.previousTargets);
            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].unitID != wA.abilityOwner)
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

    void Trigger(Collider collider)
    {
        var target = collider.transform.GetComponent<RootUnit>();
        if (target != null && target.unitID != wA.abilityOwner && target.isAlive && !wA.previousTargets.Contains(target))
        {
            ApplyHit(target);
            wA.previousTargets.Add(target);
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