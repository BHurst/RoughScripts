using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_SoulRot : StateEffect
{
    public const float rotCostPercent = .5f;
    public const float baseDuration = 3;
    public const float rotManaGain = .01f;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_SoulRot status = new State_SoulRot();
        status.currentDuration = baseDuration;
        status.snapshot = snapshot;
        target.AddState(status);
    }
}