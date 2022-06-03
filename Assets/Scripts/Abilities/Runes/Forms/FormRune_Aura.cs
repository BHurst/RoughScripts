using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Aura : FormRune
{
    public FormRune_Aura()
    {
        runeName = "Aura";
        runeDescription = "A form which persists around the target.";
        runeImageLocation = "Abilities/Runes/Forms/Aura";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Aura;
        hitType = FormRune.HitType.DoT;
        //Implicit
        formDuration = 10f;
        formInterval = .20f;
        formArea = 2f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Deals {0} {1} damage to {2} targets in {3}m around the main target for {4} seconds.", 
            DamageManager.TooltipAbilityDamage(unitStats, ability),
            ability.schoolRune.schoolRuneType,
            formMaxAdditionalTargets,
            unitStats.GetArea(ability),
            unitStats.GetDuration(ability));
    }
}