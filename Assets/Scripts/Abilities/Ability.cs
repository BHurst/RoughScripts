using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Ability
{
    public Guid abilityID;
    public string abilityName;
    public bool initialized = false;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public FormRune aFormRune;
    public CastModeRune aCastModeRune;
    public SchoolRune aSchoolRune;
    public List<EffectRune> aEffectRunes;
    public Ability abilityToTrigger;
    public int inspectorEffectRank;
    public string inspectorEffectRuneName;
    public float cooldown = 0;
    public float overrideDamage = -1f;
    public float increasedProjectileSpeed = 1;
    public float increasedArea = 1;
    public float increasedChains = 0;
    public float increasedProjectiles = 0;

    public float GetCost()
    {
        return aSchoolRune.baseCost * aFormRune.formResourceCostMod;
    }

    public void NameSelf()
    {
        abilityName = aFormRune.runeName
            + " " + aCastModeRune.runeName
            + " " + aSchoolRune.runeName;

        foreach (var rune in aEffectRunes)
        {
            abilityName += " " + rune.runeName;
        }
    }

    public void EffectFromInspector()
    {
        if(!string.IsNullOrEmpty(inspectorEffectRuneName))
        {
            EffectRune effectRune = (EffectRune)Activator.CreateInstance(Type.GetType(inspectorEffectRuneName));
            effectRune.rank = inspectorEffectRank;
            aEffectRunes.Add(effectRune);
        }
    }

    public Ability Clone()
    {
        Ability temp = new Ability
        {
            abilityID = abilityID,
            abilityName = abilityName,
            initialized = initialized,
            harmful = harmful,
            helpful = helpful,
            selfHarm = selfHarm,
            aFormRune = aFormRune.Clone(),
            aCastModeRune = aCastModeRune.Clone(),
            aSchoolRune = aSchoolRune.Clone(),
            aEffectRunes = new List<EffectRune>(),
            inspectorEffectRank = inspectorEffectRank,
            inspectorEffectRuneName = inspectorEffectRuneName,
            cooldown = cooldown,
            overrideDamage = overrideDamage
            
        };
        return temp;
    }

    public static bool NullorUninitialized(Ability ability)
    {
        if (ability != null && ability.initialized)
            return false;

        return true;
    }
}