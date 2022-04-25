using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveForm : FormRune
{
    public WaveForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Wave";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Wave;

        formDamageMod = 1f;
        formDuration = 1f;
        formArea = 4f;
    }
}