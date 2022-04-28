using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Arc : FormRune
{
    public FormRune_Arc()
    {
        runeName = "Arc";
        runeImageLocation = "Abilities/Runes/Forms/Arc";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Arc;

        //Implicit
        formDuration = 0f;
        formArea = 5f;
        formMaxTargets = 3;
        //Tertiary
        formDamageMod = .4f;
        formResourceCostMod = 0f;
        formCooldownMod = 0f;
        formCastSpeedMod = 0f;
    }
}