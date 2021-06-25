using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArcWorldAbility : _WorldAbilityForm
{
    int chainTargets = 2;

    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered)
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
        else
            PositionAtOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Arc_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Arc_Damage_Increase_Add * unit.totalStats.Arc_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(.1f, transform.position);
        Vector3 lastPos;

        if(targets.Count > 0)
        {
            wA.previousTargets.Add(targets[0].unitID);
            lastPos = targets[0].transform.position;
            TriggerParticleBurst(0);

            for (int jumps = 0; jumps < chainTargets; jumps++)
            {
                targets = GameWorldReferenceClass.GetInAreaRootUnit(8f, lastPos).OrderBy(x => (x.transform.position - lastPos).sqrMagnitude).ToList();
                for (int i = 0; i < targets.Count; i++)
                {
                    if(!wA.previousTargets.Contains(targets[i].unitID))
                    {
                        wA.previousTargets.Add(targets[i].unitID);
                        lastPos = targets[i].transform.position;
                        transform.position = lastPos;
                        TriggerParticleBurst(0);
                        i = targets.Count;
                    }
                }
            }

            foreach (Guid target in wA.previousTargets)
            {
                DamageManager.CalculateDamage(wA.abilityOwner, target, wA);
                if (wA.abilityToTrigger != null)
                    CreateTriggerAbility(GameWorldReferenceClass.GetUnitByID(target).transform.position, null);
            }

            Terminate();
        }
        else
        {
            Terminate();
        }
    }

    private void Update()
    {
        Trigger();
    }
}