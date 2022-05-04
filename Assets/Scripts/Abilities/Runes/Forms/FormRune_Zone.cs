using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Zone : FormRune
{
    public FormRune_Zone()
    {
        runeName = "Zone";
        runeImageLocation = "Abilities/Runes/Forms/Zone";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Zone;

        //Implicit
        formDuration = 5f;
        formInterval = 1f;
        formArea = 5f;
        //Tertiary
        formDamageMod = .25f;
        formResourceCostMod = 2f;
        formCooldownMod = 0f;
        formCastSpeedMod = 1.25f;
    }
}