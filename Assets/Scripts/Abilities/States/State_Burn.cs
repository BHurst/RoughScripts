using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Burn : StateEffect
{
    public const float baseDuration = 5;
    public const float baseDamage = 5;

    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStateStats snapshot)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.statusId = abilityObject.ability.abilityID;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}