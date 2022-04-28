using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Aura : FormRune
{
    public FormRune_Aura()
    {
        runeName = "Aura";
        runeImageLocation = "Abilities/Runes/Forms/Aura";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Aura;

        //Implicit
        formDuration = 10f;
        formInterval = .5f;
        formArea = 2f;
        //Tertiary
        formDamageMod = .2f;
        formResourceCostMod = 2f;
        formCooldownMod = 2f;
        formCastSpeedMod = 1f;
    }
}