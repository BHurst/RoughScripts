using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bonus
{
    public Modifier.StatModifiers Name;
    public float mod = 0;

    public float BonusDamageFlat = 0;
    public float BonusDamagePercent = 1;
    public float BonusHealFlat = 0;
    public float BonusHealRatePercent = 1;
    public float BonusAttackRateFlat = 0;
    public float BonusAttackRatePercent = 1;
    public float BonusCastSpeedFlat = 0;
    public float BonusCastSpeedPercent = 1;
    public float BonusMovementSpeedFlat = 0;
    public float BonusMovementSpeedPercent = 1;
    public float BonusAllResistanceFlat = 0;
    public float BonusAllResistancePercent = 1;
    public float BonusDefenceFlat = 0;
    public float BonusDefencePercent = 1;
    public float BonusCooldownReductionFlat = 0;
    public float BonusCooldownReductionPercent = 1;
    public float BonusMoveSpeedFlat = 0;
    public float BonusMoveSpeedPercent = 1;
    public float BonusTurnSpeedPercent = 1;
    public float BonusAccelerationPercent = 1;
}