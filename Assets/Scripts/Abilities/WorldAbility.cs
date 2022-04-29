using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAbility : MonoBehaviour
{
    public Guid worldAbilityID;
    public Guid abilityOwner;
    public string worldAbilityName;
    public FormRune wFormRune;
    public CastModeRune wCastModeRune;
    public SchoolRune wSchoolRune;
    public List<EffectRune> wEffectRunes;
    public Ability abilityToTrigger;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public bool isTriggered = false;
    public List<RootUnit> previousTargets = new List<RootUnit>();
    public float calculatedDamage = 0;
    public float calculatedHealing = 0;
    public Transform targetPreference;
    public float overrideDamage = -1;

    public void AffectTarget()
    {
        DamageManager.CalculateAbilityDefender(abilityOwner, this);
    }

    internal void Construct(Ability ability, Guid owner)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        wFormRune = ability.aFormRune;
        wEffectRunes = ability.aEffectRunes;
        wSchoolRune = ability.aSchoolRune;
        if (ability.abilityToTrigger != null && UtilityService.CanFormTriggerForm(wFormRune.formRuneType, ability.abilityToTrigger.aFormRune.formRuneType))
            abilityToTrigger = ability.abilityToTrigger;
        else
            abilityToTrigger = null;

        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
        overrideDamage = ability.overrideDamage;
    }

    internal void Construct(WorldAbility ability, Guid owner)
    {
        worldAbilityID = Guid.NewGuid();
        abilityOwner = owner;
        wFormRune = ability.wFormRune;
        wEffectRunes = null;
        wSchoolRune = ability.wSchoolRune;
        abilityToTrigger = null;

        harmful = ability.harmful;
        helpful = ability.helpful;
        selfHarm = ability.selfHarm;
    }
}