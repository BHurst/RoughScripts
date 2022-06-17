using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_RimeGuard : StateEffect
{
    public const float frostguardDamageReduction = .5f;
    public const float baseThreshold = 50;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_RimeGuard status = new State_RimeGuard();
        status.snapshot = snapshot;
        target.AddState(status);
    }
}