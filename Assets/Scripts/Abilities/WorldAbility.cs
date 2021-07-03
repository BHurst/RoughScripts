using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAbility : MonoBehaviour
{
    public Guid worldAbilityID;
    public Guid abilityOwner;
    public string worldAbilityName;
    public FormRune formRune;
    public CastModeRune castModeRune;
    public Buff_Rune buffRune;
    public Debuff_Rune debuffRune;
    public Harm_Rune harmRune;
    public Heal_Rune healRune;
    public SchoolRune schoolRune;
    public ISpecialEffect specialEffect;
    public Ability abilityToTrigger;
    public bool isTriggered = false;
    public List<RootUnit> previousTargets = new List<RootUnit>();
    public float calculatedDamage = 0;
    public float calculatedHealing = 0;
    public Transform targetPreference;

    public void AffectTarget(Guid target)
    {
        DamageManager.CalculateAbilityDefender(abilityOwner, this);
    }

    internal void Construct(Ability ability, Guid owner)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        formRune = ability.formRune;
        if (ability.buffRune != null && ability.buffRune.active)
        {
            buffRune = ability.buffRune;
            buffRune.active = true;
        }
        if (ability.debuffRune != null && ability.debuffRune.active)
        {
            debuffRune = ability.debuffRune;
            debuffRune.active = true;
        }
        if (ability.harmRune != null && ability.harmRune.active)
        {
            harmRune = ability.harmRune;
            harmRune.active = true;
        }
        if (ability.healRune != null && ability.healRune.active)
        {
            healRune = ability.healRune;
            healRune.active = true;
        }
        schoolRune = ability.schoolRune;
        specialEffect = ability.specialEffect;
        if (ability.abilityToTrigger != null && UtilityService.CanFormTriggerForm(formRune.form, ability.abilityToTrigger.formRune.form))
            abilityToTrigger = ability.abilityToTrigger;
        else
            abilityToTrigger = null;
    }
}