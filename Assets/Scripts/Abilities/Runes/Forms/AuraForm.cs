using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraForm : FormRune
{
    public AuraForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Aura";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Aura;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 2f;
    }
}