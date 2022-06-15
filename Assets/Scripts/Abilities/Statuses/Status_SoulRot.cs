using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_SoulRot : SpecialStatus
{
    public const float rotCostPercent = .5f;
    public const float baseDuration = 3;
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        Status_SoulRot status = new Status_SoulRot();
        status.currentDuration = baseDuration;
        status.snapshot = snapshot;
        target.AddSpecialStatus(status);
    }

    public override Targetting GetTargetting()
    {
        return Targetting.Self;
    }
}