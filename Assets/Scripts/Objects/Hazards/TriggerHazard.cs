using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHazard : HazardBase
{
    BasicAbility ability;
    BaseAbility hazardAbility;
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

        ability = new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            harmful = true,
            initialized = true
        };

        ability.snapshot = new UnitStatsSnapshot();
        ability.snapshot.overrideDamage = hazardOverrideDamage;

        switch (form)
        {
            case Rune.FormRuneTag.Arc:
                ability.formRune = new FormRune_Arc();
                break;
            case Rune.FormRuneTag.Aura:
                ability.formRune = new FormRune_Aura();
                break;
            case Rune.FormRuneTag.Burst:
                ability.formRune = new FormRune_Burst();
                break;
            case Rune.FormRuneTag.Command:
                ability.formRune = new FormRune_Command();
                break;
            case Rune.FormRuneTag.Lance:
                ability.formRune = new FormRune_Lance();
                break;
            case Rune.FormRuneTag.Nova:
                ability.formRune = new FormRune_Nova();
                break;
            case Rune.FormRuneTag.Orb:
                ability.formRune = new FormRune_Orb();
                break;
            case Rune.FormRuneTag.Point:
                ability.formRune = new FormRune_Point();
                break;
            case Rune.FormRuneTag.SelfCast:
                ability.formRune = new FormRune_SelfCast();
                break;
            case Rune.FormRuneTag.Strike:
                ability.formRune = new FormRune_Strike();
                break;
            case Rune.FormRuneTag.Wave:
                ability.formRune = new FormRune_Wave();
                break;
            case Rune.FormRuneTag.Weapon:
                ability.formRune = new FormRune_Weapon();
                break;
            case Rune.FormRuneTag.Zone:
                ability.formRune = new FormRune_Zone();
                break;
            default:
                break;
        }

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

        ability.formRune.formDuration = triggerDuration;
        ability.formRune.formArea = hazardArea;

        hazardAbility = ability;
    }

    void Trigger()
    {
        _WorldAbilityForm newA = AbilityFactory.InstantiateWorldAbility(ability, transform.position, unitID, entityType, BaseAbility.CreationMethod.Hazard).GetComponent<_WorldAbilityForm>();
        if (targeted)
        {
            newA.targetPreference = lastTarget.transform;
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