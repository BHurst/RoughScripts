using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Strike : FormRune
{
    public FormRune_Strike()
    {
        runeName = "Strike";
        runeDescription = "A concentrated source drawn down upon the target.";
        runeImageLocation = "Abilities/Runes/Forms/Strike";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Strike;

        //Implicit
        formDuration = 0f;
        formArea = 2f;
        //Tertiary
        formDamageMod = 1.2f;
        formResourceCostMod = 1f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }
}