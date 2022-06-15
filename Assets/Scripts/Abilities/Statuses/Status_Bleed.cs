using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Bleed : SpecialStatus
{
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        Status_Decay status = new Status_Decay();

        target.AddSpecialStatus(status);
    }
}