using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentHazard : HazardBase
{
    Ability ability;
    _WorldAbilityForm hazardAbility;
    void Start()
    {
        InitializeEntity(this);

        ability = new Ability()
        {
            abilityID = Guid.NewGuid(),
            formRune = new FormRune_Zone(),
            harmful = true,
            initialized = true,
            overrideDamage = hazardOverrideDamage,
        };

        ability.formRune.formDuration = 999999;
        ability.formRune.formArea = hazardArea;

        switch (school)
        {
            case Rune.SchoolRuneTag.Air:
                ability.schoolRune = new SchoolRune_Air();
                ability.abilityName = "Air Hazard";
                break;
            case Rune.SchoolRuneTag.Arcane:
                ability.schoolRune = new SchoolRune_Arcane();
                ability.abilityName = "Arcane Hazard";
                break;
            case Rune.SchoolRuneTag.Astral:
                ability.schoolRune = new SchoolRune_Astral();
                ability.abilityName = "Astral Hazard";
                break;
            case Rune.SchoolRuneTag.Earth:
                ability.schoolRune = new SchoolRune_Earth();
                ability.abilityName = "Earth Hazard";
                break;
            case Rune.SchoolRuneTag.Electricity:
                ability.schoolRune = new SchoolRune_Electricity();
                ability.abilityName = "Electricity Hazard";
                break;
            case Rune.SchoolRuneTag.Ethereal:
                ability.schoolRune = new SchoolRune_Ethereal();
                ability.abilityName = "Ethereal Hazard";
                break;
            case Rune.SchoolRuneTag.Fire:
                ability.schoolRune = new SchoolRune_Fire();
                ability.abilityName = "Fire Hazard";
                break;
            case Rune.SchoolRuneTag.Ice:
                ability.schoolRune = new SchoolRune_Ice();
                ability.abilityName = "Ice Hazard";
                break;
            case Rune.SchoolRuneTag.Kinetic:
                ability.schoolRune = new SchoolRune_Kinetic();
                ability.abilityName = "Kinetic Hazard";
                break;
            case Rune.SchoolRuneTag.Life:
                ability.schoolRune = new SchoolRune_Life();
                ability.abilityName = "Life Hazard";
                break;
            case Rune.SchoolRuneTag.Water:
                ability.schoolRune = new SchoolRune_Water();
                ability.abilityName = "Water Hazard";
                break;
            default:
                break;
        }

        hazardAbility = AbilityFactory.InstantiateWorldAbility(ability, transform.position, unitID, entityType, Ability.CreationMethod.Hazard).GetComponent<_WorldAbilityForm>();
    }

    void Update()
    {

    }
}