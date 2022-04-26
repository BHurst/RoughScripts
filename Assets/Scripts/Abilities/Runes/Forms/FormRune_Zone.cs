using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormRune_Zone : FormRune
{
    public FormRune_Zone()
    {
        runeImageLocation = "Abilities/Runes/Forms/Zone";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Zone;

        formDamageMod = 1f;
        formDuration = 5f;
        formArea = 5f;
    }
}