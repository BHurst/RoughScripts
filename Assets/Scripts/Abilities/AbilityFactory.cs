using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory
{
    public static WorldAbility ConstructWorldAbility(Ability ability, Guid owner)
    {
        WorldAbility worldAbility = new WorldAbility();

        worldAbility.wFormRune = ability.aFormRune;
        worldAbility.wCastModeRune = ability.aCastModeRune;
        worldAbility.wSchoolRune = ability.aSchoolRune;
        worldAbility.abilityOwner = owner;

        return worldAbility;
    }

}