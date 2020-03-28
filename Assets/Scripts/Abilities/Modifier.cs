using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier {

    public StatModifiers Mod;
    public float ModAmount;

    public enum StatModifiers
    {
        AttackDamageMin,
        AttackDamageMax,
        BonusAttackDamageFlat,
        BonusAttackDamagePercent,
        MeleeRange,
        BonusSpellDamageFlat,
        BonusSpellDamagePercent,
        BonusDamagePercent,
        BonusHealFlat,
        BonusHealPercent,
        AttackSpeed,
        BonusAttackSpeedPercent,
        BonusCastSpeedPercent,
        MoveSpeed,
        BonusMoveSpeedFlat,
        BonusMoveSpeedPercent,
        JumpHeight,
        BonusJumpHeightFlat,
        BonusJumpHeightPercent,
        BaseTurnSpeed,
        BonusTurnSpeedPercent,
        BaseAcceleration,
        BonusAccelerationPercent,
        AllResistance,
        Defence,
        AllDamageReduction,
        CooldownReduction,
        PhysicalCritChance,
        PhysicalCritDamage,
        SpellCritChance,
        SpellCritDamage
    }
}