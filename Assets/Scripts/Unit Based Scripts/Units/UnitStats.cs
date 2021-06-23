using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats
{
    #region Form Bonuses
    public float Arc_Damage_Flat = 0;
    public float Arc_Damage_Increase_Add = 1;
    public float Arc_Damage_Increase_Multiply = 1;
    public float Aura_Damage_Flat = 0;
    public float Aura_Damage_Increase_Add = 1;
    public float Aura_Damage_Increase_Multiply = 1;
    public float Beam_Damage_Flat = 0;
    public float Beam_Damage_Increase_Add = 1;
    public float Beam_Damage_Increase_Multiply = 1;
    public float Lance_Damage_Flat = 0;
    public float Lance_Damage_Increase_Add = 1;
    public float Lance_Damage_Increase_Multiply = 1;
    public float Nova_Damage_Flat = 0;
    public float Nova_Damage_Increase_Add = 1;
    public float Nova_Damage_Increase_Multiply = 1;
    public float Orb_Damage_Flat = 0;
    public float Orb_Damage_Increase_Add = 1;
    public float Orb_Damage_Increase_Multiply = 1;
    public float Point_Damage_Flat = 0;
    public float Point_Damage_Increase_Add = 1;
    public float Point_Damage_Increase_Multiply = 1;
    public float SelfCast_Damage_Flat = 0;
    public float SelfCast_Damage_Increase_Add = 1;
    public float SelfCast_Damage_Increase_Multiply = 1;
    public float Strike_Damage_Flat = 0;
    public float Strike_Damage_Increase_Add = 1;
    public float Strike_Damage_Increase_Multiply = 1;
    public float Wave_Damage_Flat = 0;
    public float Wave_Damage_Increase_Add = 1;
    public float Wave_Damage_Increase_Multiply = 1;
    public float Weapon_Damage_Flat = 0;
    public float Weapon_Damage_Increase_Add = 1;
    public float Weapon_Damage_Increase_Multiply = 1;
    public float Zone_Damage_Flat = 0;
    public float Zone_Damage_Increase_Add = 1;
    public float Zone_Damage_Increase_Multiply = 1;
    #endregion
    #region Element Bonuses
    public float Air_Damage_Flat = 0;
    public float Air_Damage_Increase_Add = 1;
    public float Air_Damage_Increase_Multiply = 1;
    public float Arcane_Damage_Flat = 0;
    public float Arcane_Damage_Increase_Add = 1;
    public float Arcane_Damage_Increase_Multiply = 1;
    public float Astral_Damage_Flat = 0;
    public float Astral_Damage_Increase_Add = 1;
    public float Astral_Damage_Increase_Multiply = 1;
    public float Ethereal_Damage_Flat = 0;
    public float Ethereal_Damage_Increase_Add = 1;
    public float Ethereal_Damage_Increase_Multiply = 1;
    public float Fire_Damage_Flat = 0;
    public float Fire_Damage_Increase_Add = 1;
    public float Fire_Damage_Increase_Multiply = 1;
    public float Kinetic_Damage_Flat = 0;
    public float Kinetic_Damage_Increase_Add = 1;
    public float Kinetic_Damage_Increase_Multiply = 1;
    public float Nature_Damage_Flat = 0;
    public float Nature_Damage_Increase_Add = 1;
    public float Nature_Damage_Increase_Multiply = 1;
    public float Water_Damage_Flat = 0;
    public float Water_Damage_Increase_Add = 1;
    public float Water_Damage_Increase_Multiply = 1;
    #endregion
    public float MoveSpeed = 7;
    public float MoveSpeed_Multiply = 1;

    public void IncreaseStat(Modifier.StatModifiers stat, float mod)
    {
        switch (stat)
        {
            case Modifier.StatModifiers.Orb_Damage_Flat:
                Orb_Damage_Flat += mod;
                break;
            default:
                break;
        }
    }

    public void DecreaseStat(Modifier.StatModifiers stat, float mod)
    {
        switch (stat)
        {
            
            default:
                break;
        }
    }

    public void RefreshAllStats_OLD()
    {
        ResetStats();

    }

    public void CalculateStatBonuses(RootUnit character)
    {
        //AttackDamageMin += character.attributes.Strength * .5f;
        //AttackDamageMax += character.attributes.Strength * .5f;
        //BonusAttackSpeedPercent *= 1 + (character.attributes.Agility * .01f);
        //BonusCastSpeedPercent *= 1 + (character.attributes.Wisdom * .005f);
        //BonusMoveSpeedPercent *= 1 + (character.attributes.Agility * .01f);
        //AllDamageReduction *= 1 + (character.attributes.Willpower * .02f);
        ////Stamina will affect health
        //CooldownReduction *= 1 + (character.attributes.Skill * .01f);
        //PhysicalCritChance += character.attributes.Agility * .002f;
        //PhysicalCritDamage *= 1 + (character.attributes.Strength * .005f);
        //SpellCritChance += character.attributes.Intellect * .005f;
        //SpellCritDamage *= 1 + (character.attributes.Wisdom * .0075f);
    }

    public void ResetStats()
    {
        //AttackDamageMin = 5;
        //AttackDamageMax = 10;
        //BonusAttackDamageFlat = 0;
        //BonusAttackDamagePercent = 1;
        //BonusSpellDamageFlat = 0;
        //BonusSpellDamagePercent = 1;
        //BonusDamagePercent = 1;
        //BonusHealFlat = 0;
        //BonusHealPercent = 1;
        //AttackSpeed = 1;
        //BonusAttackSpeedPercent = 1;
        //BonusCastSpeedPercent = 1;
        //MoveSpeed = 7f;
        //BonusMoveSpeedFlat = 0;
        //BonusMoveSpeedPercent = 1;
        //JumpHeight = 1f;
        //BonusJumpHeightFlat = 0;
        //BonusJumpHeightPercent = 1;
        //AllResistance = 1;
        //Defence = 1;
        //AllDamageReduction = 1;
        //CooldownReduction = 1;
        //PhysicalCritChance = .03f;
        //PhysicalCritDamage = 1.5f;
        //SpellCritChance = .03f;
        //SpellCritDamage = 1.5f;
    }
}