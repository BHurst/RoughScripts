using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Aura : FormRune
{
    public FormRune_Aura()
    {
        runeName = "Aura";
        runeDescription = "A form which persists around the target.";
        runeImageLocation = "Abilities/Runes/Forms/Aura";
        formCastAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Aura;
        hitType = FormRune.HitType.DoT;
        //Implicit
        formDuration = 10f;
        formInterval = .20f;
        formArea = 2f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on channel duration to {3} targets in {4}m around the main target for {5} seconds.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            ability.snapshot.area,
            ability.snapshot.duration);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Deals from {0} to {1} {2} damage based on how long the ability is charged to {3} targets in {4}m around the main target for {5} seconds.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            ability.snapshot.area,
            ability.snapshot.duration);
        }
        else
        {
            return string.Format("Deals {0} {1} damage to {2} targets in {3}m around the main target for {4} seconds.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            ability.snapshot.area,
            ability.snapshot.duration);
        }
    }
}