using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Distortion : StateEffect
{
    public const float percentManaReduction = .1f;
    public const float baseThreshold = .25f;
    public const float decayRate = .01f;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_Distortion status = new State_Distortion();

        target.AddState(status);
    }
}