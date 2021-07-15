using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunge : EffectRune
{
    public Lunge()
    {
        triggerTag = TriggerTag.OnHit;
    }

    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Vector3 dir = Camera.main.transform.forward;

        target.GetComponent<RootUnit>().Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}