using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats
{
    #region Form Bonuses
    public float Arc_Damage_Flat = 0;
    public float Arc_Damage_AddPercent = 1;
    public float Arc_Damage_MultiplyPercent = 1;
    public float Aura_Damage_Flat = 0;
    public float Aura_Damage_AddPercent = 1;
    public float Aura_Damage_MultiplyPercent = 1;
    public float Beam_Damage_Flat = 0;
    public float Beam_Damage_AddPercent = 1;
    public float Beam_Damage_MultiplyPercent = 1;
    public float Lance_Damage_Flat = 0;
    public float Lance_Damage_AddPercent = 1;
    public float Lance_Damage_MultiplyPercent = 1;
    public float Nova_Damage_Flat = 0;
    public float Nova_Damage_AddPercent = 1;
    public float Nova_Damage_MultiplyPercent = 1;
    public float Orb_Damage_Flat = 0;
    public float Orb_Damage_AddPercent = 1;
    public float Orb_Damage_MultiplyPercent = 1;
    public float Point_Damage_Flat = 0;
    public float Point_Damage_AddPercent = 1;
    public float Point_Damage_MultiplyPercent = 1;
    public float SelfCast_Damage_Flat = 0;
    public float SelfCast_Damage_AddPercent = 1;
    public float SelfCast_Damage_MultiplyPercent = 1;
    public float Strike_Damage_Flat = 0;
    public float Strike_Damage_AddPercent = 1;
    public float Strike_Damage_MultiplyPercent = 1;
    public float Wave_Damage_Flat = 0;
    public float Wave_Damage_AddPercent = 1;
    public float Wave_Damage_MultiplyPercent = 1;
    public float Weapon_Damage_Flat = 0;
    public float Weapon_Damage_AddPercent = 1;
    public float Weapon_Damage_MultiplyPercent = 1;
    public float Zone_Damage_Flat = 0;
    public float Zone_Damage_AddPercent = 1;
    public float Zone_Damage_MultiplyPercent = 1;
    #endregion
    #region Element Bonuses
    public float Air_Damage_Flat = 0;
    public float Air_Damage_AddPercent = 1;
    public float Air_Damage_MultiplyPercent = 1;
    public float Arcane_Damage_Flat = 0;
    public float Arcane_Damage_AddPercent = 1;
    public float Arcane_Damage_MultiplyPercent = 1;
    public float Astral_Damage_Flat = 0;
    public float Astral_Damage_AddPercent = 1;
    public float Astral_Damage_MultiplyPercent = 1;
    public float Ethereal_Damage_Flat = 0;
    public float Ethereal_Damage_AddPercent = 1;
    public float Ethereal_Damage_MultiplyPercent = 1;
    public float Fire_Damage_Flat = 0;
    public float Fire_Damage_AddPercent = 1;
    public float Fire_Damage_MultiplyPercent = 1;
    public float Kinetic_Damage_Flat = 0;
    public float Kinetic_Damage_AddPercent = 1;
    public float Kinetic_Damage_MultiplyPercent = 1;
    public float Nature_Damage_Flat = 0;
    public float Nature_Damage_AddPercent = 1;
    public float Nature_Damage_MultiplyPercent = 1;
    public float Water_Damage_Flat = 0;
    public float Water_Damage_AddPercent = 1;
    public float Water_Damage_MultiplyPercent = 1;
    #endregion
    public float MoveSpeed { get; private set; } = 8.4315f;
    public float MoveSpeed_Movement_AddPercent = 1;
    public float MoveSpeed_Movement_MultiplyPercent = 1;
    public float Movespeed_Sprint_AddPercent = 1.3f;
    public float Movespeed_Cast_MultiplyPercent = .5f;

    public void IncreaseStat(ModifierGroup.eStat stat, ModifierGroup.eAspect aspect, ModifierGroup.eMethod method, float mod)
    {
        var statField = this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString());

        if (method == ModifierGroup.eMethod.Flat)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal + mod);
        }
        else if (method == ModifierGroup.eMethod.AddPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal + mod);
        }
        else if (method == ModifierGroup.eMethod.MultiplyPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal * mod);
        }   
    }

    public void DecreaseStat(ModifierGroup.eStat stat, ModifierGroup.eAspect aspect, ModifierGroup.eMethod method, float mod)
    {
        var statField = this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString());

        if (method == ModifierGroup.eMethod.Flat)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal - mod);
        }
        else if (method == ModifierGroup.eMethod.AddPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal - mod);
        }
        else if (method == ModifierGroup.eMethod.MultiplyPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal / mod);
        }
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
}