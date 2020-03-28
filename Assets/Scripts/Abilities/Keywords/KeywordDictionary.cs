using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeywordDictionary {

    public static AbilityModifierKeyword Physical()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Physical";
        keyword.abilitySchool = SpellStats.AbilitySchool.Physical;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Physical
        };
        
        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Physical});
        return keyword;
    }

    public static AbilityModifierKeyword Arcane()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Arcane";
        keyword.abilitySchool = SpellStats.AbilitySchool.Arcane;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Arcane
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Arcane });
        return keyword;
    }

    public static AbilityModifierKeyword Fire()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Fire";
        keyword.abilitySchool = SpellStats.AbilitySchool.Fire;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Fire
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Fire });
        return keyword;
    }

    public static AbilityModifierKeyword Water()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Water";
        keyword.abilitySchool = SpellStats.AbilitySchool.Water;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Water
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Water });
        return keyword;
    }

    public static AbilityModifierKeyword Nature()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Nature";
        keyword.abilitySchool = SpellStats.AbilitySchool.Nature;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Nature
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Nature });
        return keyword;
    }

    public static AbilityModifierKeyword Air()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Air";
        keyword.abilitySchool = SpellStats.AbilitySchool.Air;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Air
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Air });
        return keyword;
    }

    public static AbilityModifierKeyword Ethereal()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Ethereal";
        keyword.abilitySchool = SpellStats.AbilitySchool.Ethereal;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Ethereal
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Ethereal });
        return keyword;
    }

    public static AbilityModifierKeyword Astral()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Vus";
        keyword.description = "Astral";
        keyword.abilitySchool = SpellStats.AbilitySchool.Astral;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Damage,
            AbilityTags.AbilityTag.Astral
        };

        keyword.abilityDamageComponents.Add(new Damage() { minimumDamage = 10, maximumDamage = 15, abilityBaseDamageType = SpellStats.AbilitySchool.Astral });
        return keyword;
    }

    public static AbilityModifierKeyword Area()
    {
        AbilityModifierKeyword keyword = new AbilityModifierKeyword();

        keyword.keywordName = "Suda";
        keyword.description = "Area";
        keyword.abilitySchool = SpellStats.AbilitySchool.Utility;

        keyword.abilityTags = new List<AbilityTags.AbilityTag>
        {
            AbilityTags.AbilityTag.Area
        };

        KeywordBonuses bonuses = new KeywordBonuses();

        bonuses.keywordBaseArea = 3;

        keyword.KeyBonuses.Add(bonuses);
        
        return keyword;
    }
}