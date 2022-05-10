using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStats
{
    public UnitStat Health_Current = new UnitStat() { readableName = "Current life", value = 100f, defaultValue = 100f, displayOnStatScreen = false , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Health_Max = new UnitStat() { readableName = "Maximum life", value = 100f, defaultValue = 100f, displayOnStatScreen = false , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Health_Max_Flat = new UnitStat() { readableName = "Additional health regeneration per second", value = 0f, defaultValue = 0f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Health_Max_AddPercent = new UnitStat() { readableName = "Increased health regeneration", value = 0f, defaultValue = 0f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Health_Max_MultiplyPercent = new UnitStat() { readableName = "More health regeneration", value = 1f, defaultValue = 1f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Health_Regeneration { get; private set; } = new UnitStat() { readableName = "Health regenerated per second", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Health_Regeneration_Flat = new UnitStat() { readableName = "Additional health regeneration per second", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Health_Regeneration_AddPercent = new UnitStat() { readableName = "Increased health regeneration", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Health_Regeneration_MultiplyPercent = new UnitStat() { readableName = "More health regeneration", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Mana_Current = new UnitStat() { readableName = "Current mana", value = 100f, defaultValue = 100f, displayOnStatScreen = false , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Mana_Max = new UnitStat() { readableName = "Max mana", value = 100f, defaultValue = 100f, displayOnStatScreen = false , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Mana_Max_Flat = new UnitStat() { readableName = "Additional mana regeneration per second", value = 0f, defaultValue = 0f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Mana_Max_AddPercent = new UnitStat() { readableName = "Increased mana regeneration", value = 0f, defaultValue = 0f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Mana_Max_MultiplyPercent = new UnitStat() { readableName = "More mana regeneration", value = 1f, defaultValue = 1f, sourceAvailability = StatSourceAvailability.All };
    public UnitStat Mana_Regeneration { get; private set; } = new UnitStat() { readableName = "Mana regenerated per second", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.None };
    public UnitStat Mana_Regeneration_Flat = new UnitStat() { readableName = "Additional mana regeneration per second", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Mana_Regeneration_AddPercent = new UnitStat() { readableName = "Increased mana regeneration", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Mana_Regeneration_MultiplyPercent = new UnitStat() { readableName = "More mana regeneration", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    #region Form Bonuses
    //Arc
    public UnitStat Arc_Damage_Flat = new UnitStat() { readableName = "Additional arc damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arc_Damage_AddPercent = new UnitStat() { readableName = "Increased arc damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arc_Damage_MultiplyPercent = new UnitStat() { readableName = "More arc damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arc_DamageTaken_Flat = new UnitStat() { readableName = "Additional arc damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arc_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased arc damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arc_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More arc damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Aura
    public UnitStat Aura_Damage_Flat = new UnitStat() { readableName = "Additional aura damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Aura_Damage_AddPercent = new UnitStat() { readableName = "Increased aura damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Aura_Damage_MultiplyPercent = new UnitStat() { readableName = "More aura damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Aura_DamageTaken_Flat = new UnitStat() { readableName = "Additional aura damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Aura_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased aura damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Aura_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More aura damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Beam
    public UnitStat Beam_Damage_Flat = new UnitStat() { readableName = "Additional beam damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Beam_Damage_AddPercent = new UnitStat() { readableName = "Increased beam damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Beam_Damage_MultiplyPercent = new UnitStat() { readableName = "More beam damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Beam_DamageTaken_Flat = new UnitStat() { readableName = "Additional beam damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Beam_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased beam damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Beam_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More beam damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Command
    public UnitStat Command_Damage_Flat = new UnitStat() { readableName = "Additional command damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Command_Damage_AddPercent = new UnitStat() { readableName = "Increased command damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Command_Damage_MultiplyPercent = new UnitStat() { readableName = "More command damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Command_DamageTaken_Flat = new UnitStat() { readableName = "Additional command damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Command_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased command damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Command_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More command damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Lance
    public UnitStat Lance_Damage_Flat = new UnitStat() { readableName = "Additional lance damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Lance_Damage_AddPercent = new UnitStat() { readableName = "Increased lance damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Lance_Damage_MultiplyPercent = new UnitStat() { readableName = "More lance damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Lance_DamageTaken_Flat = new UnitStat() { readableName = "Additional lance damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Lance_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased lance damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Lance_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More lance damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Nova
    public UnitStat Nova_Damage_Flat = new UnitStat() { readableName = "Additional nova damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Nova_Damage_AddPercent = new UnitStat() { readableName = "Increased nova damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Nova_Damage_MultiplyPercent = new UnitStat() { readableName = "More nova damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Nova_DamageTaken_Flat = new UnitStat() { readableName = "Additional nova damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Nova_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased nova damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Nova_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More nova damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Orb
    public UnitStat Orb_Damage_Flat = new UnitStat() { readableName = "Additional orb damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Orb_Damage_AddPercent = new UnitStat() { readableName = "Increased orb damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Orb_Damage_MultiplyPercent = new UnitStat() { readableName = "More orb damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Orb_DamageTaken_Flat = new UnitStat() { readableName = "Additional orb damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Orb_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased orb damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Orb_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More orb damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Point
    public UnitStat Point_Damage_Flat = new UnitStat() { readableName = "Additional point damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Point_Damage_AddPercent = new UnitStat() { readableName = "Increased point damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Point_Damage_MultiplyPercent = new UnitStat() { readableName = "More point damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Point_DamageTaken_Flat = new UnitStat() { readableName = "Additional point damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Point_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased point damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Point_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More point damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //SelfCast
    public UnitStat SelfCast_Damage_Flat = new UnitStat() { readableName = "Additional self-cast damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SelfCast_Damage_AddPercent = new UnitStat() { readableName = "Increased self-cast damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SelfCast_Damage_MultiplyPercent = new UnitStat() { readableName = "More self-cast damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SelfCast_DamageTaken_Flat = new UnitStat() { readableName = "Additional self-cast damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SelfCast_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased self-cast damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SelfCast_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More self-cast damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Strike
    public UnitStat Strike_Damage_Flat = new UnitStat() { readableName = "Additional strike damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Strike_Damage_AddPercent = new UnitStat() { readableName = "Increased strike damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Strike_Damage_MultiplyPercent = new UnitStat() { readableName = "More strike damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Strike_DamageTaken_Flat = new UnitStat() { readableName = "Additional strike damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Strike_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased strike damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Strike_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More strike damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Wave
    public UnitStat Wave_Damage_Flat = new UnitStat() { readableName = "Additional wave damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Wave_Damage_AddPercent = new UnitStat() { readableName = "Increased wave damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Wave_Damage_MultiplyPercent = new UnitStat() { readableName = "More wave damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Wave_DamageTaken_Flat = new UnitStat() { readableName = "Additional wave damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Wave_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased wave damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Wave_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More wave damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Weapon
    public UnitStat Weapon_Damage_Flat = new UnitStat() { readableName = "Additional weapon damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Weapon_Damage_AddPercent = new UnitStat() { readableName = "Increased weapon damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Weapon_Damage_MultiplyPercent = new UnitStat() { readableName = "More weapon damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Weapon_DamageTaken_Flat = new UnitStat() { readableName = "Additional weapon damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Weapon_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased weapon damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Weapon_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More weapon damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Zone
    public UnitStat Zone_Damage_Flat = new UnitStat() { readableName = "Additional zone damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Zone_Damage_AddPercent = new UnitStat() { readableName = "Increased zone damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Zone_Damage_MultiplyPercent = new UnitStat() { readableName = "More zone damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Zone_DamageTaken_Flat = new UnitStat() { readableName = "Additional zone damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Zone_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased zone damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Zone_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More zone damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    #endregion
    #region Element Bonuses
    //Air
    public UnitStat Air_Damage_Flat = new UnitStat() { readableName = "Additional air damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Air_Damage_AddPercent = new UnitStat() { readableName = "Increased air damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Air_Damage_MultiplyPercent = new UnitStat() { readableName = "More air damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Air_DamageTaken_Flat = new UnitStat() { readableName = "Additional air damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Air_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased air damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Air_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More air damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Arcane
    public UnitStat Arcane_Damage_Flat = new UnitStat() { readableName = "Additional arcane damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arcane_Damage_AddPercent = new UnitStat() { readableName = "Increased arcane damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arcane_Damage_MultiplyPercent = new UnitStat() { readableName = "More arcane damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arcane_DamageTaken_Flat = new UnitStat() { readableName = "Additional arcane damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arcane_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased arcane damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Arcane_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More arcane damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Astral
    public UnitStat Astral_Damage_Flat = new UnitStat() { readableName = "Additional astral damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Astral_Damage_AddPercent = new UnitStat() { readableName = "Increased astral damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Astral_Damage_MultiplyPercent = new UnitStat() { readableName = "More astral damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Astral_DamageTaken_Flat = new UnitStat() { readableName = "Additional astral damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Astral_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased astral damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Astral_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More astral damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Earth
    public UnitStat Earth_Damage_Flat = new UnitStat() { readableName = "Additional earth damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Earth_Damage_AddPercent = new UnitStat() { readableName = "Increased earth damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Earth_Damage_MultiplyPercent = new UnitStat() { readableName = "More earth damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Earth_DamageTaken_Flat = new UnitStat() { readableName = "Additional earth damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Earth_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased earth damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Earth_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More earth damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Electricity
    public UnitStat Electricity_Damage_Flat = new UnitStat() { readableName = "Additional electricity damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Electricity_Damage_AddPercent = new UnitStat() { readableName = "Increased electricity damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Electricity_Damage_MultiplyPercent = new UnitStat() { readableName = "More electricity damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Electricity_DamageTaken_Flat = new UnitStat() { readableName = "Additional electricity damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Electricity_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased electricity damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Electricity_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More electricity damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Ethereal
    public UnitStat Ethereal_Damage_Flat = new UnitStat() { readableName = "Additional ethereal damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ethereal_Damage_AddPercent = new UnitStat() { readableName = "Increased ethereal damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ethereal_Damage_MultiplyPercent = new UnitStat() { readableName = "More ethereal damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ethereal_DamageTaken_Flat = new UnitStat() { readableName = "Additional ethereal damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ethereal_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased ethereal damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ethereal_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More ethereal damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Fire
    public UnitStat Fire_Damage_Flat = new UnitStat() { readableName = "Additional fire damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Fire_Damage_AddPercent = new UnitStat() { readableName = "Increased fire damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Fire_Damage_MultiplyPercent = new UnitStat() { readableName = "More fire damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Fire_DamageTaken_Flat = new UnitStat() { readableName = "Additional fire damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Fire_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased fire damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Fire_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More fire damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Ice
    public UnitStat Ice_Damage_Flat = new UnitStat() { readableName = "Additional ice damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ice_Damage_AddPercent = new UnitStat() { readableName = "Increased ice damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ice_Damage_MultiplyPercent = new UnitStat() { readableName = "More ice damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ice_DamageTaken_Flat = new UnitStat() { readableName = "Additional ice damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ice_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased ice damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ice_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More ice damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Kinetic
    public UnitStat Kinetic_Damage_Flat = new UnitStat() { readableName = "Additional kinetic damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Kinetic_Damage_AddPercent = new UnitStat() { readableName = "Increased kinetic damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Kinetic_Damage_MultiplyPercent = new UnitStat() { readableName = "More kinetic damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Kinetic_DamageTaken_Flat = new UnitStat() { readableName = "Additional kinetic damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Kinetic_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased kinetic damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Kinetic_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More kinetic damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Life
    public UnitStat Life_Damage_Flat = new UnitStat() { readableName = "Additional life damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Life_Damage_AddPercent = new UnitStat() { readableName = "Increased life damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Life_Damage_MultiplyPercent = new UnitStat() { readableName = "More life damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Life_DamageTaken_Flat = new UnitStat() { readableName = "Additional life damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Life_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased life damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Life_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More life damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    //Water
    public UnitStat Water_Damage_Flat = new UnitStat() { readableName = "Additional water damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Water_Damage_AddPercent = new UnitStat() { readableName = "Increased water damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Water_Damage_MultiplyPercent = new UnitStat() { readableName = "More water damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Water_DamageTaken_Flat = new UnitStat() { readableName = "Additional water damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Water_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased water damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Water_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More water damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    #endregion
    public UnitStat GlobalDamage_Damage_AddPercent = new UnitStat() { readableName = "Increased global damage", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat GlobalDamage_Damage_MultiplyPercent = new UnitStat() { readableName = "More global damage", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat GlobalDamage_DamageTaken_AddPercent = new UnitStat() { readableName = "Increased global damage received", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat GlobalDamage_DamageTaken_MultiplyPercent = new UnitStat() { readableName = "More global damage received", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat MoveSpeed { get; private set; } = new UnitStat() { readableName = "Move speed", value = 8.4315f, defaultValue = -1f , sourceAvailability = StatSourceAvailability.None };
    public UnitStat MoveSpeed_Rate_AddPercent = new UnitStat() { readableName = "Increased move speed", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat MoveSpeed_Rate_MultiplyPercent = new UnitStat() { readableName = "More move speed", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat SprintSpeed_Rate_AddPercent = new UnitStat() { readableName = "Increased sprint speed", value = 1.3f, defaultValue = 1.3f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat CastmoveSpeed_Rate_MultiplyPercent = new UnitStat() { readableName = "More sprint speed", value = .5f, defaultValue = .5f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Cast_Rate_Flat = new UnitStat() { readableName = "Flat cast time", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Cast_Rate_AddPercent = new UnitStat() { readableName = "Increased cast speed", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Cast_Rate_MultiplyPercent = new UnitStat() { readableName = "More cast speed", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Attack_Rate_AddPercent = new UnitStat() { readableName = "Increased attack speed", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Attack_Rate_MultiplyPercent = new UnitStat() { readableName = "More attack speed", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Projectile_Speed_AddPercent = new UnitStat() { readableName = "Increased projectile speed", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Projectile_Speed_MultiplyPercent = new UnitStat() { readableName = "More projectile speed", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Ability_Area_AddPercent = new UnitStat() { readableName = "Increased ability radius", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };
    public UnitStat Ability_Area_MultiplyPercent = new UnitStat() { readableName = "More ability radius", value = 1f, defaultValue = 1f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Ability_Chains_Flat = new UnitStat() { readableName = "Additional ability chain targets", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };

    public UnitStat Ability_Projectiles_Flat = new UnitStat() { readableName = "Additional ability projectiles", value = 0f, defaultValue = 0f , sourceAvailability = StatSourceAvailability.All };

    public void IncreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        if (method == ModifierGroup.EMethod.Flat)
        {
            statField.value += mod;
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            statField.value += mod;
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            statField.value *= mod;
        }
    }

    public void DecreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        if (method == ModifierGroup.EMethod.Flat)
        {
            statField.value -= mod;
        }
        else if (method == ModifierGroup.EMethod.AddPercent)
        {
            statField.value -= mod;
        }
        else if (method == ModifierGroup.EMethod.MultiplyPercent)
        {
            statField.value /= mod;
        }
    }

    public float GetUnitCastTime(Ability ability)
    {
        return (ability.aSchoolRune.baseCastSpeed - Cast_Rate_Flat.value) / (1 + Cast_Rate_AddPercent.value) / Cast_Rate_MultiplyPercent.value;
    }
}

[Serializable]
public class UnitStat
{
    public float value;
    public float defaultValue;
    public string readableName;
    public string statScreenSymbol = "";
    public bool displayOnStatScreen = true;
    public StatSourceAvailability sourceAvailability;
}

public enum StatSourceAvailability
{
    All,
    None
}