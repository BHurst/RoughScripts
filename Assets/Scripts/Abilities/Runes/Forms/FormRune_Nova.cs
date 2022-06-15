using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Nova : FormRune
{
    public FormRune_Nova()
    {
        runeName = "Nova";
        runeDescription = "An explosion of energy radiating from the target.";
        runeImageLocation = "Abilities/Runes/Forms/Nova";
        formCastAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Nova;
        hitType = RootAbility.HitType.Hit;
        //Implicit
        formDuration = 0f;
        formArea = 5f;
        formMaxAdditionalTargets = 10;
        //Tertiary
        formDamageMod = .3f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on channel duration to the closest {3} targets within {4}m.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            unitStats.GetArea(ability));
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on how long the ability is charged to the closest {3} targets within {4}m.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            unitStats.GetArea(ability));
        }
        else
        {
            return string.Format("Deals {0} {1} damage to the closest {2} targets within {3}m.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            unitStats.GetArea(ability));
        }
    }
}