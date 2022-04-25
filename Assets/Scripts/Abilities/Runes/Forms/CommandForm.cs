using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandForm : FormRune
{
    public CommandForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Command";
        formAnimation = "triggerMainHandCast";
        formRuneType = Rune.FormRuneTag.Command;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 0f;
    }
}