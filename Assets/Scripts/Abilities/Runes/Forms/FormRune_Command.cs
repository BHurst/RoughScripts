using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Command : FormRune
{
    public FormRune_Command()
    {
        runeName = "Command";
        runeDescription = "A form that persists for a duration, while casting spells of its own.";
        runeImageLocation = "Abilities/Runes/Forms/Command";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Command;
        hitType = RootAbility.HitType.None;
        targettingType = RootAbility.TargettingType.None;
        //Implicit
        formDuration = 10f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .3f;
        formResourceCostMod = 3f;
        formCooldownMod = 0f;
        formCastSpeedMod = 2f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);

        return string.Format("Creates a sentry for {0} seconds, that will cast <spell> at the closest valid target to it.",
            unitStats.GetDuration(ability));
    }
}