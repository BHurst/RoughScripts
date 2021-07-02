using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public Guid abilityID;
    public string abilityName;
    public FormRune formRune;
    public CastModeRune castModeRune;
    public Buff_Rune buffRune;
    public Debuff_Rune debuffRune;
    public Harm_Rune harmRune;
    public Heal_Rune healRune;
    public List<SchoolRune> schoolRunes;
    public Ability abilityToTrigger;
    public ISpecialEffect specialEffect;
}