using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Lance : FormRune
{
    public FormRune_Lance()
    {
        runeName = "Lance";
        runeDescription = "A narrow high speed projectile.";
        runeImageLocation = "Abilities/Runes/Forms/Lance";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Lance;

        //Implicit
        formDuration = 2f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .8f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = .8f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Fires a fast moving projectile that deals {0} {1} damage to the target.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType);
    }
}