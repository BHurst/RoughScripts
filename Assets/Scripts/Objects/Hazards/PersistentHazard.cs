using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentHazard : HazardBase
{
    Ability ability;
    WorldAbility hazardAbility;
    void Start()
    {
        InitializeEntity(this);

        ability = new Ability()
        {
            abilityID = Guid.NewGuid(),
            aFormRune = new FormRune_Zone(),
            harmful = true,
            initialized = true,
            overrideDamage = hazardOverrideDamage,
        };

        ability.aFormRune.formDuration = 999999;
        ability.aFormRune.formArea = hazardArea;

        switch (school)
        {
            case Rune.SchoolRuneTag.Air:
                ability.aSchoolRune = new SchoolRune_Air();
                ability.abilityName = "Air Hazard";
                break;
            case Rune.SchoolRuneTag.Arcane:
                ability.aSchoolRune = new SchoolRune_Arcane();
                ability.abilityName = "Arcane Hazard";
                break;
            case Rune.SchoolRuneTag.Astral:
                ability.aSchoolRune = new SchoolRune_Astral();
                ability.abilityName = "Astral Hazard";
                break;
            case Rune.SchoolRuneTag.Earth:
                ability.aSchoolRune = new SchoolRune_Earth();
                ability.abilityName = "Earth Hazard";
                break;
            case Rune.SchoolRuneTag.Electricity:
                ability.aSchoolRune = new SchoolRune_Electricity();
                ability.abilityName = "Electricity Hazard";
                break;
            case Rune.SchoolRuneTag.Ethereal:
                ability.aSchoolRune = new SchoolRune_Ethereal();
                ability.abilityName = "Ethereal Hazard";
                break;
            case Rune.SchoolRuneTag.Fire:
                ability.aSchoolRune = new SchoolRune_Fire();
                ability.abilityName = "Fire Hazard";
                break;
            case Rune.SchoolRuneTag.Ice:
                ability.aSchoolRune = new SchoolRune_Ice();
                ability.abilityName = "Ice Hazard";
                break;
            case Rune.SchoolRuneTag.Kinetic:
                ability.aSchoolRune = new SchoolRune_Kinetic();
                ability.abilityName = "Kinetic Hazard";
                break;
            case Rune.SchoolRuneTag.Life:
                ability.aSchoolRune = new SchoolRune_Life();
                ability.abilityName = "Life Hazard";
                break;
            case Rune.SchoolRuneTag.Water:
                ability.aSchoolRune = new SchoolRune_Water();
                ability.abilityName = "Water Hazard";
                break;
            default:
                break;
        }

        hazardAbility = AbilityFactory.InstantiateWorldAbility(ability, transform.position, unitID, entityType, WorldAbility.CreationMethod.Hazard).GetComponent<WorldAbility>();
    }

    void Update()
    {

    }
}