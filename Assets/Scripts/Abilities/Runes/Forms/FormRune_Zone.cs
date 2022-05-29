using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Zone : FormRune
{
    public FormRune_Zone()
    {
        runeName = "Zone";
        runeDescription = "A large persistant area of magic.";
        runeImageLocation = "Abilities/Runes/Forms/Zone";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Zone;
        hitType = WorldAbility.HitType.DoT;
        //Implicit
        formDuration = 5f;
        formInterval = .25f;
        formArea = 5f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1.25f;
    }

    public override string GetTooltipDescription(UnitStats unitStats, Ability ability)
    {
        return string.Format("Creates an area at the target for {0} seconds, that deals {1} {2} damage every {3} second to all targets within {4}m.", unitStats.GetDuration(ability), DamageManager.TooltipAbilityDamage(unitStats, ability), ability.aSchoolRune.schoolRuneType, formInterval, unitStats.GetArea(ability));
    }
}