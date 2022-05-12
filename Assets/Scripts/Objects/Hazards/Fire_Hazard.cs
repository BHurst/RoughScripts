using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Hazard : HazardBase
{
    Ability ability;
    WorldAbility hazard;
    void Start()
    {
        InitializeEntity(this);

        ability = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Fire Hazard",
            aFormRune = new FormRune_Zone(),
            aSchoolRune = new SchoolRune_Fire(),
            harmful = true,
            initialized = true
        };
        ability.aFormRune.formDuration = 999999;

        hazard = AbilityFactory.InstantiateWorldAbility(ability, transform.position, unitID, entityType, WorldAbility.CreationMethod.Naturally).GetComponent<WorldAbility>();
    }

    void Update()
    {
        
    }
}