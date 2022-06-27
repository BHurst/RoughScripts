using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAbilityForm : RootAbilityForm
{

    public override bool ApplyHit(RootCharacter target, bool addToPreviousTargets)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            RootCharacter owner = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner);
            DamageManager.CalculateAbilityDefender(target.unitID, ability);
            if (ability.GetHitType() == RootAbility.HitType.Hit)
                GlobalEventManager.AbilityHitTrigger(this, this, target, target.transform.position);


            if (ability.effectRunes != null)
            {
                foreach (var rune in ability.effectRunes)
                {
                    if (rune.triggerTag == Rune.TriggerTag.OnHit)
                        if (!rune.targetSelf)
                            rune.Effect(target, owner, this);
                }
            }

            if (owner != null)
                ability.abilityStateManager.ApplyStateOnHit(target, owner);
            if (addToPreviousTargets)
                chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override bool ApplyDoT(RootCharacter target, bool addToPreviousTargets)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            RootCharacter owner = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner);
            Status status = new Status();
            status.name = ability.abilityName;
            status.statusId = ability.abilityID;
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
                            rune.Effect(target, owner, this);
                }
            }

            if (owner != null)
                ability.abilityStateManager.ApplyStateOnHit(target, owner);
            if (addToPreviousTargets)
                chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override void ApplyAreaDoT(RootCharacter target, bool addToPreviousTargets)
    {
        if (CanIHit(target, chaperone, ability.GetTargettingType()))
        {
            RootCharacter owner = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner);
            Status status = new Status();
            status.name = ability.abilityName;
            status.statusId = ability.abilityID;
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
                            rune.Effect(target, owner, this);
                }
            }
            if (addToPreviousTargets)
                chaperone.previousTargets.Add(target);
        }
    }

    public void TriggerParticleBurst(int index)
    {
        //If a particle system does not exist for long enough, burst will not trigger. No particles will be present thus immediately destroying it.
        if (pS.emission.burstCount > 0)
            pS.Emit((int)pS.emission.GetBurst(index).count.constant);
    }

    public void CollisionTrigger(Collider collider)
    {
        var characterTarget = collider.transform.GetComponent<RootCharacter>();
        var destructableObject = collider.transform.GetComponent<DestructableObject>();
        if (characterTarget != null)
        {
            if (ApplyHit(characterTarget, true))
            {
                if (ability.abilityToTrigger != null)
                    CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
                Terminate();
            }
        }
        else if (destructableObject != null)
        {
            destructableObject.PushFromDirection(transform.forward, ability.snapshot.force);
            destructableObject.InflictDamage(ability.snapshot.damage, false);
            if (ability.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
            Terminate();
        }
        else if (collider.gameObject.layer == 9)
            Terminate();
    }

    public void PersistentAreaTrigger()
    {
        List<RootCharacter> areaTargets = GameWorldReferenceClass.GetNewEnemyRootUnitInCapsule(transform.position, transform.position + new Vector3(0, 1, 0), ability.snapshot.area, new List<RootCharacter>(), ability.GetAsBasic().formRune.formMaxAdditionalTargets, GameWorldReferenceClass.GetTeam(ability.abilityOwner));
        List<DestructableObject> destructableTargets = GameWorldReferenceClass.GetDestructableObjectsInCapsule(transform.position, transform.position + new Vector3(0, 1, 0), ability.snapshot.area);

        foreach (DestructableObject target in destructableTargets)
        {
            target.InflictDamage(ability.GetAsBasic().formRune.formInterval * ability.snapshot.damage, false);
        }

        foreach (var target in areaTargets)
        {
            ApplyAreaDoT(target, false);
        }
    }

    public void AreaHitTrigger()
    {
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewRootUnitInSphere(ability.GetAsBasic().formRune.formArea, transform.position, chaperone.previousTargets, ability.GetAsBasic().formRune.formMaxAdditionalTargets);
        List<DestructableObject> destructableTargets = GameWorldReferenceClass.GetDestructableObjectsInSphere(ability.GetAsBasic().formRune.formArea, transform.position);
        pS.transform.localScale = new Vector3(ability.GetAsBasic().formRune.formArea, ability.GetAsBasic().formRune.formArea, ability.GetAsBasic().formRune.formArea);
        TriggerParticleBurst(0);
        if (targets.Count > 0)
        {
            foreach (RootCharacter target in targets)
            {
                if (target.unitID != ability.abilityOwner)
                {
                    ApplyHit(target, true);
                    if (ability.abilityToTrigger != null)
                        CreateTriggerAbility(target.transform.position, null, ability.ownerEntityType);
                }
            }
        }
        if (destructableTargets.Count > 0)
        {
            foreach (var dObject in destructableTargets)
            {
                dObject.InflictDamage(ability.snapshot.damage, false);
                dObject.PushFromOrigin(transform.position, ability.snapshot.force);
            }
            if (ability.abilityToTrigger != null)
                CreateTriggerAbility(transform.position, null, ability.ownerEntityType);
        }
        Terminate();
    }

    public void CreateTriggerAbility(Vector3 location, Transform? preference, RootEntity.EntityType entityType)
    {
        BasicAbilityForm abilityResult = AbilityFactory.InstantiateBasicWorldAbility(((BasicAbility)ability.abilityToTrigger), location, ability.abilityOwner, entityType, RootAbility.CreationMethod.Triggered, chaperone).GetComponent<BasicAbilityForm>();
        abilityResult.ability.Construct(ability.abilityToTrigger, ability.abilityOwner, entityType);
        abilityResult.transform.position = location;
        abilityResult.chaperone = chaperone;
        abilityResult.ability.creation = RootAbility.CreationMethod.Triggered;
        abilityResult.transform.rotation = this.transform.rotation;

        abilityResult.DelayedStart();

    }
}