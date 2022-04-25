using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneForm : FormRune
{
    public ZoneForm()
    {
        formImageLocation = "Abilities/Runes/Forms/Zone";
        formAnimation = "triggerTwoHandSelfCast";
        formRuneType = Rune.FormRuneTag.Zone;

        formDamageMod = 1f;
        formDuration = 5f;
        formArea = 5f;
    }
}