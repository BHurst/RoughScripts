using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Split : EffectRune
{
    public EffectRune_Split()
    {
        triggerTag = TriggerTag.OnHit;
    }
    
    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        GameWorldReferenceClass.CreateWorldAbility(target, owner, worldAbility, 10);
    }
}