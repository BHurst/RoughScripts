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
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Arc;

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

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Deals {0} {1} damage to the target, and up to {2} additional targets nearby.",
            DamageManager.TooltipAbilityDamage(unitStats, ability),
            ability.aSchoolRune.schoolRuneType,
            formMaxAdditionalTargets + unitStats.Ability_Chains_Flat.value);
    }
}