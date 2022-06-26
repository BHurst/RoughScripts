using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Point : FormRune
{
    public FormRune_Point()
    {
        runeName = "Point";
        runeDescription = "An instantaneous snap of magic at a small point.";
        runeImageLocation = "Abilities/Runes/Forms/Point";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Point;
        hitType = RootAbility.HitType.Hit;
        targettingType = RootAbility.TargettingType.Single;
        //Implicit
        formDuration = 0f;
        formArea = .1f;
        //Tertiary
        formDamageMod = .5f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Instantaneous deals from {0} to {1} {2} damage based on channel duration to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Instantaneous deals from {0} to {1} {2} damage based on how long the ability is charged to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else
        {
            return string.Format("Instantaneous deals {0} {1} damage to the target.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
    }
}