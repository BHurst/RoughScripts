using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Command : FormRune
{
    public FormRune_Command()
    {
        runeName = "Command";
        runeImageLocation = "Abilities/Runes/Forms/Command";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Command;

        //Implicit
        formDuration = 10f;
        formArea = 0f;
        //Tertiary
        formDamageMod = .3f;
        formResourceCostMod = 3f;
        formCooldownMod = 0f;
        formCastSpeedMod = 2f;
    }
}