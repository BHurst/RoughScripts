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
}