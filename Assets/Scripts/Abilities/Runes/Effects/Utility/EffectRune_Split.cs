using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectRune_Split : EffectRune
{
    int numberOfCopies = 3;
    public EffectRune_Split()
    {
        triggerTag = TriggerTag.OnHit;
        rank = 1;
        runeDescription = "Will split to additional targets after hitting an enemy.";
        readableName = "Split";
    }

    public override void Effect(RootCharacter target, RootCharacter owner, _WorldAbilityForm abilityObject)
    {
        List<RootCharacter> targetsSplitTo = new List<RootCharacter>() { abilityObject.previousTargets.LastOrDefault() };
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(10, abilityObject.transform.position, targetsSplitTo, numberOfCopies, owner.team);

        for (int i = 0; i < targets.Count; i++)
        {
            _WorldAbilityForm newWorldAbility = AbilityFactory.InstantiateWorldAbility(abilityObject.ability, abilityObject.transform.position, abilityObject.ability.abilityOwner, abilityObject.ability.ownerEntityType, BaseAbility.CreationMethod.Triggered);
            newWorldAbility.targetPreference = targets[i].transform;
            newWorldAbility.previousTargets.AddRange(abilityObject.previousTargets);
        }
    }
}