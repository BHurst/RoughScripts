using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellStats {

    public enum AbilitySchool
    {
        Utility,
        Physical,
        Arcane,
        Fire,
        Water,
        Nature,
        Air,
        Ethereal,
        Astral
    }

    public enum AbilityTarget
    {
        Self,
        Target,
        Ground
    }

    public enum PassiveFunction
    {
        AlwaysOn,
        OnCast,
        OnAttack,
        OnHitBySpell,
        OnHitByAttack
    }

    public string abilityName = "None";
    public string description = "Placeholder, does {0} damage.";
    public AbilitySchool abilitySchool = AbilitySchool.Utility;
    public PassiveFunction passiveFunction = PassiveFunction.AlwaysOn;
    public List<AbilityTags.AbilityTag> abilityTags = new List<AbilityTags.AbilityTag>();
    public List<AbilityModifierKeyword> abilityKeywords = new List<AbilityModifierKeyword>();
    public float weaponModifer = 1;
    public float spellModifer = 1;
    public string abilityPrefabLocation = "";
    public bool abilityRequiresTarget = false;
    public int numberOfSpells = 1;
    public float abilityBaseCost = 0;
    public List<Damage> abilityDamageComponents = new List<Damage>();
    public float abilityBaseCriticalChance = 0;
    public float abilityBaseCriticalMultiplier = 1.5f;
    public float abilityBaseRangeMinimum = 0;
    public float abilityBaseRangeMaximum = 0;
    public float abilityBaseCooldown = 0;
    public float abilityBasePulseTimer = 0;
    public float abilityBasePulseDamage = 0;
    public float abilityBaseDuration = 0;
    public float abilityBaseInterval = 0;
    public float abilityBaseCastTime = 0;
    public float abilityBaseArea = 0;
    public float abilityBaseForce = 0;
    public float abilityBaseSpeed = 0;
    public AbilityTarget whoShouldITarget = AbilityTarget.Target;
    public List<int> castOnExpiration = new List<int>();
    public List<RootStatus> Statuses = new List<RootStatus>();
    public List<ISpecialEffect> specialEffects;
    public float activationStart = 0;
    public float activationEnd = 1000;
    public float randomLow = 1;
    public float randomHigh = 1;
}