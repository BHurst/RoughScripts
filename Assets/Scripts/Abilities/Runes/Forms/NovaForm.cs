using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaForm : FormRune
{
    public NovaForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Nova";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Nova;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 5f;
    }
}