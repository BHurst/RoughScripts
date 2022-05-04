using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Point : FormRune
{
    public FormRune_Point()
    {
        runeName = "Point";
        runeImageLocation = "Abilities/Runes/Forms/Point";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Point;

        //Implicit
        formDuration = 0f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .5f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }
}