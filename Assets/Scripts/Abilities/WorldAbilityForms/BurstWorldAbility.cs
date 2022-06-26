using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWorldAbility : BasicAbilityForm
{
    float activationTimer = 0;

    public BurstWorldAbility()
    {
        formType = FormType.None;
        activationTimer = 0;
    }

    void Start()
    {
        var main = pS.main;
        main.startSpeed = 15f * ability.GetAsBasic().formRune.formArea / 10f;
        if (ability.creation == RootAbility.CreationMethod.Hazard)
        {

        }
        else
            FaceOwnerTarget();
    }

    public void Trigger()
    {
        List<RootCharacter> areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position, transform.forward * ability.snapshot.area, .5f, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets, GameWorldReferenceClass.GetTeam(ability.abilityOwner));
        List<DestructableObject> destructableTargets = GameWorldReferenceClass.GetDestructableObjectsInCapsule(transform.position, transform.forward * ability.snapshot.area, .5f);

        foreach (DestructableObject target in destructableTargets)
        {
            target.InflictDamage(ability.snapshot.damage, false);
        }

        foreach (RootCharacter target in areaTargets)
        {
            ApplyHit(target, false);
        }
    }

    void Update()
    {
        if (ability.creation == RootAbility.CreationMethod.Triggered)
        {
            if (targetPreference != null)
                transform.LookAt(targetPreference);
        }
        else
        {
            FaceOwnerTarget();
            PositionAtOwnerCastLocation();
        }
        activationTimer += Time.deltaTime;
        if (activationTimer > ability.GetAsBasic().formRune.formInterval)
        {
            Trigger();
            activationTimer -= ability.GetAsBasic().formRune.formInterval;
        }
        Tick();
    }
}