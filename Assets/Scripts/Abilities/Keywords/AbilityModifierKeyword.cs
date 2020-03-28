using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityModifierKeyword {

    public string keywordName = "None";
    public string description = "Nothing Added, Nothing Gained.";
    public SpellStats.AbilitySchool abilitySchool = SpellStats.AbilitySchool.Utility;
    public List<AbilityTags.AbilityTag> abilityTags = new List<AbilityTags.AbilityTag>();
    public List<KeywordBonuses> KeyBonuses = new List<KeywordBonuses>();
    public List<Damage> abilityDamageComponents = new List<Damage>();
}