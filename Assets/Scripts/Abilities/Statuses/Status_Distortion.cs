using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Distortion : SpecialStatus
{
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        Status_Distortion status = new Status_Distortion();

        target.AddSpecialStatus(status);
    }
}