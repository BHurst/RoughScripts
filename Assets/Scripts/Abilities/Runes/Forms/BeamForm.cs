using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamForm : FormRune
{
    public BeamForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Beam";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Beam;

        formDamageMod = 1f;
        formDuration = 2f;
        formArea = 0f;
    }
}