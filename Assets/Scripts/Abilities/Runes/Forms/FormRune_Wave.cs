using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Wave : FormRune
{
    public FormRune_Wave()
    {
        runeName = "Wave";
        runeDescription = "An expansive conical form.";
        runeImageLocation = "Abilities/Runes/Forms/Wave";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Wave;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 1f;
        formArea = 4f;
        //Tertiary
        formDamageMod = .4f;
        formResourceCostMod = 1.5f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Fires an expanding wave that deals from {0} to {1} {2} damage based on channel duration to all targets in its path.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Fires an expanding wave that deals from {0} to {1} {2} damage based on how long the ability is charged to all targets in its path.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else
        {
            return string.Format("Fires an expanding wave that deals {0} {1} damage to all targets in its path.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
    }
}