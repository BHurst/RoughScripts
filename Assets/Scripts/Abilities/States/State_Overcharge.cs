using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Overcharge : StateEffect
{
    public const float overchargeBonus = 1.5f;
    public const float baseThreshold = 25;
    public const float decayRate = .2f;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_Overcharge status = new State_Overcharge();
        status.snapshot = snapshot;
        target.AddState(status);
    }
}