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

    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject)
    {
        List<RootCharacter> targetsSplitTo = new List<RootCharacter>();
        targetsSplitTo.AddRange(abilityObject.chaperone.previousTargets);
        targetsSplitTo.AddRange(abilityObject.chaperone.previouslyTargeted);
        List<RootCharacter> targets = GameWorldReferenceClass.GetNewEnemyRootUnitInSphere(10, abilityObject.transform.position, targetsSplitTo, numberOfCopies, owner.team);

        for (int i = 0; i < targets.Count; i++)
        {
            BasicAbilityForm newWorldAbility = AbilityFactory.InstantiateWorldAbility(abilityObject.ability.GetAsBasic(), abilityObject.transform.position, abilityObject.ability.GetAsBasic().abilityOwner, abilityObject.ability.GetAsBasic().ownerEntityType, RootAbility.CreationMethod.Triggered, abilityObject.chaperone);
            newWorldAbility.targetPreference = targets[i].transform;
            newWorldAbility.chaperone.previouslyTargeted.Add(targets[i]);
        }
    }
}