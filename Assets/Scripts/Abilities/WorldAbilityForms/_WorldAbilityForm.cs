using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WorldAbilityForm : MonoBehaviour
{
    public float timer = 0;
    public RaycastHit spellRay;
    public RaycastHit camRay;
    public Rigidbody skeleton;
    public ParticleSystem pS;
    public Ability ability;
    public Transform targetPreference;
    public List<RootCharacter> previousTargets = new List<RootCharacter>();

    public void InitialCreation()
    {

    }

    public void DelayedStart()
    {
        ability = GetComponent<_WorldAbilityForm>().ability;
        skeleton = GetComponent<Rigidbody>();
        pS = GetComponentInChildren<ParticleSystem>();
        gameObject.layer = 11;

        CalculateAttackerStats();
    }

    public void FaceOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
        if (camRay.collider != null)
            transform.LookAt(spellRay.point);
        else
        {
            transform.LookAt(GameWorldReferenceClass.GW_PlayerCamera.transform.position + GameWorldReferenceClass.GW_PlayerCamera.transform.forward * 1000);
        }
    }

    public void FaceNewTarget(Transform target)
    {
        transform.LookAt(target);
    }

    public void PositionAtOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
        if (camRay.collider != null)
            transform.position = spellRay.point;
        else
        {
            transform.position = GameWorldReferenceClass.GW_PlayerCamera.transform.position + GameWorldReferenceClass.GW_PlayerCamera.transform.forward * 1000;
        }
    }

    public void PositionAtNewTarget(Transform target)
    {
        transform.position = target.position;
    }

    public void PositionAtOwner()
    {
        transform.position = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).unitBody.transform.position;
    }

    public void PositionAtOwnerCastLocation()
    {
        transform.position = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position;
    }

    public void TriggerParticleBurst(int index)
    {
        //If a particle system does not exist for long enough, burst will not trigger. No particles will be present thus immediately destroying it.
        if (pS.emission.burstCount > 0)
            pS.Emit((int)pS.emission.GetBurst(index).count.constant);
    }

    public void CalculateAttackerStats()
    {
        if (ability.ownerEntityType == RootEntity.EntityType.Hazard)
            DamageManager.CalculateAbilityHazard(ability);
        else
            DamageManager.CalculateAbilityAttacker(ability);
    }

    public void CreateTriggerAbility(Vector3 location, Transform? preference, RootEntity.EntityType entityType)
    {
        _WorldAbilityForm abilityResult = AbilityFactory.InstantiateWorldAbility(ability.abilityToTrigger, location, ability.abilityOwner, entityType, Ability.CreationMethod.Triggered).GetComponent<_WorldAbilityForm>();
        abilityResult.ability.Construct(ability.abilityToTrigger, ability.abilityOwner, entityType);
        abilityResult.transform.position = location;
        abilityResult.previousTargets.AddRange(previousTargets);
        abilityResult.ability.creation = Ability.CreationMethod.Triggered;
        abilityResult.transform.rotation = this.transform.rotation;

        if (preference != null)
            abilityResult.targetPreference = preference;

    }

    public void ApplyHit(RootCharacter target)
    {
        if ((target.unitID == ability.abilityOwner && ability.harmful && ability.selfHarm) || target.unitID != ability.abilityOwner)
        {
            DamageManager.CalculateAbilityDefender(target.unitID, ability);
            if (ability.formRune.hitType == FormRune.HitType.Hit)
                GlobalEventManager.AbilityHitTrigger(this, this, target, target.transform.position);
        }

        if (ability.effectRunes != null)
        {
            foreach (var rune in ability.effectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnHit)
                    if (!rune.targetSelf)
                        rune.Effect(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner), this);
            }
        }
    }

    public void ApplyDoT(RootCharacter target)
    {
        if ((target.unitID == ability.abilityOwner && ability.harmful && ability.selfHarm) || target.unitID != ability.abilityOwner)
        {
            Status status = new Status();
            status.name = ability.abilityName;
            status.sourceUnit = ability.abilityOwner;
            status.rate = ability.calculatedDamage;
            status.refreshable = true;
            status.maxDuration = .25F;
            status.imageLocation = ability.schoolRune.runeImageLocation;

            target.AddStatus(status);
        }

        if (ability.effectRunes != null)
        {
            foreach (var rune in ability.effectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnHit)
                    if (!rune.targetSelf)
                        rune.Effect(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner), this);
            }
        }
    }

    public void Terminate()
    {
        if (pS != null)
        {
            pS.transform.SetParent(null);
            pS.transform.localScale = new Vector3(1, 1, 1); //When a scaled object parent is removed, the particle system takes on that scale.
        }

        Destroy(this.gameObject);
    }

    public void Obliterate()
    {
        Destroy(this.gameObject);
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (timer > ability.formRune.formDuration)
            Terminate();
    }
}