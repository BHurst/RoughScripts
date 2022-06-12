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

    public static _WorldAbilityForm InstantiateWorldAbility(BasicAbility abilityToBeCreated, Vector3 locationToBePlaced, Guid unitCreating, RootEntity.EntityType entityType, BaseAbility.CreationMethod creation)
    {
        if(AbilityFolder == null)
            AbilityFolder = GameObject.Find("AbilityFolder").transform;

        GameObject abilityResult = Instantiate(Resources.Load(abilityToBeCreated.GetPrefabDirectory()), locationToBePlaced, new Quaternion(), AbilityFolder) as GameObject;
        Instantiate(Resources.Load(abilityToBeCreated.GetParticleDirectory()), abilityResult.transform.position, new Quaternion(), abilityResult.transform);
        _WorldAbilityForm worldAbility = abilityResult.GetComponent<_WorldAbilityForm>();
        worldAbility.ability = new BasicAbility();
        worldAbility.ability.Construct(abilityToBeCreated, unitCreating, entityType);

        worldAbility.ability.creation = creation;
        worldAbility.DelayedStart();
        return worldAbility;
    }

}