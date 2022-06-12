using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Weapon : FormRune
{
    public FormRune_Weapon()
    {
        runeName = "Weapon";
        runeDescription = "A method of imbuing magic into a weapon.";
        runeImageLocation = "Abilities/Runes/Forms/Weapon";
        formCastAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Weapon;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 0f;
        formArea = 0f;
        //Tertiary
        formDamageMod = 1f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        DamageManager.CalculateAbilityAttacker(ability);

        return string.Format("Deals weapon damage modified by the spell-WIP.");
    }
}