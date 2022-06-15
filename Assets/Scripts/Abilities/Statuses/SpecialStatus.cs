using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStatus
{
    public float currentDuration = 5;
    public float maxDuration = 5;
    public CalculatedStatusStats snapshot;
    public virtual void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        
    }

    public virtual Targetting GetTargetting()
    {
        return Targetting.None;
    }

    public enum Targetting
    {
        None,
        Self,
        Target
    }
}