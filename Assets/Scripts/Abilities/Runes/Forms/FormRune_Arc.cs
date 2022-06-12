using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Arc : FormRune
{
    public FormRune_Arc()
    {
        runeName = "Arc";
        runeDescription = "A form which chains between nearby targets.";
        runeImageLocation = "Abilities/Runes/Forms/Arc";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Arc;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 0f;
        formArea = 5f;
        formMaxAdditionalTargets = 2;
        //Tertiary
        formDamageMod = .4f;
        formResourceCostMod = 0f;
        formCooldownMod = 0f;
        formCastSpeedMod = 0f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);

        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on channel duration to the target, and up to {3} additional targets nearby.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets + unitStats.Ability_Chains_Flat.value);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on how long the ability is charged to the target, and up to {3} additional targets nearby.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets + unitStats.Ability_Chains_Flat.value);
        }
        else
        {
            return string.Format("Deals {0} {1} damage to the target, and up to {2} additional targets nearby.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets + unitStats.Ability_Chains_Flat.value);
        }
    }
}