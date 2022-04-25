using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForm : FormRune
{
    public PointForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Point";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Point;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 0f;
    }
}