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
            chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override bool ApplyDoT(RootCharacter target)
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
            chaperone.previousTargets.Add(target);
            return true;
        }
        return false;
    }

    public override void ApplyAreaDoT(RootCharacter target)
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
        }
    }

    public void TriggerParticleBurst(int index)
    {
        //If a particle system does not exist for long enough, burst will not trigger. No particles will be present thus immediately destroying it.
        if (pS.emission.burstCount > 0)
            pS.Emit((int)pS.emission.GetBurst(index).count.constant);
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