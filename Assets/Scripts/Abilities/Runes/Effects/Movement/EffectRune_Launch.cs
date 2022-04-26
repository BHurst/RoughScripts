using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Launch : EffectRune
{
    public EffectRune_Launch()
    {
        triggerTag = TriggerTag.OnHit;
    }

    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Vector3 dir = new Vector3(0, 1, 0);

        target.Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}