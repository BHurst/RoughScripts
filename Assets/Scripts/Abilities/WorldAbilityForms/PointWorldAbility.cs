using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        PositionAtOwnerTarget();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Point_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Point_Damage_Increase_Add * unit.totalStats.Point_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(.1f, transform.position);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            DamageManager.CalculateDamage(wA.abilityOwner, targets[0].unitID, wA);
            wA.previousTargets.Add(targets[0].unitID);
            if (wA.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null);
            Terminate();
        }
        else
            Terminate();
    }

    private void Update()
    {
        Trigger();
    }
}