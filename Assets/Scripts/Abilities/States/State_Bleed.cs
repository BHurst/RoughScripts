using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Bleed : StateEffect
{
    public const float baseDuration = 10;
    public const float bleedDamageRatio = .05f;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_Bleed status = new State_Bleed();
        status.currentDuration = baseDuration;
        status.snapshot = snapshot;
        target.AddState(status);
    }
}