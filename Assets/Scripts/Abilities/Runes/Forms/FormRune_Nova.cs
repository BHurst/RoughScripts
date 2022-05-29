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
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Nova;
        hitType = WorldAbility.HitType.Hit;
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

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Deals {0} {1} damage to the closest {2} targets within {3}m.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType, formMaxAdditionalTargets, unitStats.GetArea(ability));
    }
}