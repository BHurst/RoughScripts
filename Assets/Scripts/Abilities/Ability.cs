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
        Ability temp = new Ability();
        temp.abilityID = abilityID;
        temp.abilityName = abilityName;
        temp.initialized = initialized;
        temp.harmful = harmful;
        temp.helpful = helpful;
        temp.selfHarm = selfHarm;
        temp.aFormRune = aFormRune.Clone();
        temp.aCastModeRune = aCastModeRune.Clone();
        temp.aSchoolRune = aSchoolRune.Clone();
        temp.aEffectRunes = new List<EffectRune>();
        temp.inspectorEffectRank = inspectorEffectRank;
        temp.inspectorEffectRuneName = inspectorEffectRuneName;
        temp.cooldown = cooldown;
        return temp;
    }
}