using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHazard : HazardBase
{
    Ability ability;
    WorldAbility hazardAbility;
    public FormRune.FormRuneTag form;
    public float triggerDuration;
    public float triggerArea;
    public float cooldown;
    public float timer;
    public bool targeted;
    public RootCharacter lastTarget;
    void Start()
    {
        InitializeEntity(this);

        ability = new Ability()
        {
            abilityID = Guid.NewGuid(),
            harmful = true,
            initialized = true,
            overrideDamage = hazardOverrideDamage,
        };

        switch (form)
        {
            case Rune.FormRuneTag.Arc:
                ability.aFormRune = new FormRune_Arc();
                break;
            case Rune.FormRuneTag.Aura:
                ability.aFormRune = new FormRune_Aura();
                break;
            case Rune.FormRuneTag.Burst:
                ability.aFormRune = new FormRune_Burst();
                break;
            case Rune.FormRuneTag.Command:
                ability.aFormRune = new FormRune_Command();
                break;
            case Rune.FormRuneTag.Lance:
                ability.aFormRune = new FormRune_Lance();
                break;
            case Rune.FormRuneTag.Nova:
                ability.aFormRune = new FormRune_Nova();
                break;
            case Rune.FormRuneTag.Orb:
                ability.aFormRune = new FormRune_Orb();
                break;
            case Rune.FormRuneTag.Point:
                ability.aFormRune = new FormRune_Point();
                break;
            case Rune.FormRuneTag.SelfCast:
                ability.aFormRune = new FormRune_SelfCast();
                break;
            case Rune.FormRuneTag.Strike:
                ability.aFormRune = new FormRune_Strike();
                break;
            case Rune.FormRuneTag.Wave:
                ability.aFormRune = new FormRune_Wave();
                break;
            case Rune.FormRuneTag.Weapon:
                ability.aFormRune = new FormRune_Weapon();
                break;
            case Rune.FormRuneTag.Zone:
                ability.aFormRune = new FormRune_Zone();
                break;
            default:
                break;
        }

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

        ability.aFormRune.formDuration = triggerDuration;
        ability.aFormRune.formArea = hazardArea;
    }

    void Trigger()
    {
        hazardAbility = AbilityFactory.InstantiateWorldAbility(ability, transform.position, unitID, entityType, WorldAbility.CreationMethod.Hazard).GetComponent<WorldAbility>();
        if (targeted)
        {
            hazardAbility.targetPreference = lastTarget.transform;
            lastTarget = null;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldown)
        {
            List<RootCharacter> foundChars = GameWorldReferenceClass.GetNewRootUnitInSphere(triggerArea, transform.position, new List<RootCharacter>(), 99);

            if (foundChars.Count > 0)
            {
                if (targeted)
                    lastTarget = foundChars[0];
                Trigger();
                timer = 0;
            }
        }
    }
}