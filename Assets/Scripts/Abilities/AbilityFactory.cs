using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory : MonoBehaviour
{
    public static Transform AbilityFolder;

    private void Start()
    {
        AbilityFolder = GameObject.Find("AbilityFolder").transform;
    }

    public static _WorldAbilityForm InstantiateWorldAbility(Ability abilityToBeCreated, Vector3 locationToBePlaced, Guid unitCreating, RootEntity.EntityType entityType, Ability.CreationMethod creation)
    {
        if(AbilityFolder == null)
            AbilityFolder = GameObject.Find("AbilityFolder").transform;

        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", abilityToBeCreated.formRune.formRuneType)), locationToBePlaced, new Quaternion(), AbilityFolder) as GameObject;
        Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", abilityToBeCreated.formRune.formRuneType, abilityToBeCreated.schoolRune.schoolRuneType)), abilityResult.transform.position, new Quaternion(), abilityResult.transform);
        _WorldAbilityForm worldAbility = abilityResult.GetComponent<_WorldAbilityForm>();
        worldAbility.ability.Construct(abilityToBeCreated, unitCreating, entityType);

        worldAbility.ability.creation = creation;
        worldAbility.DelayedStart();
        return worldAbility;
    }

}