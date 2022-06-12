using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Lance : FormRune
{
    public FormRune_Lance()
    {
        runeName = "Lance";
        runeDescription = "A narrow high speed projectile.";
        runeImageLocation = "Abilities/Runes/Forms/Lance";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Lance;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 2f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .8f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = .8f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Fires a fast moving projectile that deals from {0} to {1} {2} damage based on channel duration to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Fires a fast moving projectile that deals from {0} to {1} {2} damage based on how long the ability is charged to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else
        {
            return string.Format("Fires a fast moving projectile that deals {0} {1} damage to the target.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
    }
}