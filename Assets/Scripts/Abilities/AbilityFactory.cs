using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory
{
    public static WorldAbility ConstructWorldAbility(Ability ability, Guid owner)
    {
        WorldAbility worldAbility = new WorldAbility();

        worldAbility.formRune = ability.formRune;
        worldAbility.harmRune = ability.harmRune;
        worldAbility.abilityOwner = owner;

        return worldAbility;
    }

}