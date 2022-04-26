using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Weapon : FormRune
{
    public FormRune_Weapon()
    {
        runeImageLocation = "Abilities/Runes/Forms/Weapon";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Weapon;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 0f;
    }
}