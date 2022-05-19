using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStats
{
    public float Health_Current = 100;
    public float Health_Max = 100;
    public float Health_Max_Default = 100;
    public UnitStat Health_Max_Flat = new() { valueCollection = new(), readableName = "Additional max health", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Health_Max_AddPercent = new() { valueCollection = new(), readableName = "Increased max health", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Health_Max_MultiplyPercent = new() { valueCollection = new(), readableName = "More max health", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public float Health_Regeneration = 0;
    public UnitStat Health_Regeneration_Flat = new() { valueCollection = new(), readableName = "Additional health regeneration per second", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Health_Regeneration_AddPercent = new() { valueCollection = new(), readableName = "Increased health regeneration", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Health_Regeneration_MultiplyPercent = new() { valueCollection = new(), readableName = "More health regeneration", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public float Mana_Current = 100;
    public float Mana_Max = 100;
    public float Mana_Max_Default = 100;
    public UnitStat Mana_Max_Flat = new() { valueCollection = new(), readableName = "Additional max mana", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Mana_Max_AddPercent = new() { valueCollection = new(), readableName = "Increased max mana", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Mana_Max_MultiplyPercent = new() { valueCollection = new(), readableName = "More max mana", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public float Mana_Regeneration = 0;
    public UnitStat Mana_Regeneration_Flat = new() { valueCollection = new(), readableName = "Additional mana regeneration per second", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Mana_Regeneration_AddPercent = new() { valueCollection = new(), readableName = "Increased mana regeneration", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Mana_Regeneration_MultiplyPercent = new() { valueCollection = new(), readableName = "More mana regeneration", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    #region Form Bonuses
    //Arc
    public UnitStat Arc_Damage_Flat = new() { valueCollection = new(), readableName = "Additional arc damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Arc_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased arc damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Arc_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More arc damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Arc_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional arc damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Arc_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased arc damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Arc_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More arc damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Aura
    public UnitStat Aura_Damage_Flat = new() { valueCollection = new(), readableName = "Additional aura damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Aura_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased aura damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Aura_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More aura damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Aura_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional aura damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Aura_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased aura damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Aura_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More aura damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Beam
    public UnitStat Beam_Damage_Flat = new() { valueCollection = new(), readableName = "Additional beam damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Beam_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased beam damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Beam_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More beam damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Beam_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional beam damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Beam_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased beam damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Beam_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More beam damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Command
    public UnitStat Command_Damage_Flat = new() { valueCollection = new(), readableName = "Additional command damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Command_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased command damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Command_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More command damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Command_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional command damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Command_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased command damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Command_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More command damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Lance
    public UnitStat Lance_Damage_Flat = new() { valueCollection = new(), readableName = "Additional lance damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Lance_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased lance damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Lance_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More lance damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Lance_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional lance damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Lance_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased lance damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Lance_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More lance damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Nova
    public UnitStat Nova_Damage_Flat = new() { valueCollection = new(), readableName = "Additional nova damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Nova_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased nova damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Nova_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More nova damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Nova_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional nova damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Nova_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased nova damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Nova_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More nova damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Orb
    public UnitStat Orb_Damage_Flat = new() { valueCollection = new(), readableName = "Additional orb damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Orb_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased orb damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Orb_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More orb damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Orb_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional orb damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Orb_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased orb damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Orb_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More orb damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Point
    public UnitStat Point_Damage_Flat = new() { valueCollection = new(), readableName = "Additional point damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Point_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased point damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Point_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More point damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Point_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional point damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Point_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased point damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Point_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More point damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //SelfCast
    public UnitStat SelfCast_Damage_Flat = new() { valueCollection = new(), readableName = "Additional self-cast damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat SelfCast_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased self-cast damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat SelfCast_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More self-cast damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat SelfCast_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional self-cast damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat SelfCast_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased self-cast damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat SelfCast_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More self-cast damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Strike
    public UnitStat Strike_Damage_Flat = new() { valueCollection = new(), readableName = "Additional strike damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Strike_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased strike damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Strike_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More strike damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Strike_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional strike damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Strike_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased strike damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Strike_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More strike damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Wave
    public UnitStat Wave_Damage_Flat = new() { valueCollection = new(), readableName = "Additional wave damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Wave_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased wave damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Wave_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More wave damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Wave_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional wave damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Wave_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased wave damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Wave_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More wave damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Weapon
    public UnitStat Weapon_Damage_Flat = new() { valueCollection = new(), readableName = "Additional weapon damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Weapon_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased weapon damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Weapon_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More weapon damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Weapon_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional weapon damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Weapon_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased weapon damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Weapon_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More weapon damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Zone
    public UnitStat Zone_Damage_Flat = new() { valueCollection = new(), readableName = "Additional zone damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Zone_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased zone damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Zone_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More zone damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Zone_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional zone damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Zone_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased zone damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Zone_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More zone damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    #endregion
    #region Element Bonuses
    //Air
    public UnitStat Air_Damage_Flat = new() { valueCollection = new(), readableName = "Additional air damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Air_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased air damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Air_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More air damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Air_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional air damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Air_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased air damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Air_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More air damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Arcane
    public UnitStat Arcane_Damage_Flat = new() { valueCollection = new(), readableName = "Additional arcane damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Arcane_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased arcane damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Arcane_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More arcane damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Arcane_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional arcane damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Arcane_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased arcane damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Arcane_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More arcane damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Astral
    public UnitStat Astral_Damage_Flat = new() { valueCollection = new(), readableName = "Additional astral damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Astral_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased astral damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Astral_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More astral damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Astral_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional astral damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Astral_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased astral damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Astral_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More astral damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Earth
    public UnitStat Earth_Damage_Flat = new() { valueCollection = new(), readableName = "Additional earth damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Earth_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased earth damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Earth_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More earth damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Earth_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional earth damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Earth_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased earth damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Earth_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More earth damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Electricity
    public UnitStat Electricity_Damage_Flat = new() { valueCollection = new(), readableName = "Additional electricity damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Electricity_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased electricity damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Electricity_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More electricity damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Electricity_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional electricity damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Electricity_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased electricity damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Electricity_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More electricity damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Ethereal
    public UnitStat Ethereal_Damage_Flat = new() { valueCollection = new(), readableName = "Additional ethereal damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased ethereal damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More ethereal damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Ethereal_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional ethereal damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased ethereal damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More ethereal damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Fire
    public UnitStat Fire_Damage_Flat = new() { valueCollection = new(), readableName = "Additional fire damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Fire_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased fire damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Fire_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More fire damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Fire_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional fire damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Fire_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased fire damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Fire_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More fire damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Ice
    public UnitStat Ice_Damage_Flat = new() { valueCollection = new(), readableName = "Additional ice damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ice_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased ice damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ice_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More ice damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Ice_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional ice damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ice_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased ice damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ice_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More ice damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Kinetic
    public UnitStat Kinetic_Damage_Flat = new() { valueCollection = new(), readableName = "Additional kinetic damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased kinetic damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More kinetic damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Kinetic_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional kinetic damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased kinetic damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More kinetic damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Life
    public UnitStat Life_Damage_Flat = new() { valueCollection = new(), readableName = "Additional life damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Life_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased life damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Life_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More life damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Life_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional life damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Life_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased life damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Life_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More life damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    //Water
    public UnitStat Water_Damage_Flat = new() { valueCollection = new(), readableName = "Additional water damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Water_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased water damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Water_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More water damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Water_DamageTaken_Flat = new() { valueCollection = new(), readableName = "Additional water damage received", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Water_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased water damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Water_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More water damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    #endregion
    public UnitStat GlobalDamage_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased global damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat GlobalDamage_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More global damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat GlobalDamage_DamageTaken_AddPercent = new() { valueCollection = new(), readableName = "Increased global damage received", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat GlobalDamage_DamageTaken_MultiplyPercent = new() { valueCollection = new(), readableName = "More global damage received", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Movement { get; private set; } = new() { valueCollection = new(), readableName = "Move speed", value = 10, defaultValue = 10, displayOnStatScreen = true };
    public UnitStat Movement_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased move speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Movement_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More move speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };
    public UnitStat Sprint_Rate_AddPercent = new() { valueCollection = new(), readableName = "Sprint speed increase",  method = ModifierGroup.EMethod.AddPercent, value = .3f, defaultValue = .3f };
    public UnitStat Castmove_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "Reduced speed while casting", method = ModifierGroup.EMethod.MultiplyPercent, value = .5f, defaultValue = .5f };

    public UnitStat Cast_Rate_Flat = new() { valueCollection = new(), readableName = "Flat cast time", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Cast_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased cast speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Cast_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More cast speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public UnitStat Attack_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased attack speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Attack_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More attack speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public UnitStat Projectile_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased projectile speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Projectile_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More projectile speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public UnitStat Ability_Area_AddPercent = new() { valueCollection = new(), readableName = "Increased ability radius", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ability_Area_MultiplyPercent = new() { valueCollection = new(), readableName = "More ability radius", method = ModifierGroup.EMethod.MultiplyPercent, value = 1 ,defaultValue = 1 };

    public UnitStat Ability_Chains_Flat = new() { valueCollection = new(), readableName = "Additional ability chain targets", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };

    public UnitStat Ability_Projectiles_Flat = new() { valueCollection = new(), readableName = "Additional ability projectiles", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };

    public void IncreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        statField.Increase(mod);

        if (stat == ModifierGroup.EStat.Health)
        {
            float oldPercent = Health_Current / Health_Max;

            if (aspect == ModifierGroup.EAspect.Max)
            {
                Health_Max = (Health_Max_Default + Health_Max_Flat.value) * (1 + Health_Max_AddPercent.value) * Health_Max_MultiplyPercent.value;
            }
            Health_Regeneration = (Health_Max / 200 + Health_Regeneration_Flat.value) * (1 + Health_Regeneration_AddPercent.value) * Health_Regeneration_MultiplyPercent.value;

            Health_Current = oldPercent * Health_Max;
        }

        if (stat == ModifierGroup.EStat.Mana)
        {
            float oldPercent = Mana_Current / Mana_Max;

            if (aspect == ModifierGroup.EAspect.Max)
            {
                Mana_Max = (Mana_Max_Default + Mana_Max_Flat.value) * (1 + Mana_Max_AddPercent.value) * Mana_Max_MultiplyPercent.value;
            }
            Mana_Regeneration = (Mana_Max / 120 + Mana_Regeneration_Flat.value) * (1 + Mana_Regeneration_AddPercent.value) * Mana_Regeneration_MultiplyPercent.value;

            Mana_Current = oldPercent * Mana_Max;
        }
    }

    public void DecreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        statField.Decrease(mod);

        if (stat == ModifierGroup.EStat.Health)
        {
            float oldPercent = Health_Current / Health_Max;

            if (aspect == ModifierGroup.EAspect.Max)
            {
                Health_Max = (Health_Max_Default + Health_Max_Flat.value) * (1 + Health_Max_AddPercent.value) * Health_Max_MultiplyPercent.value;
            }
            Health_Regeneration = (Health_Max / 200 + Health_Regeneration_Flat.value) * (1 + Health_Regeneration_AddPercent.value) * Health_Regeneration_MultiplyPercent.value;

            Health_Current = oldPercent * Health_Max;
        }

        if (stat == ModifierGroup.EStat.Mana)
        {
            float oldPercent = Mana_Current / Mana_Max;

            if (aspect == ModifierGroup.EAspect.Max)
            {
                Mana_Max = (Mana_Max_Default + Mana_Max_Flat.value) * (1 + Mana_Max_AddPercent.value) * Mana_Max_MultiplyPercent.value;
            }
            Mana_Regeneration = (Mana_Max / 120 + Mana_Regeneration_Flat.value) * (1 + Mana_Regeneration_AddPercent.value) * Mana_Regeneration_MultiplyPercent.value;

            Mana_Current = oldPercent * Mana_Max;
        }
    }

    public float GetUnitCastTime(Ability ability)
    {
        return (ability.aSchoolRune.baseCastSpeed - Cast_Rate_Flat.value) / (1 + Cast_Rate_AddPercent.value) / Cast_Rate_MultiplyPercent.value;
    }

    public void InitializeStats()
    {
        Health_Regeneration = (Health_Max / 200 + Health_Regeneration_Flat.value) * (1 + Health_Regeneration_AddPercent.value) * Health_Regeneration_MultiplyPercent.value;
        Mana_Regeneration = (Mana_Max / 120 + Mana_Regeneration_Flat.value) * (1 + Mana_Regeneration_AddPercent.value) * Mana_Regeneration_MultiplyPercent.value;
    }
}

[Serializable]
public class UnitStat
{
    public List<float> valueCollection;
    public float value
    {
        get
        {
            if (valueCollection.Count < 1)
                return defaultValue;
            float full = defaultValue;
            if (method == ModifierGroup.EMethod.Flat)
            {
                full = defaultValue;
                foreach (float val in valueCollection)
                {
                    full += val;

                }
            }
            else if (method == ModifierGroup.EMethod.AddPercent)
            {
                full = defaultValue;
                foreach (float val in valueCollection)
                {
                    full += val;

                }
            }
            else if (method == ModifierGroup.EMethod.MultiplyPercent)
            {
                full = defaultValue;
                foreach (float val in valueCollection)
                {
                    full *= val;

                }
            }
            else
                return 0;
            return full;
        }
        set
        {

        }
    }
    public ModifierGroup.EMethod method;
    public float defaultValue;
    public string readableName;
    public string statScreenSymbol = "";
    public bool displayOnStatScreen = true;

    public void Increase(float amount)
    {
        valueCollection.Add(amount);
    }

    public void Decrease(float amount)
    {
        valueCollection.Remove(amount);
    }
}