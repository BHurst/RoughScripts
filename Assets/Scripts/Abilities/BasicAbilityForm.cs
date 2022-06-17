using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbilityForm : RootAbilityForm
{

    public override bool ApplyHit(RootCharacter target)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            DamageManager.CalculateAbilityDefender(target.unitID, ability);
            if (ability.GetHitType() == RootAbility.HitType.Hit)
                GlobalEventManager.AbilityHitTrigger(this, this, target, target.transform.position);


            if (ability.effectRunes != null)
            {
                foreach (var rune in ability.effectRunes)
                {
                    if (rune.triggerTag == Rune.TriggerTag.OnHit)
                        if (!rune.targetSelf)
                            rune.Effect(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner), this);
                }
            }

            ability.abilityStateManager.ApplyStateOnHit(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner));
            chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override bool ApplyDoT(RootCharacter target)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            Status status = new Status();
            status.name = ability.abilityName;
            status.sourceUnit = ability.abilityOwner;
            status.rate = ability.snapshot.damage;
            status.refreshable = true;
            status.maxDuration = ability.snapshot.duration;
            status.imageLocation = ability.schoolRune.runeImageLocation;

            target.AddStatus(status);


            if (ability.effectRunes != null)
            {
                foreach (var rune in ability.effectRunes)
                {
                    if (rune.triggerTag == Rune.TriggerTag.OnHit)
                        if (!rune.targetSelf)
                            rune.Effect(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner), this);
                }
            }

            ability.abilityStateManager.ApplyStateOnHit(target, GameWorldReferenceClass.GetUnitByID(ability.abilityOwner));
            chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override void ApplyAreaDoT(RootCharacter target)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            Status status = new Status();
            status.name = ability.abilityName;
            status.sourceUnit = ability.abilityOwner;
            status.rate = ability.snapshot.damage;
            status.refreshable = true;
            status.maxDuration = .25F;
            status.imageLocation = ability.schoolRune.runeImageLocation;

            target.AddStatus(status);


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
    }

    public void InitialCreation()
    {

    }

    public void DelayedStart()
    {
        ability = GetComponent<BasicAbilityForm>().ability;
        skeleton = GetComponent<Rigidbody>();
        pS = GetComponentInChildren<ParticleSystem>();
        gameObject.layer = 11;

        if (ability.creation != RootAbility.CreationMethod.Triggered)
        {
            CalculateAttackerStats();
            if(ability.GetAbilityToTrigger() != null)
            {
                var loopingAbilityCheck = ability.GetAbilityToTrigger();
                while (loopingAbilityCheck != null)
                {
                    DamageManager.CalculateAbilityAttacker(ability.GetAbilityToTrigger());
                    if (loopingAbilityCheck.GetAbilityToTrigger() != null)
                        loopingAbilityCheck = loopingAbilityCheck.GetAbilityToTrigger();
                    else
                        loopingAbilityCheck = null;
                }
            }
        }
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
        if (ability.ownerEntityType != RootEntity.EntityType.Hazard)
            DamageManager.CalculateAbilityAttacker(ability);
    }

    public void CreateTriggerAbility(Vector3 location, Transform? preference, RootEntity.EntityType entityType)
    {
        BasicAbilityForm abilityResult = AbilityFactory.InstantiateWorldAbility(((BasicAbility)ability.abilityToTrigger), location, ability.abilityOwner, entityType, RootAbility.CreationMethod.Triggered, chaperone).GetComponent<BasicAbilityForm>();
        abilityResult.ability.Construct(ability.abilityToTrigger, ability.abilityOwner, entityType);
        abilityResult.transform.position = location;
        abilityResult.chaperone = chaperone;
        abilityResult.ability.creation = RootAbility.CreationMethod.Triggered;
        abilityResult.transform.rotation = this.transform.rotation;

        if (preference != null)
            abilityResult.targetPreference = preference;

        abilityResult.DelayedStart();

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
        if (timer > ability.snapshot.duration)
            Terminate();
    }
}