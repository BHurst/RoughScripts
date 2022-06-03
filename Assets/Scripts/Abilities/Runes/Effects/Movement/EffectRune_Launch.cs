using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Launch : EffectRune
{
    public EffectRune_Launch()
    {
        triggerTag = TriggerTag.OnCast;
        runeDescription = "The target will be thrown upwards.";
        readableName = "Launch";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, _WorldAbilityForm abilityObject)
    {
        Vector3 dir = new Vector3(0, 1, 0);

        target.Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}