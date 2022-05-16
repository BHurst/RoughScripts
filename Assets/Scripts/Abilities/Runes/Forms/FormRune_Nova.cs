using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Nova : FormRune
{
    public FormRune_Nova()
    {
        runeName = "Nova";
        runeDescription = "An explosion of energy radiating from the target.";
        runeImageLocation = "Abilities/Runes/Forms/Nova";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Nova;

        //Implicit
        formDuration = 0f;
        formArea = 5f;
        formMaxTargets = 10;
        //Tertiary
        formDamageMod = .3f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1f;
    }
}