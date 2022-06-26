using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Burst : FormRune
{
    public FormRune_Burst()
    {
        runeName = "Burst";
        runeDescription = "A narrow spout of energy.";
        runeImageLocation = "Abilities/Runes/Forms/Burst";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Burst;
        hitType = RootAbility.HitType.MultiHit;
        targettingType = RootAbility.TargettingType.Single;
        //Implicit
        formDuration = .25f;
        formInterval = .05f;
        formArea = 10f;
        //Tertiary
        formDamageMod = .05f;
        formResourceCostMod = 1.25f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Rapidly deals from {0} to {1} {2} damage based on channel duration to the first target hit every {3} seconds.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Rapidly deals from {0} to {1} {2} damage based on how long the ability is charged to the first target hit every {3} seconds, for {4} seconds.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval,
            ability.snapshot.duration);
        }
        else
        {
            return string.Format("Rapidly deals {0} {1} damage to the first target hit every {2} seconds, for {3} seconds.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval,
            ability.snapshot.duration);
        }
    }
}