using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : EffectRune
{
    public Split()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        GameWorldReferenceClass.CreateWorldAbility(target, owner, worldAbility, 10);
    }
}