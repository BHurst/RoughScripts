using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueAbilityForm : RootAbilityForm
{
    RootAbility.HitType hitType;

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
            status.statusId = ability.abilityID;
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
        if ((target.unitID == ability.abilityOwner && ability.harmful && ability.selfHarm) || target.unitID != ability.abilityOwner)
        {
            Status status = new Status();
            status.name = ability.abilityName;
            status.statusId = ability.abilityID;
            status.sourceUnit = ability.abilityOwner;
            status.rate = ability.snapshot.damage;
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
}