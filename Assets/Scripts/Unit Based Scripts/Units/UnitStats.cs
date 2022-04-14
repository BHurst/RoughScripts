using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStats
{
    #region Form Bonuses
    //Arc
    public float Arc_Damage_Flat = 0;
    public float Arc_Damage_AddPercent = 0;
    public float Arc_Damage_MultiplyPercent = 1;
    public float Arc_DamageTaken_Flat = 0;
    public float Arc_DamageTaken_AddPercent = 0;
    public float Arc_DamageTaken_MultiplyPercent = 1;
    //Aura
    public float Aura_Damage_Flat = 0;
    public float Aura_Damage_AddPercent = 0;
    public float Aura_Damage_MultiplyPercent = 1;
    public float Aura_DamageTaken_Flat = 0;
    public float Aura_DamageTaken_AddPercent = 0;
    public float Aura_DamageTaken_MultiplyPercent = 1;
    //Beam
    public float Beam_Damage_Flat = 0;
    public float Beam_Damage_AddPercent = 0;
    public float Beam_Damage_MultiplyPercent = 1;
    public float Beam_DamageTaken_Flat = 0;
    public float Beam_DamageTaken_AddPercent = 0;
    public float Beam_DamageTaken_MultiplyPercent = 1;
    //Command
    public float Command_Damage_Flat = 0;
    public float Command_Damage_AddPercent = 0;
    public float Command_Damage_MultiplyPercent = 1;
    public float Command_DamageTaken_Flat = 0;
    public float Command_DamageTaken_AddPercent = 0;
    public float Command_DamageTaken_MultiplyPercent = 1;
    //Lance
    public float Lance_Damage_Flat = 0;
    public float Lance_Damage_AddPercent = 0;
    public float Lance_Damage_MultiplyPercent = 1;
    public float Lance_DamageTaken_Flat = 0;
    public float Lance_DamageTaken_AddPercent = 0;
    public float Lance_DamageTaken_MultiplyPercent = 1;
    //Nova
    public float Nova_Damage_Flat = 0;
    public float Nova_Damage_AddPercent = 0;
    public float Nova_Damage_MultiplyPercent = 1;
    public float Nova_DamageTaken_Flat = 0;
    public float Nova_DamageTaken_AddPercent = 0;
    public float Nova_DamageTaken_MultiplyPercent = 1;
    //Orb
    public float Orb_Damage_Flat = 0;
    public float Orb_Damage_AddPercent = 0;
    public float Orb_Damage_MultiplyPercent = 1;
    public float Orb_DamageTaken_Flat = 0;
    public float Orb_DamageTaken_AddPercent = 0;
    public float Orb_DamageTaken_MultiplyPercent = 1;
    //Point
    public float Point_Damage_Flat = 0;
    public float Point_Damage_AddPercent = 0;
    public float Point_Damage_MultiplyPercent = 1;
    public float Point_DamageTaken_Flat = 0;
    public float Point_DamageTaken_AddPercent = 0;
    public float Point_DamageTaken_MultiplyPercent = 1;
    //SelfCast
    public float SelfCast_Damage_Flat = 0;
    public float SelfCast_Damage_AddPercent = 0;
    public float SelfCast_Damage_MultiplyPercent = 1;
    public float SelfCast_DamageTaken_Flat = 0;
    public float SelfCast_DamageTaken_AddPercent = 0;
    public float SelfCast_DamageTaken_MultiplyPercent = 1;
    //Strike
    public float Strike_Damage_Flat = 0;
    public float Strike_Damage_AddPercent = 0;
    public float Strike_Damage_MultiplyPercent = 1;
    public float Strike_DamageTaken_Flat = 0;
    public float Strike_DamageTaken_AddPercent = 0;
    public float Strike_DamageTaken_MultiplyPercent = 1;
    //Wave
    public float Wave_Damage_Flat = 0;
    public float Wave_Damage_AddPercent = 0;
    public float Wave_Damage_MultiplyPercent = 1;
    public float Wave_DamageTaken_Flat = 0;
    public float Wave_DamageTaken_AddPercent = 0;
    public float Wave_DamageTaken_MultiplyPercent = 1;
    //Weapon
    public float Weapon_Damage_Flat = 0;
    public float Weapon_Damage_AddPercent = 0;
    public float Weapon_Damage_MultiplyPercent = 1;
    public float Weapon_DamageTaken_Flat = 0;
    public float Weapon_DamageTaken_AddPercent = 0;
    public float Weapon_DamageTaken_MultiplyPercent = 1;
    //Zone
    public float Zone_Damage_Flat = 0;
    public float Zone_Damage_AddPercent = 0;
    public float Zone_Damage_MultiplyPercent = 1;
    public float Zone_DamageTaken_Flat = 0;
    public float Zone_DamageTaken_AddPercent = 0;
    public float Zone_DamageTaken_MultiplyPercent = 1;
    #endregion
    #region Element Bonuses
    //Air
    public float Air_Damage_Flat = 0;
    public float Air_Damage_AddPercent = 0;
    public float Air_Damage_MultiplyPercent = 1;
    public float Air_DamageTaken_Flat = 0;
    public float Air_DamageTaken_AddPercent = 0;
    public float Air_DamageTaken_MultiplyPercent = 1;
    //Arcane
    public float Arcane_Damage_Flat = 0;
    public float Arcane_Damage_AddPercent = 0;
    public float Arcane_Damage_MultiplyPercent = 1;
    public float Arcane_DamageTaken_Flat = 0;
    public float Arcane_DamageTaken_AddPercent = 0;
    public float Arcane_DamageTaken_MultiplyPercent = 1;
    //Astral
    public float Astral_Damage_Flat = 0;
    public float Astral_Damage_AddPercent = 0;
    public float Astral_Damage_MultiplyPercent = 1;
    public float Astral_DamageTaken_Flat = 0;
    public float Astral_DamageTaken_AddPercent = 0;
    public float Astral_DamageTaken_MultiplyPercent = 1;
    //Electricity
    public float Electricity_Damage_Flat = 0;
    public float Electricity_Damage_AddPercent = 0;
    public float Electricity_Damage_MultiplyPercent = 1;
    public float Electricity_DamageTaken_Flat = 0;
    public float Electricity_DamageTaken_AddPercent = 0;
    public float Electricity_DamageTaken_MultiplyPercent = 1;
    //Ethereal
    public float Ethereal_Damage_Flat = 0;
    public float Ethereal_Damage_AddPercent = 0;
    public float Ethereal_Damage_MultiplyPercent = 1;
    public float Ethereal_DamageTaken_Flat = 0;
    public float Ethereal_DamageTaken_AddPercent = 0;
    public float Ethereal_DamageTaken_MultiplyPercent = 1;
    //Ice
    public float Ice_Damage_Flat = 0;
    public float Ice_Damage_AddPercent = 0;
    public float Ice_Damage_MultiplyPercent = 1;
    public float Ice_DamageTaken_Flat = 0;
    public float Ice_DamageTaken_AddPercent = 0;
    public float Ice_DamageTaken_MultiplyPercent = 1;
    //Fire
    public float Fire_Damage_Flat = 0;
    public float Fire_Damage_AddPercent = 0;
    public float Fire_Damage_MultiplyPercent = 1;
    public float Fire_DamageTaken_Flat = 0;
    public float Fire_DamageTaken_AddPercent = 0;
    public float Fire_DamageTaken_MultiplyPercent = 1;
    //Kinetic
    public float Kinetic_Damage_Flat = 0;
    public float Kinetic_Damage_AddPercent = 0;
    public float Kinetic_Damage_MultiplyPercent = 1;
    public float Kinetic_DamageTaken_Flat = 0;
    public float Kinetic_DamageTaken_AddPercent = 0;
    public float Kinetic_DamageTaken_MultiplyPercent = 1;
    //Nature
    public float Nature_Damage_Flat = 0;
    public float Nature_Damage_AddPercent = 0;
    public float Nature_Damage_MultiplyPercent = 1;
    public float Nature_DamageTaken_Flat = 0;
    public float Nature_DamageTaken_AddPercent = 0;
    public float Nature_DamageTaken_MultiplyPercent = 1;
    //Water
    public float Water_Damage_Flat = 0;
    public float Water_Damage_AddPercent = 0;
    public float Water_Damage_MultiplyPercent = 1;
    public float Water_DamageTaken_Flat = 0;
    public float Water_DamageTaken_AddPercent = 0;
    public float Water_DamageTaken_MultiplyPercent = 1;
    #endregion
    public float GlobalDamage_Damage_AddPercent = 0;
    public float GlobalDamage_Damage_MultiplyPercent = 1;
    public float GlobalDamage_DamageTaken_AddPercent = 0;
    public float GlobalDamage_DamageTaken_MultiplyPercent = 1;
    public float MoveSpeed { get; private set; } = 8.4315f;
    public float MoveSpeed_Movement_AddPercent = 1;
    public float MoveSpeed_Movement_MultiplyPercent = 1;
    public float Movespeed_Sprint_AddPercent = 1.3f;
    public float Movespeed_Cast_MultiplyPercent = .5f;
    public float Cast_Rate_Flat = 0;
    public float Cast_Rate_AddPercent = 0;
    public float Cast_Rate_MultiplyPercent = 1;

    public void IncreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        var statField = this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString());

        if (method == ModifierGroup.EMethod.Flat)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal + mod);
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal + mod);
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal * mod);
        }   
    }

    public void DecreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        var statField = this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString());

        if (method == ModifierGroup.EMethod.Flat)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal - mod);
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal - mod);
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            float priorVal = (float)statField.GetValue(this);
            statField.SetValue(this, priorVal / mod);
        }
    }
}