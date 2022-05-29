using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Point : FormRune
{
    public FormRune_Point()
    {
        runeName = "Point";
        runeDescription = "An instantaneous snap of magic at a small point.";
        runeImageLocation = "Abilities/Runes/Forms/Point";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Point;
        hitType = WorldAbility.HitType.Hit;
        //Implicit
        formDuration = 0f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .5f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Instantaneous deals {0} {1} damage to the target.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType);
    }
}