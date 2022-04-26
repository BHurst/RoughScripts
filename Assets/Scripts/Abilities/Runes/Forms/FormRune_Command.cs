using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Command : FormRune
{
    public FormRune_Command()
    {
        runeImageLocation = "Abilities/Runes/Forms/Command";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Command;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 0f;
    }
}