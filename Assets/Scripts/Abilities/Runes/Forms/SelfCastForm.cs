using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCastForm : FormRune
{
    public SelfCastForm()
    {
        formImageLocation = "Abilities/Runes/Forms/SelfCast";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.SelfCast;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 0f;
    }
}