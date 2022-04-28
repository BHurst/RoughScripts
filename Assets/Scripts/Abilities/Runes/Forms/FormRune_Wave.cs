using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Wave : FormRune
{
    public FormRune_Wave()
    {
        runeName = "Wave";
        runeImageLocation = "Abilities/Runes/Forms/Wave";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Wave;

        //Implicit
        formDuration = 1f;
        formArea = 4f;
        //Tertiary
        formDamageMod = .4f;
        formResourceCostMod = 1.5f;
        formCooldownMod = 2f;
        formCastSpeedMod = 1f;
    }
}