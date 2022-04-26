using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Arc : FormRune
{
    public FormRune_Arc()
    {
        runeName = "Arc";
        runeImageLocation = "Abilities/Runes/Forms/Arc";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Arc;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 5f;
        maxTargets = 3;
    }
}