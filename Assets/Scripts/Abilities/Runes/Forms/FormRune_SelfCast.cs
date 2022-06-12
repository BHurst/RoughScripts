using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_SelfCast : FormRune
{
    public FormRune_SelfCast()
    {
        runeName = "Self Cast";
        runeDescription = "A self targeting form.";
        runeImageLocation = "Abilities/Runes/Forms/SelfCast";
        formCastAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.SelfCast;
        hitType = FormRune.HitType.Hit;
        //Implicit
        formDuration = 10f;
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

        return string.Format("This ability targets the user.");
    }
}