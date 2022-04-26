using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Orb : FormRune
{
    public FormRune_Orb()
    {
        runeName = "Orb";
        runeImageLocation = "Abilities/Runes/Forms/Orb";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Orb;

        formDamageMod = 1f;
        formDuration = 1f;
        formArea = 0f;
    }
}