using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitStats
{
    #region Basic Stats
    public float Health_Current = 100;
    public float Health_Max = 100;
    public float Health_Max_Default = 100;
    public UnitStat Health_Max_Flat = new() { valueCollection = new(), readableName = "Additional max health", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Health_Max_AddPercent = new() { valueCollection = new(), readableName = "Increased max health", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Health_Max_MultiplyPercent = new() { valueCollection = new(), readableName = "More max health", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public float Health_Regeneration = 0;
    public UnitStat Health_Regeneration_Flat = new() { valueCollection = new(), readableName = "Additional health regeneration per second", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Health_Regeneration_AddPercent = new() { valueCollection = new(), readableName = "Increased health regeneration", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Health_Regeneration_MultiplyPercent = new() { valueCollection = new(), readableName = "More health regeneration", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public float Mana_Current = 100;
    public float Mana_Max = 100;
    public float Mana_Max_Default = 100;
    public UnitStat Mana_Max_Flat = new() { valueCollection = new(), readableName = "Additional max mana", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Mana_Max_AddPercent = new() { valueCollection = new(), readableName = "Increased max mana", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Mana_Max_MultiplyPercent = new() { valueCollection = new(), readableName = "More max mana", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public float Mana_Regeneration = 0;
    public UnitStat Mana_Regeneration_Flat = new() { valueCollection = new(), readableName = "Additional mana regeneration per second", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Mana_Regeneration_AddPercent = new() { valueCollection = new(), readableName = "Increased mana regeneration", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Mana_Regeneration_MultiplyPercent = new() { valueCollection = new(), readableName = "More mana regeneration", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public UnitStat Mana_Cost_AddPercent = new() { valueCollection = new(), readableName = "Mana cost reduction", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Mana_Cost_MultiplyPercent = new() { valueCollection = new(), readableName = "More mana cost reduction", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public UnitStat GlobalDamage_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased global damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat GlobalDamage_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More global damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat GlobalHitDamage_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased global hit damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat GlobalHitDamage_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More global hit damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat GlobalDoTDamage_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased global damage over time", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat GlobalDoTDamage_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More global damage over time", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public UnitStat GlobalDamage_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Damage resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public float MovementSpeed = 10;
    public float MovementSpeed_Default = 10;
    public UnitStat Movement_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased move speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Movement_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More move speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat Sprint_Rate_AddPercent = new() { valueCollection = new(), readableName = "Sprint speed increase", method = ModifierGroup.EMethod.AddPercent, value = .3f, defaultValue = .3f };
    public UnitStat Castmove_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "Reduced speed while casting", method = ModifierGroup.EMethod.MultiplyPercent, value = .5f, defaultValue = .5f };

    public UnitStat Cast_Rate_Flat = new() { valueCollection = new(), readableName = "Flat cast time", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Cast_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased cast speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Cast_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More cast speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };

    public UnitStat Attack_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased attack speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Attack_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More attack speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    #endregion
    #region Element Bonuses
    //Air
    public UnitStat Air_Damage_Flat = new() { valueCollection = new(), readableName = "Additional air damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Air_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased air damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Air_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More air damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Air_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Air resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Arcane
    public UnitStat Arcane_Damage_Flat = new() { valueCollection = new(), readableName = "Additional arcane damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Arcane_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased arcane damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Arcane_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More arcane damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Arcane_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Arcane resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Astral
    public UnitStat Astral_Damage_Flat = new() { valueCollection = new(), readableName = "Additional astral damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Astral_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased astral damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Astral_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More astral damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Astral_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Astral resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Earth
    public UnitStat Earth_Damage_Flat = new() { valueCollection = new(), readableName = "Additional earth damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Earth_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased earth damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Earth_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More earth damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Earth_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Earth resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Electricity
    public UnitStat Electricity_Damage_Flat = new() { valueCollection = new(), readableName = "Additional electricity damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Electricity_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased electricity damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Electricity_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More electricity damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Electricity_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Electricity resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Ethereal
    public UnitStat Ethereal_Damage_Flat = new() { valueCollection = new(), readableName = "Additional ethereal damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased ethereal damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ethereal_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More ethereal damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Ethereal_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Ethereal resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Fire
    public UnitStat Fire_Damage_Flat = new() { valueCollection = new(), readableName = "Additional fire damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Fire_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased fire damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Fire_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More fire damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Fire_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Fire resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Ice
    public UnitStat Ice_Damage_Flat = new() { valueCollection = new(), readableName = "Additional ice damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ice_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased ice damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ice_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More ice damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Ice_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Ice resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Kinetic
    public UnitStat Kinetic_Damage_Flat = new() { valueCollection = new(), readableName = "Additional kinetic damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased kinetic damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Kinetic_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More kinetic damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Kinetic_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Kinetic resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Life
    public UnitStat Life_Damage_Flat = new() { valueCollection = new(), readableName = "Additional life damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Life_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased life damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Life_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More life damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Life_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Life resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    //Water
    public UnitStat Water_Damage_Flat = new() { valueCollection = new(), readableName = "Additional water damage", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Water_Damage_AddPercent = new() { valueCollection = new(), readableName = "Increased water damage", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Water_Damage_MultiplyPercent = new() { valueCollection = new(), readableName = "More water damage", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    
    public UnitStat Water_Resistance_AddPercent = new() { valueCollection = new(), readableName = "Water resistance", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    #endregion
    #region AbilityModifiers
    public UnitStat Projectile_Rate_AddPercent = new() { valueCollection = new(), readableName = "Increased projectile speed", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Projectile_Rate_MultiplyPercent = new() { valueCollection = new(), readableName = "More projectile speed", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat Ability_Area_AddPercent = new() { valueCollection = new(), readableName = "Increased ability radius", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ability_Area_MultiplyPercent = new() { valueCollection = new(), readableName = "More ability radius", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat Ability_Duration_AddPercent = new() { valueCollection = new(), readableName = "Increased ability duration", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    public UnitStat Ability_Duration_MultiplyPercent = new() { valueCollection = new(), readableName = "More ability duration", method = ModifierGroup.EMethod.MultiplyPercent, value = 1, defaultValue = 1 };
    public UnitStat Ability_Chains_Flat = new() { valueCollection = new(), readableName = "Additional ability chain targets", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    public UnitStat Ability_Projectiles_Flat = new() { valueCollection = new(), readableName = "Additional ability projectiles", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0 };
    #endregion
    #region CastModeModifiers
    public float Channel_Current = 0;
    public float Channel_Default = .6f;
    public float Channel_Max = 1.4f;
    public float Channel_Rate = .2f;
    public UnitStat Channel_Max_MultiplyPercent = new() { valueCollection = new(), readableName = "Maximum strength for channeled abilities", method = ModifierGroup.EMethod.AddPercent, value = 1, defaultValue = 1 };
    public UnitStat Charge_Max_AddPercent = new() { valueCollection = new(), readableName = "Maximum charge time and damage for charge abilities", method = ModifierGroup.EMethod.AddPercent, value = 0, defaultValue = 0 };
    #endregion
    #region Form Modifiers
    public float baseReserveRecoveryTime = 1.6f;

    public int AirReserve_Current = 0;
    public int AirReserve_Max = 2;
    public UnitStat AirReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max air Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int ArcaneReserve_Current = 0;
    public int ArcaneReserve_Max = 2;
    public UnitStat ArcaneReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max arcane Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int AstralReserve_Current = 0;
    public int AstralReserve_Max = 2;
    public UnitStat AstralReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max astral Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int EarthReserve_Current = 0;
    public int EarthReserve_Max = 2;
    public UnitStat EarthReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max earth Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int ElectricityReserve_Current = 0;
    public int ElectricityReserve_Max = 2;
    public UnitStat ElectricityReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max electricity Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int EtherealReserve_Current = 0;
    public int EtherealReserve_Max = 2;
    public UnitStat EtherealReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max ethereal Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int FireReserve_Current = 0;
    public int FireReserve_Max = 2;
    public UnitStat FireReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max fire Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int IceReserve_Current = 0;
    public int IceReserve_Max = 2;
    public UnitStat IceReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max ice Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int KineticReserve_Current = 0;
    public int KineticReserve_Max = 2;
    public UnitStat KineticReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max kinetic Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int LifeReserve_Current = 0;
    public int LifeReserve_Max = 2;
    public UnitStat LifeReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max life Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    public int WaterReserve_Current = 0;
    public int WaterReserve_Max = 2;
    public UnitStat WaterReserve_Max_Flat = new() { valueCollection = new(), readableName = "Max water Reserves", method = ModifierGroup.EMethod.Flat, value = 0, defaultValue = 0, displayOnStatScreen = false };
    #endregion
    public void IncreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        statField.Increase(mod);

        if (stat == ModifierGroup.EStat.Health)
            FixHealth();

        if (stat == ModifierGroup.EStat.Mana)
            FixMana();

        if (stat == ModifierGroup.EStat.Movement)
            FixMovement();
    }

    public void DecreaseStat(ModifierGroup.EStat stat, ModifierGroup.EAspect aspect, ModifierGroup.EMethod method, float mod)
    {
        UnitStat statField = (UnitStat)this.GetType().GetField(stat.ToString() + "_" + aspect.ToString() + "_" + method.ToString()).GetValue(this);

        statField.Decrease(mod);

        if (stat == ModifierGroup.EStat.Health)
            FixHealth();

        if (stat == ModifierGroup.EStat.Mana)
            FixMana();

        if (stat == ModifierGroup.EStat.Movement)
            FixMovement();
    }

    private void FixHealth()
    {
        float oldPercent = Health_Current / Health_Max;

        Health_Max = (Health_Max_Default + Health_Max_Flat.value) * (1 + Health_Max_AddPercent.value) * Health_Max_MultiplyPercent.value;
        Health_Regeneration = (Health_Max / 200 + Health_Regeneration_Flat.value) * (1 + Health_Regeneration_AddPercent.value) * Health_Regeneration_MultiplyPercent.value;

        Health_Current = oldPercent * Health_Max;
    }

    private void FixMana()
    {
        float oldPercent = Mana_Current / Mana_Max;

        Mana_Max = (Mana_Max_Default + Mana_Max_Flat.value) * (1 + Mana_Max_AddPercent.value) * Mana_Max_MultiplyPercent.value;
        Mana_Regeneration = (Mana_Max / 120 + Mana_Regeneration_Flat.value) * (1 + Mana_Regeneration_AddPercent.value) * Mana_Regeneration_MultiplyPercent.value;

        Mana_Current = oldPercent * Mana_Max;
    }

    private void FixMovement()
    {
        MovementSpeed = MovementSpeed_Default * (1 + Movement_Rate_AddPercent.value) * Movement_Rate_MultiplyPercent.value;
    }

    public float GetUnitCastTime(Ability ability)
    {
        return (ability.schoolRune.baseCastTime - Cast_Rate_Flat.value) / (1 + Cast_Rate_AddPercent.value) / Cast_Rate_MultiplyPercent.value;
    }

    public float GetArea(Ability ability)
    {
        return ability.formRune.formArea * (1 + Ability_Area_AddPercent.value) * Ability_Area_MultiplyPercent.value;
    }

    public float GetDuration(Ability ability)
    {
        return ability.formRune.formDuration * (1 + Ability_Duration_AddPercent.value) * Ability_Duration_MultiplyPercent.value;
    }

    public void InitializeStats()
    {
        Health_Regeneration = (Health_Max / 200 + Health_Regeneration_Flat.value) * (1 + Health_Regeneration_AddPercent.value) * Health_Regeneration_MultiplyPercent.value;
        Mana_Regeneration = (Mana_Max / 120 + Mana_Regeneration_Flat.value) * (1 + Mana_Regeneration_AddPercent.value) * Mana_Regeneration_MultiplyPercent.value;
    }
    #region Reserve Form Methods
    public void RefillReserve()
    {
        AirReserve_Current = AirReserve_Max;
        ArcaneReserve_Current = ArcaneReserve_Max;
        AstralReserve_Current = AstralReserve_Max;
        EarthReserve_Current = EarthReserve_Max;
        ElectricityReserve_Current = ElectricityReserve_Max;
        EtherealReserve_Current = EtherealReserve_Max;
        FireReserve_Current = FireReserve_Max;
        IceReserve_Current = IceReserve_Max;
        KineticReserve_Current = KineticReserve_Max;
        LifeReserve_Current = LifeReserve_Max;
        WaterReserve_Current = WaterReserve_Max;
    }
    
    public void RefillReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                AirReserve_Current = AirReserve_Max;
                break;
            case Rune.SchoolRuneTag.Arcane:
                ArcaneReserve_Current = ArcaneReserve_Max;
                break;
            case Rune.SchoolRuneTag.Astral:
                AstralReserve_Current = AstralReserve_Max;
                break;
            case Rune.SchoolRuneTag.Earth:
                EarthReserve_Current = EarthReserve_Max;
                break;
            case Rune.SchoolRuneTag.Electricity:
                ElectricityReserve_Current = ElectricityReserve_Max;
                break;
            case Rune.SchoolRuneTag.Ethereal:
                EtherealReserve_Current = EtherealReserve_Max;
                break;
            case Rune.SchoolRuneTag.Fire:
                FireReserve_Current = FireReserve_Max;
                break;
            case Rune.SchoolRuneTag.Ice:
                IceReserve_Current = IceReserve_Max;
                break;
            case Rune.SchoolRuneTag.Kinetic:
                KineticReserve_Current = KineticReserve_Max;
                break;
            case Rune.SchoolRuneTag.Life:
                LifeReserve_Current = LifeReserve_Max;
                break;
            case Rune.SchoolRuneTag.Water:
                WaterReserve_Current = WaterReserve_Max;
                break;
            default:
                break;
        }
    }

    public void RecoverReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                if (AirReserve_Current < AirReserve_Max)
                {
                    AirReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (ArcaneReserve_Current < ArcaneReserve_Max)
                {
                    ArcaneReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (AstralReserve_Current < AstralReserve_Max)
                {
                    AstralReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (EarthReserve_Current < EarthReserve_Max)
                {
                    EarthReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (ElectricityReserve_Current < ElectricityReserve_Max)
                {
                    ElectricityReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (EtherealReserve_Current < EtherealReserve_Max)
                {
                    EtherealReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (FireReserve_Current < FireReserve_Max)
                {
                    FireReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (IceReserve_Current < IceReserve_Max)
                {
                    IceReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (KineticReserve_Current < KineticReserve_Max)
                {
                    KineticReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (LifeReserve_Current < LifeReserve_Max)
                {
                    LifeReserve_Current++;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (WaterReserve_Current < WaterReserve_Max)
                {
                    WaterReserve_Current++;
                }
                break;
            default:
                break;
        }
    }

    public void ExpendCharge(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                if (AirReserve_Current >= 0)
                {
                    AirReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (ArcaneReserve_Current >= 0)
                {
                    ArcaneReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (AstralReserve_Current >= 0)
                {
                    AstralReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (EarthReserve_Current >= 0)
                {
                    EarthReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (ElectricityReserve_Current >= 0)
                {
                    ElectricityReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (EtherealReserve_Current >= 0)
                {
                    EtherealReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (FireReserve_Current >= 0)
                {
                    FireReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (IceReserve_Current >= 0)
                {
                    IceReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (KineticReserve_Current >= 0)
                {
                    KineticReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (LifeReserve_Current >= 0)
                {
                    LifeReserve_Current--;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (WaterReserve_Current >= 0)
                {
                    WaterReserve_Current--;
                }
                break;
            default:
                break;
        }
    }

    public int CheckReserves(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return AirReserve_Current;
            case Rune.SchoolRuneTag.Arcane:
                return ArcaneReserve_Current;
            case Rune.SchoolRuneTag.Astral:
                return AstralReserve_Current;
            case Rune.SchoolRuneTag.Earth:
                return EarthReserve_Current;
            case Rune.SchoolRuneTag.Electricity:
                return ElectricityReserve_Current;
            case Rune.SchoolRuneTag.Ethereal:
                return EtherealReserve_Current;
            case Rune.SchoolRuneTag.Fire:
                return FireReserve_Current;
            case Rune.SchoolRuneTag.Ice:
                return IceReserve_Current;
            case Rune.SchoolRuneTag.Kinetic:
                return KineticReserve_Current;
            case Rune.SchoolRuneTag.Life:
                return LifeReserve_Current;
            case Rune.SchoolRuneTag.Water:
                return WaterReserve_Current;
            default:
                return 0;
        }
    }

    public int CheckMaxReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return AirReserve_Max;
            case Rune.SchoolRuneTag.Arcane:
                return ArcaneReserve_Max;
            case Rune.SchoolRuneTag.Astral:
                return AstralReserve_Max;
            case Rune.SchoolRuneTag.Earth:
                return EarthReserve_Max;
            case Rune.SchoolRuneTag.Electricity:
                return ElectricityReserve_Max;
            case Rune.SchoolRuneTag.Ethereal:
                return EtherealReserve_Max;
            case Rune.SchoolRuneTag.Fire:
                return FireReserve_Max;
            case Rune.SchoolRuneTag.Ice:
                return IceReserve_Max;
            case Rune.SchoolRuneTag.Kinetic:
                return KineticReserve_Max;
            case Rune.SchoolRuneTag.Life:
                return LifeReserve_Max;
            case Rune.SchoolRuneTag.Water:
                return WaterReserve_Max;
            default:
                return 0;
        }
    }

    public bool IsReserveFull(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return AirReserve_Current == AirReserve_Max;
            case Rune.SchoolRuneTag.Arcane:
                return ArcaneReserve_Current == ArcaneReserve_Max;
            case Rune.SchoolRuneTag.Astral:
                return AstralReserve_Current == AstralReserve_Max;
            case Rune.SchoolRuneTag.Earth:
                return EarthReserve_Current == EarthReserve_Max;
            case Rune.SchoolRuneTag.Electricity:
                return ElectricityReserve_Current == ElectricityReserve_Max;
            case Rune.SchoolRuneTag.Ethereal:
                return EtherealReserve_Current == EtherealReserve_Max;
            case Rune.SchoolRuneTag.Fire:
                return FireReserve_Current == FireReserve_Max;
            case Rune.SchoolRuneTag.Ice:
                return IceReserve_Current == IceReserve_Max;
            case Rune.SchoolRuneTag.Kinetic:
                return KineticReserve_Current == KineticReserve_Max;
            case Rune.SchoolRuneTag.Life:
                return LifeReserve_Current == LifeReserve_Max;
            case Rune.SchoolRuneTag.Water:
                return WaterReserve_Current == WaterReserve_Max;
            default:
                return true;
        }
    }
    #endregion
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
                    full *= (1 + val);

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