using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_ExplosiveFireOrb : Tier3Talent
{
    public T3_ExplosiveFireOrb()
    {
        talentName = "Explosive Fire Orbs";
        cost = 2;
        talentDescription = "Your Fire based Orb abilities have a 25% chance to explode on contact, dealing 1 Fire damage in a 10m radius.";
        trigger = Tier3TalentTrigger.SpellHittingTarget;
        tier = Tier.tier3;
    }

    public override void ActivateTalent()
    {
        GlobalEventManager.abilityHitTrigger += Effect;
    }

    public override void DeactivateTalent()
    {
        GlobalEventManager.abilityHitTrigger -= Effect;
    }

    public override void Effect(object sender, _WorldAbilityForm abilityObject)
    {
        if(abilityObject.ability.formRune.formRuneType == Rune.FormRuneTag.Orb && abilityObject.ability.schoolRune.schoolRuneType == Rune.SchoolRuneTag.Fire)
        {
            if(UnityEngine.Random.Range(0, 100) > 74)
            {
                Ability ctAbility = new Ability()
                {
                    abilityID = Guid.NewGuid(),
                    abilityName = "Explosive Fire Orb Effect",
                    formRune = new FormRune_Nova(),
                    schoolRune = new SchoolRune_Fire(),
                    castModeRune = new CastModeRune_Reserve(),

                    harmful = true,
                    initialized = true
                };

                ctAbility.formRune.formDamageMod = 1;

                ctAbility.formRune.formArea = 10;
                ctAbility.overrideDamage = 1;

                AbilityFactory.InstantiateWorldAbility(ctAbility, abilityObject.transform.position, abilityObject.ability.abilityOwner, abilityObject.ability.ownerEntityType, Ability.CreationMethod.Triggered);
            }
        }
    }
}