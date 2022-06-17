using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Decay : StateEffect
{
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        State_Decay status = new State_Decay();

        target.AddState(status);
    }
}