using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Beam : FormRune
{
    public FormRune_Beam()
    {
        runeName = "Beam";
        runeImageLocation = "Abilities/Runes/Forms/Beam";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Beam;

        //Implicit
        formDuration = 2f;
        formInterval = .25f;
        formArea = 10f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 1.25f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }
}