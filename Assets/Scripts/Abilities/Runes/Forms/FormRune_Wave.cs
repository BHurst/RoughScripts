using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Wave : FormRune
{
    public FormRune_Wave()
    {
        runeName = "Wave";
        runeDescription = "An expansive conical form.";
        runeImageLocation = "Abilities/Runes/Forms/Wave";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Wave;

        //Implicit
        formDuration = 1f;
        formArea = 4f;
        //Tertiary
        formDamageMod = .4f;
        formResourceCostMod = 1.5f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Fires an expanding wave that deals {0} {1} damage to all targets in its path.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType);
    }
}