using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Weapon : FormRune
{
    public FormRune_Weapon()
    {
        runeName = "Weapon";
        runeImageLocation = "Abilities/Runes/Forms/Weapon";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Weapon;

        //Implicit
        formDuration = 0f;
        formArea = 0f;
        //Tertiary
        formDamageMod = 1f;
        formResourceCostMod = 1f;
        formCooldownMod = 1f;
        formCastSpeedMod = 1f;
    }
}