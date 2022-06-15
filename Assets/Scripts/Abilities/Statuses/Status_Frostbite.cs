using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Frostbite : SpecialStatus
{
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject, CalculatedStatusStats snapshot)
    {
        Status status = new Status();
        status.sourceUnit = owner.unitID;
        status.rate = abilityObject.ability.GetDamage() / 5;
        status.maxDuration = 5;
        status.imageLocation = abilityObject.ability.schoolRune.runeImageLocation;

        target.AddStatus(status);
    }
}