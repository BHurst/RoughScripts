using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Beam : FormRune
{
    public FormRune_Beam()
    {
        runeImageLocation = "Abilities/Runes/Forms/Beam";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Beam;

        formDamageMod = 1f;
        formDuration = 2f;
        formArea = 0f;
    }
}