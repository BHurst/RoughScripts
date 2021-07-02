using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCast_Rune : FormRune
{
    public SelfCast_Rune()
    {
        form = FormRuneTag.SelfCast;
        formDamageMod = 1f;
    }
}