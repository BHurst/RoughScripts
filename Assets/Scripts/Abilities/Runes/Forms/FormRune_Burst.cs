using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Burst : FormRune
{
    public FormRune_Burst()
    {
        runeName = "Burst";
        runeDescription = "A narrow spout of energy.";
        runeImageLocation = "Abilities/Runes/Forms/Burst";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Burst;

        //Implicit
        formDuration = .25f;
        formInterval = .05f;
        formArea = 10f;
        //Tertiary
        formDamageMod = .05f;
        formResourceCostMod = 1.25f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Rapidly deals {0} {1} damage to the first target hit every {2} seconds, for {3} seconds.", DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType, formInterval, unitStats.GetDuration(ability));
    }
}