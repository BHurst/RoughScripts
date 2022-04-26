using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Wave : FormRune
{
    public FormRune_Wave()
    {
        runeImageLocation = "Abilities/Runes/Forms/Wave";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Wave;

        formDamageMod = 1f;
        formDuration = 1f;
        formArea = 4f;
    }
}