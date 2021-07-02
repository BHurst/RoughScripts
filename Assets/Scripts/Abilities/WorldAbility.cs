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
    public List<SchoolRune> schoolRunes;
    public ISpecialEffect specialEffect;
    public Ability abilityToTrigger;
    public bool isTriggered = false;
    public List<Guid> previousTargets = new List<Guid>();
    public float caculatedDamage = 0;
    public float caculatedHealing = 0;
    public Transform targetPreference;

    public void AffectTarget(Guid target)
    {
        DamageManager.CalculateAbilityDefender(abilityOwner, this);
    }

    internal void Construct(Ability ability, Guid owner)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        worldAbilityName = "None Yet";
        formRune = ability.formRune;
        buffRune = ability.buffRune;
        debuffRune = ability.debuffRune;
        harmRune = ability.harmRune;
        healRune = ability.healRune;
        schoolRunes = ability.schoolRunes;
        specialEffect = ability.specialEffect;
        if (ability.abilityToTrigger != null && UtilityService.CanFormTriggerForm(formRune.form, ability.abilityToTrigger.formRune.form))
            abilityToTrigger = ability.abilityToTrigger;
    }
}