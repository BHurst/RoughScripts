using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Zone : FormRune
{
    public FormRune_Zone()
    {
        runeName = "Zone";
        runeDescription = "A large persistant area of magic.";
        runeImageLocation = "Abilities/Runes/Forms/Zone";
        formCastAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Zone;
        hitType = RootAbility.HitType.DoT;
        //Implicit
        formDuration = 5f;
        formInterval = .20f;
        formArea = 5f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1.25f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Creates an area at the target for {0} seconds, that deals from {1} to {2} {3} damage based on channel duration every {4} second to all targets within {5}m.",
            ability.snapshot.duration,
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval,
            ability.snapshot.area);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Creates an area at the target for {0} seconds, that deals from {1} to {2} {3} damage based on how long the ability is charged every {4} second to all targets within {5}m.",
            ability.snapshot.duration,
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval,
            ability.snapshot.area);
        }
        else
        {
            return string.Format("Creates an area at the target for {0} seconds, that deals {1} {2} damage every {3} second to all targets within {4}m.",
            ability.snapshot.duration,
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formInterval,
            ability.snapshot.area);
        }
    }
}