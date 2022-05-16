using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Lunge : EffectRune
{
    public EffectRune_Lunge()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "The target will be shoved in the direction they are facing.";
        readableName = "Lunge";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        Vector3 dir = Camera.main.transform.forward;

        target.GetComponent<RootCharacter>().Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}