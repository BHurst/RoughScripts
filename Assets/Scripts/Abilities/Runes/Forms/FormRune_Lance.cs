using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Lance : FormRune
{
    public FormRune_Lance()
    {
        runeImageLocation = "Abilities/Runes/Forms/Lance";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Lance;

        formDamageMod = 1f;
        formDuration = 2f;
        formArea = 0f;
    }
}