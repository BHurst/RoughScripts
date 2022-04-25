using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceForm : FormRune
{
    public LanceForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Lance";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Lance;

        formDamageMod = 1f;
        formDuration = 2f;
        formArea = 0f;
    }
}