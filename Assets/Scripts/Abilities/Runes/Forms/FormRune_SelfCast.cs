using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_SelfCast : FormRune
{
    public FormRune_SelfCast()
    {
        runeImageLocation = "Abilities/Runes/Forms/SelfCast";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.SelfCast;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 0f;
    }
}