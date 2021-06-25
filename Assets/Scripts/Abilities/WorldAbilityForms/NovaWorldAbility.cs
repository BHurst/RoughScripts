using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaWorldAbility : _WorldAbilityForm
{

    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        if (wA.isTriggered)
        {

        }
        else
            PositionAtOwner();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.Nova_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.Nova_Damage_Increase_Add * unit.totalStats.Nova_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        List<RootUnit> targets = GameWorldReferenceClass.GetInAreaRootUnit(5f, transform.position);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootUnit target in targets)
            {
                if(target.unitID != wA.abilityOwner)
                {
                    DamageManager.CalculateDamage(wA.abilityOwner, target.unitID, wA);
                    if (wA.abilityToTrigger != null)
                        CreateTriggerAbility(target.transform.position, null);
                }
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