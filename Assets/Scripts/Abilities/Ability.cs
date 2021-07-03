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
    public FormRune formRune;
    public CastModeRune castModeRune;
    public Buff_Rune buffRune;
    public Debuff_Rune debuffRune;
    public Harm_Rune harmRune;
    public Heal_Rune healRune;
    public SchoolRune schoolRune;
    public Ability abilityToTrigger;
    public ISpecialEffect specialEffect;

    public void NameSelf()
    {
        abilityName = formRune.runeName + castModeRune.runeName + buffRune.runeName + debuffRune.runeName + harmRune.runeName + healRune.runeName + schoolRune.runeName;
    }
}