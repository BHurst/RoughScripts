using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Aura : FormRune
{
    public FormRune_Aura()
    {
        runeName = "Aura";
        runeImageLocation = "Abilities/Runes/Forms/Aura";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Aura;

        formDamageMod = 1f;
        formDuration = 10f;
        formArea = 2f;
    }
}