using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Orb : FormRune
{
    public FormRune_Orb()
    {
        runeName = "Orb";
        runeDescription = "A slow moving projectile.";
        runeImageLocation = "Abilities/Runes/Forms/Orb";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Orb;
        hitType = RootAbility.HitType.Hit;
        targettingType = RootAbility.TargettingType.Single;
        //Implicit
        formDuration = 10f;
        formArea = 0f;
        formSpeed = 15f;
        //Tertiary
        formDamageMod = 1f;
        formResourceCostMod = .75f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);
        if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Channel)
        {
            return string.Format("Fires a slow moving projectile that deals from {0} to {1} {2} damage based on channel duration to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else if (ability.castModeRune.castModeRuneType == CastModeRuneTag.Charge)
        {
            return string.Format("Fires a slow moving projectile that deals from {0} to {1} {2} damage based on how long the ability is charged to the target.",
            MathF.Round(ability.snapshot.chargeAndChannelMinimum * 100) / 100,
            MathF.Round(ability.snapshot.chargeAndChannelMaximum * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
        else
        {
            return string.Format("Fires a slow moving projectile that deals {0} {1} damage to the target.",
            MathF.Round(ability.snapshot.damage * 100) / 100,
            ability.schoolRune.schoolRuneType);
        }
    }
}