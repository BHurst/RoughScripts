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
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Orb;

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

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Fires a slow moving projectile that deals {0} {1} damage to the target.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType);
    }
}