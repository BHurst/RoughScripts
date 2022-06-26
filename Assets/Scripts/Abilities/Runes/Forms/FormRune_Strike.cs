using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Strike : FormRune
{
    public FormRune_Strike()
    {
        runeName = "Strike";
        runeDescription = "A concentrated blast drawn down upon the target after a delay.";
        runeImageLocation = "Abilities/Runes/Forms/Strike";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Strike;
        hitType = RootAbility.HitType.Hit;
        targettingType = RootAbility.TargettingType.Multiple;
        //Implicit
        formDuration = 1.5f;
        formArea = 2f;
        //Tertiary
        formDamageMod = 1.2f;
        formAdditionalTargetsDamageMod = .6f;
        formResourceCostMod = 1.4f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Calls down a bolt of energy dealing from {0} to {1} {2} damage based on channel duration to the target and {0} {1} damage to surrounding targets within {3}m after {4}s.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            unitStats.GetArea(ability),
            unitStats.GetDuration(ability));
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Calls down a bolt of energy dealing from {0} to {1} {2} damage based on how long the ability is charged to the target and {0} {1} damage to surrounding targets within {3}m after {4}s.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            unitStats.GetArea(ability),
            unitStats.GetDuration(ability));
        }
        else
        {
            return string.Format("Calls down a bolt of energy dealing {0} {1} damage to the target and {0} {1} damage to surrounding targets within {2}m after {3}s.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            unitStats.GetArea(ability),
            unitStats.GetDuration(ability));
        }
    }
}