using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Nova : FormRune
{
    public FormRune_Nova()
    {
        runeName = "Nova";
        runeImageLocation = "Abilities/Runes/Forms/Nova";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Nova;

        formDamageMod = 1f;
        formDuration = 0f;
        formArea = 5f;
    }
}