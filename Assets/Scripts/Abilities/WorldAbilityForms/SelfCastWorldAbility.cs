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
        if (wA.isTriggered && wA.targetPreference != null)
        {

        }
        else if (wA.isTriggered && wA.targetPreference == null)
        {

        }
        else
            PositionAtOwner();
    }

    void CalculateAttackerStats()
    {
        if (GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>())
        {
            var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<PlayerCharacterUnit>();
            if (wA.harmRune != null)
                wA.caculatedDamage = (wA.harmRune.damage + unit.totalStats.SelfCast_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.SelfCast_Damage_AddPercent * unit.totalStats.SelfCast_Damage_MultiplyPercent;
            if (wA.healRune != null)
                wA.caculatedHealing = (wA.healRune.healing + unit.totalStats.SelfCast_Damage_Flat) * wA.formRune.formDamageMod * unit.totalStats.SelfCast_Damage_AddPercent * unit.totalStats.SelfCast_Damage_MultiplyPercent;
        }
        else if (GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<NPCUnit>())
        {
            var unit = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).GetComponent<NPCUnit>();
            if (wA.harmRune != null)
                wA.caculatedDamage = wA.harmRune.damage;
            if (wA.healRune != null)
                wA.caculatedHealing = wA.healRune.healing;
        }

    }

    public void Trigger()
    {
        TriggerParticleBurst(0);
        DamageManager.CalculateAbilityDefender(wA.abilityOwner, wA);
        if (wA.specialEffect != null)
            wA.specialEffect.Effect(wA.abilityOwner);
        if (wA.abilityToTrigger != null)
            CreateTriggerAbility(transform.position, null);
        Terminate();
    }

    private void Update()
    {
        Trigger();
    }
}