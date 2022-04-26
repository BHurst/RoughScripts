﻿using System;
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
    public float healthCost = 0;
    public float manaCost = 5;
    public float cooldown = 0;
    public int inspectorEffectRank;
    public string inspectorEffectRuneName;

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
            cooldown = cooldown
            
        };
        return temp;
    }
}