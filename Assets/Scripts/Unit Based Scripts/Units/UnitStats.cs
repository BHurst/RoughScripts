using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats
{
    public float AttackDamageMin = 0;
    public float AttackDamageMax = 0;
    public float BonusAttackDamageFlat = 0;
    private List<float> BonusAttackDamageFlatBonuses = new List<float>();
    public float BonusAttackDamagePercent = 0;
    private List<float> BonusAttackDamagePercentBonuses = new List<float>();

    public float BonusSpellDamageFlat = 0;
    private List<float> BonusSpellDamageFlatBonuses = new List<float>();
    public float BonusSpellDamagePercent = 1;
    private List<float> BonusSpellDamagePercentBonuses = new List<float>();

    public float BonusDamagePercent = 1;
    private List<float> BonusDamagePercentBonuses = new List<float>();

    public float BonusHealFlat = 0;
    private List<float> BonusHealFlatBonuses = new List<float>();
    public float BonusHealPercent = 1;
    private List<float> BonusHealPercentBonuses = new List<float>();

    public float AttackSpeed = 1;
    public float BonusAttackSpeedPercent = 1;
    private List<float> BonusAttackSpeedPercentBonuses = new List<float>();
    public float BonusCastSpeedPercent = 1;
    private List<float> BonusCastSpeedPercentBonuses = new List<float>();

    public float MoveSpeed = 3.5f;
    public float BonusMoveSpeedFlat = 0;
    private List<float> BonusMoveSpeedFlatBonuses = new List<float>();
    public float BonusMoveSpeedPercent = 1;
    private List<float> BonusMoveSpeedPercentBonuses = new List<float>();

    public float JumpHeight = 1f;
    public float BonusJumpHeightFlat = 0;
    private List<float> BonusJumpHeightFlatBonuses = new List<float>();
    public float BonusJumpHeightPercent = 1;
    private List<float> BonusJumpHeightPercentBonuses = new List<float>();

    public float BaseTurnSpeed = 270f;
    public float BonusTurnSpeedPercent = 1;
    private List<float> BonusTurnSpeedPercentBonuses = new List<float>();

    public float BaseAcceleration = 20f;
    public float BonusAccelerationPercent = 1;
    private List<float> BonusAccelerationPercentBonuses = new List<float>();

    public float AllResistance = 1;
    private List<float> AllResistanceBonuses = new List<float>();

    public float Defence = 1;
    private List<float> DefenceBonuses = new List<float>();

    public float AllDamageReduction = 1;
    private List<float> AllDamageReductionBonuses = new List<float>();

    public float CooldownReduction = 1;
    private List<float> CooldownReductionBonuses = new List<float>();

    public float PhysicalCritChance = 0;
    private List<float> PhysicalCritChanceBonuses = new List<float>();
    public float PhysicalCritDamage = 0;
    private List<float> PhysicalCritDamageBonuses = new List<float>();

    public float SpellCritChance = 0;
    private List<float> SpellCritChanceBonuses = new List<float>();
    public float SpellCritDamage = 2;
    private List<float> SpellCritDamageBonuses = new List<float>();

    public void IncreaseStat(Modifier.StatModifiers stat, float mod)
    {
        switch (stat)
        {
            case Modifier.StatModifiers.BonusAttackDamageFlat:
                BonusAttackDamageFlatBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusAttackDamagePercent:
                BonusAttackDamagePercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusSpellDamageFlat:
                BonusSpellDamageFlatBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusSpellDamagePercent:
                BonusSpellDamagePercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusDamagePercent:
                BonusDamagePercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusHealFlat:
                BonusHealFlatBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusHealPercent:
                BonusHealPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusAttackSpeedPercent:
                BonusAttackSpeedPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusCastSpeedPercent:
                BonusCastSpeedPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusMoveSpeedFlat:
                BonusMoveSpeedFlatBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusMoveSpeedPercent:
                BonusMoveSpeedPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusJumpHeightFlat:
                BonusJumpHeightFlatBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusJumpHeightPercent:
                BonusJumpHeightPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusTurnSpeedPercent:
                BonusTurnSpeedPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.BonusAccelerationPercent:
                BonusAccelerationPercentBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.AllResistance:
                AllResistanceBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.Defence:
                DefenceBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.AllDamageReduction:
                AllDamageReductionBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.CooldownReduction:
                CooldownReductionBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.PhysicalCritChance:
                PhysicalCritChanceBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.PhysicalCritDamage:
                PhysicalCritDamageBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.SpellCritChance:
                SpellCritChanceBonuses.Add(mod);
                break;
            case Modifier.StatModifiers.SpellCritDamage:
                SpellCritDamageBonuses.Add(mod);
                break;
            default:
                break;
        }
    }

    public void DecreaseStat(Modifier.StatModifiers stat, float mod)
    {
        switch (stat)
        {
            case Modifier.StatModifiers.BonusAttackDamageFlat:
                BonusAttackDamageFlatBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusAttackDamagePercent:
                BonusAttackDamagePercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusSpellDamageFlat:
                BonusSpellDamageFlatBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusSpellDamagePercent:
                BonusSpellDamagePercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusDamagePercent:
                BonusDamagePercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusHealFlat:
                BonusHealFlatBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusHealPercent:
                BonusHealPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusAttackSpeedPercent:
                BonusAttackSpeedPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusCastSpeedPercent:
                BonusCastSpeedPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusMoveSpeedFlat:
                BonusMoveSpeedFlatBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusMoveSpeedPercent:
                BonusMoveSpeedPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusJumpHeightFlat:
                BonusJumpHeightFlatBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusJumpHeightPercent:
                BonusJumpHeightPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusTurnSpeedPercent:
                BonusTurnSpeedPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.BonusAccelerationPercent:
                BonusAccelerationPercentBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.AllResistance:
                AllResistanceBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.Defence:
                DefenceBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.AllDamageReduction:
                AllDamageReductionBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.CooldownReduction:
                CooldownReductionBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.PhysicalCritChance:
                PhysicalCritChanceBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.PhysicalCritDamage:
                PhysicalCritDamageBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.SpellCritChance:
                SpellCritChanceBonuses.Remove(mod);
                break;
            case Modifier.StatModifiers.SpellCritDamage:
                SpellCritDamageBonuses.Remove(mod);
                break;
            default:
                break;
        }
    }

    public void RefreshAllStats()
    {
        ResetStats();
        foreach (var item in BonusAttackDamageFlatBonuses)
            BonusAttackDamageFlat += item;
        foreach (var item in BonusAttackDamagePercentBonuses)
            BonusAttackDamagePercent *= item;
        foreach (var item in BonusSpellDamageFlatBonuses)
            BonusSpellDamageFlat += item;
        foreach (var item in BonusSpellDamagePercentBonuses)
            BonusSpellDamagePercent *= item;
        foreach (var item in BonusDamagePercentBonuses)
            BonusDamagePercent *= item;
        foreach (var item in BonusHealFlatBonuses)
            BonusHealFlat += item;
        foreach (var item in BonusHealPercentBonuses)
            BonusHealPercent *= item;
        foreach (var item in BonusAttackSpeedPercentBonuses)
            BonusAttackSpeedPercent *= item;
        foreach (var item in BonusCastSpeedPercentBonuses)
            BonusCastSpeedPercent *= item;
        foreach (var item in BonusMoveSpeedFlatBonuses)
            BonusMoveSpeedFlat += item;
        foreach (var item in BonusMoveSpeedPercentBonuses)
            BonusMoveSpeedPercent *= item;
        foreach (var item in BonusJumpHeightFlatBonuses)
            BonusJumpHeightFlat += item;
        foreach (var item in BonusJumpHeightPercentBonuses)
            BonusJumpHeightPercent *= item;
        foreach (var item in BonusTurnSpeedPercentBonuses)
            BonusTurnSpeedPercent *= item;
        foreach (var item in BonusAccelerationPercentBonuses)
            BonusAccelerationPercent *= item;
        foreach (var item in AllDamageReductionBonuses)
            AllDamageReduction = AllDamageReduction - (AllDamageReduction * item);
        foreach (var item in AllResistanceBonuses)
            AllResistance = AllResistance - (AllResistance * item);
        foreach (var item in DefenceBonuses)
            Defence = Defence - (Defence * item);
        foreach (var item in CooldownReductionBonuses)
            CooldownReduction = CooldownReduction - (CooldownReduction * item);
        foreach (var item in PhysicalCritChanceBonuses)
            PhysicalCritChance += item;
        foreach (var item in PhysicalCritDamageBonuses)
            PhysicalCritDamage += item;
        foreach (var item in SpellCritChanceBonuses)
            SpellCritChance += item;
        foreach (var item in SpellCritDamageBonuses)
            SpellCritDamage += item;
    }

    public void CalculateStatBonuses(RootUnit character)
    {
        AttackDamageMin += character.attributes.Strength * .5f;
        AttackDamageMax += character.attributes.Strength * .5f;
        BonusAttackSpeedPercent *= 1 + (character.attributes.Agility * .01f);
        BonusCastSpeedPercent *= 1 + (character.attributes.Wisdom * .005f);
        BonusMoveSpeedPercent *= 1 + (character.attributes.Agility * .01f);
        AllDamageReduction *= 1 + (character.attributes.Willpower * .02f);
        //Stamina will affect health
        CooldownReduction *= 1 + (character.attributes.Skill * .01f);
        PhysicalCritChance += character.attributes.Agility * .002f;
        PhysicalCritDamage *= 1 + (character.attributes.Strength * .005f);
        SpellCritChance += character.attributes.Intellect * .005f;
        SpellCritDamage *= 1 + (character.attributes.Wisdom * .0075f);
    }

    public void ResetStats()
    {
        AttackDamageMin = 5;
        AttackDamageMax = 10;
        BonusAttackDamageFlat = 0;
        BonusAttackDamagePercent = 1;
        BonusSpellDamageFlat = 0;
        BonusSpellDamagePercent = 1;
        BonusDamagePercent = 1;
        BonusHealFlat = 0;
        BonusHealPercent = 1;
        AttackSpeed = 1;
        BonusAttackSpeedPercent = 1;
        BonusCastSpeedPercent = 1;
        MoveSpeed = 3.5f;
        BonusMoveSpeedFlat = 0;
        BonusMoveSpeedPercent = 1;
        JumpHeight = 1f;
        BonusJumpHeightFlat = 0;
        BonusJumpHeightPercent = 1;
        BaseTurnSpeed = 270;
        BonusTurnSpeedPercent = 1;
        BaseAcceleration = 20;
        BonusAccelerationPercent = 1;
        AllResistance = 1;
        Defence = 1;
        AllDamageReduction = 1;
        CooldownReduction = 1;
        PhysicalCritChance = .03f;
        PhysicalCritDamage = 1.5f;
        SpellCritChance = .03f;
        SpellCritDamage = 1.5f;
    }
}