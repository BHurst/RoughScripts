using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastWorldAbility : _WorldAbilityForm
{
    void Start()
    {
        duration = 0;
        InitialCreation();
        CalculateAttackerStats();
        PositionAtOwner();
    }

    void CalculateAttackerStats()
    {
        var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();

        wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.SelfCast_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.SelfCast_Damage_Increase_Add * unit.totalStats.SelfCast_Damage_Increase_Multiply;
    }

    public void Trigger()
    {
        TriggerParticleBurst(0);
        DamageManager.CalculateDamage(wA.abilityOwner, wA.abilityOwner, wA);
        if (wA.specialEffect != null)
            wA.specialEffect.Effect(wA.abilityOwner);
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position);
        Terminate();
    }

    private void Update()
    {
        Trigger();
    }
}