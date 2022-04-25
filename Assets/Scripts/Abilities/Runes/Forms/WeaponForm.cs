using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponForm : FormRune
{
    public WeaponForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Weapon";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Weapon;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 0f;
    }
}