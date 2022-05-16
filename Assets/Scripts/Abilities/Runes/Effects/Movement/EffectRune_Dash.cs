﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_Dash : EffectRune
{
    public EffectRune_Dash()
    {
        triggerTag = TriggerTag.OnHit;
        runeDescription = "The target will be pushed forward.";
        readableName = "Dash";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, WorldAbility worldAbility)
    {
        Vector2 flattenedDir = new Vector2(Camera.main.transform.forward.x, Camera.main.transform.forward.z).normalized;
        Vector3 dir = new Vector3(flattenedDir.x, 0, flattenedDir.y);

        target.Shove(15, dir);
        target.moveAbilityTimer = 0;
    }
}