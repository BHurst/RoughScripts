using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Beam : FormRune
{
    public FormRune_Beam()
    {
        runeName = "Beam";
        runeDescription = "A narrow spout of energy.";
        runeImageLocation = "Abilities/Runes/Forms/Beam";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Beam;

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
}