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

    public static BasicAbilityForm InstantiateWorldAbility(BasicAbility abilityToBeCreated, Vector3 locationToBePlaced, Guid unitCreating, RootEntity.EntityType entityType, RootAbility.CreationMethod creation, AbilityChaperone abilityChaperone)
    {
        if(AbilityFolder == null)
            AbilityFolder = GameObject.Find("AbilityFolder").transform;

        GameObject abilityResult = Instantiate(Resources.Load(abilityToBeCreated.GetPrefabDirectory()), locationToBePlaced, new Quaternion()) as GameObject;
        Instantiate(Resources.Load(abilityToBeCreated.GetParticleDirectory()), abilityResult.transform.position, new Quaternion(), abilityResult.transform);
        BasicAbilityForm worldAbility = abilityResult.GetComponent<BasicAbilityForm>();
        worldAbility.ability = new BasicAbility();
        worldAbility.ability.Construct(abilityToBeCreated, unitCreating, entityType);

        worldAbility.ability.creation = creation;
        if (creation == RootAbility.CreationMethod.Triggered)
            worldAbility.ability.snapshot = abilityToBeCreated.snapshot;

        if (abilityChaperone != null)
        {
            abilityResult.transform.SetParent(abilityChaperone.transform);
            worldAbility.chaperone = abilityChaperone;
        }
        else
        {
            GameObject newChaperone = Instantiate(Resources.Load("Prefabs/Abilities/AbilityChaperone"), new Vector3(), new Quaternion(), AbilityFolder) as GameObject;
            abilityResult.transform.SetParent(newChaperone.transform);
            worldAbility.chaperone = newChaperone.GetComponent<AbilityChaperone>();
        }

        worldAbility.DelayedStart();
        return worldAbility;
    }

}