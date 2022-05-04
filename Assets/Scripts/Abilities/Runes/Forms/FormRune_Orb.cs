using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Orb : FormRune
{
    public FormRune_Orb()
    {
        runeName = "Orb";
        runeImageLocation = "Abilities/Runes/Forms/Orb";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Orb;

        //Implicit
        formDuration = 10f;
        formArea = 0f;
        formSpeed = 15f;
        //Tertiary
        formDamageMod = 1f;
        formResourceCostMod = .75f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }
}