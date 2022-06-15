using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Decay : SpecialStatus
{
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        Status_Decay status = new Status_Decay();

        target.AddSpecialStatus(status);
    }
}