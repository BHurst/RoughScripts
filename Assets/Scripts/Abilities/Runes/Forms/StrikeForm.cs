using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeForm : FormRune
{
    public StrikeForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Strike";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Strike;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 2f;
    }
}