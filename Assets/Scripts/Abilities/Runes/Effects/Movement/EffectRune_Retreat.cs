using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Retreat : EffectRune
{
    public EffectRune_Retreat()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "The target will be pushed backwards.";
        readableName = "Retreat";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, _WorldAbilityForm abilityObject)
    {
        Vector2 flattenedDir = new Vector2(-Camera.main.transform.forward.x, -Camera.main.transform.forward.z).normalized;
        Vector3 dir = new Vector3(flattenedDir.x, 0, flattenedDir.y);

        target.Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}