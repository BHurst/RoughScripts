using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcForm : FormRune
{
    public ArcForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Arc";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Arc;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 0f;
    }
}