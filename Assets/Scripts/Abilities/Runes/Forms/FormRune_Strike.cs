using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Strike : FormRune
{
    public FormRune_Strike()
    {
        runeName = "Strike";
        runeDescription = "A concentrated source drawn down upon the target.";
        runeImageLocation = "Abilities/Runes/Forms/Strike";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Strike;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 0f;
        formArea = 2f;
        //Tertiary
        formDamageMod = 1.2f;
        formAdditionalTargetsDamageMod = .6f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Calls down a bolt of energy dealing {0} {1} damage to the target and {0} {1} damage to surrounding targets within {2}m.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.schoolRune.schoolRuneType, unitStats.GetArea(ability));
    }
}