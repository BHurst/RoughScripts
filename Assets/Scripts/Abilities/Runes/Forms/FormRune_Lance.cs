using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Lance : FormRune
{
    public FormRune_Lance()
    {
        runeName = "Lance";
        runeImageLocation = "Abilities/Runes/Forms/Lance";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Lance;

        //Implicit
        formDuration = 2f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .8f;
        formResourceCostMod = 1f;
        formCooldownMod = 1.2f;
        formCastSpeedMod = .8f;
    }
}