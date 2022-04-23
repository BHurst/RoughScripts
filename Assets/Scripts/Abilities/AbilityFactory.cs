using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour
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

    public static WorldAbility InstantiateWorldAbility(Ability abilityToBeCreated, Vector3 locationToBePlaced, Guid unitCreating, bool triggered)
    {
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", abilityToBeCreated.aFormRune.formRuneType)), locationToBePlaced, new Quaternion()) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", abilityToBeCreated.aFormRune.formRuneType, abilityToBeCreated.aSchoolRune.schoolRuneType)), abilityResult.transform.position, new Quaternion()) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(abilityToBeCreated, unitCreating);

        worldAbility.isTriggered = triggered;

        return worldAbility;
    }

}