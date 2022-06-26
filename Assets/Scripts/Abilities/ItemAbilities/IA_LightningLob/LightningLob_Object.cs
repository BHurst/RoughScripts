using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningLob_Object : UniqueAbilityForm
{
    float intervalTimer = 0;
    float interval = .1f;
    BasicAbility zap;

    void Start()
    {
        FaceOwnerTarget();
        if (transform.localEulerAngles.x < 270 || transform.localEulerAngles.x > 300)
            transform.localEulerAngles += new Vector3(transform.localEulerAngles.x - 30, 0, 0f);


        zap = new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = ability.abilityOwner,
            ownerEntityType = RootEntity.EntityType.Player,
            abilityName = "Zap",
            formRune = new FormRune_Arc(),
            schoolRune = new SchoolRune_Electricity(),
            castModeRune = new CastModeRune_Trigger(),
            snapshot = ability.snapshot,
            abilityStateManager = ability.abilityStateManager,

            harmful = true,
            initialized = true
        };

        skeleton.AddForce(transform.forward * 30f, ForceMode.Impulse);
    }

    void Trigger(Collider collider)
    {
        var target = collider.transform.GetComponent<RootCharacter>();
        if (target != null)
        {
            if (ApplyHit(target, true))
                Terminate();
        }
        else if (collider.gameObject.layer == 9)
            Terminate();
    }

    void OnTriggerEnter(Collider collider)
    {
        Trigger(collider);
    }

    void Update()
    {
        Tick();
        intervalTimer += Time.deltaTime;
        if (intervalTimer >= interval)
        {
            BasicAbilityForm jolt = AbilityFactory.InstantiateBasicWorldAbility(zap, transform.position, ability.abilityOwner, ability.ownerEntityType, RootAbility.CreationMethod.Triggered, null);
            List<RootCharacter> newTarget = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(ability.snapshot.area, transform.position, new List<RootCharacter>(), 1, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).team);
            if (newTarget.Count > 0)
                jolt.targetPreference = newTarget[0].transform;

            intervalTimer -= interval;
        }
    }
}