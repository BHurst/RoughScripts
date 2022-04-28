using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_SelfCast : FormRune
{
    public FormRune_SelfCast()
    {
        runeName = "Self Cast";
        runeImageLocation = "Abilities/Runes/Forms/SelfCast";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.SelfCast;

        //Implicit
        formDuration = 10f;
        formArea = 0f;
        //Tertiary
        formDamageMod = 1f;
        formResourceCostMod = 1f;
        formCooldownMod = 1f;
        formCastSpeedMod = 1f;
    }
}