using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEffect
{
    public float currentDuration = 5;
    public float maxDuration = 5;
    public CalculatedStateStats snapshot;
    public virtual void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        
    }
}