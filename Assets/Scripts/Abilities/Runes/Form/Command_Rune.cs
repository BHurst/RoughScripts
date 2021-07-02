using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Rune : FormRune
{
    public Command_Rune()
    {
        form = FormRuneTag.Command;
        formDamageMod = .1f;
    }
}