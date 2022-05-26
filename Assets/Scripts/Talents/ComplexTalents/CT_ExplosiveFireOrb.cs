using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_ExplosiveFireOrb : ComplexTalent
{
    public CT_ExplosiveFireOrb()
    {
        talentName = "Explosive Fire Orbs";
        cost = 2;
        talentDescription = "Your Fire based Orb abilities have a 25% chance to explode on contact, dealing 1 Fire damage in a 10m radius.";
        trigger = ComplexTalentTrigger.SpellHittingTarget;
    }

    public override void ActivateTalent()
    {
        GlobalEventManager.abilityHitTrigger += Effect;
    }

    public override void DeactivateTalent()
    {
        GlobalEventManager.abilityHitTrigger -= Effect;
    }

    public override void Effect(object sender, WorldAbility worldAbility)
    {
        if(worldAbility.wFormRune.formRuneType == Rune.FormRuneTag.Orb && worldAbility.wSchoolRune.schoolRuneType == Rune.SchoolRuneTag.Fire)
        {
            if(UnityEngine.Random.Range(0, 100) > 74)
            {
                Ability ctAbility = new Ability()
                {
                    abilityID = Guid.NewGuid(),
                    abilityName = "Explosive Fire Orb Effect",
                    aFormRune = new FormRune_Nova(),
                    aSchoolRune = new SchoolRune_Fire(),
                    aCastModeRune = new CastModeRune_Reserve(),

                    harmful = true,
                    initialized = true
                };

                ctAbility.aFormRune.formDamageMod = 1;

                ctAbility.aFormRune.formArea = 10;
                ctAbility.overrideDamage = 1;

                AbilityFactory.InstantiateWorldAbility(ctAbility, ((_WorldAbilityForm)sender).wA.transform.position, worldAbility.abilityOwner, worldAbility.ownerEntityType, WorldAbility.CreationMethod.Triggered).GetComponent<WorldAbility>();
            }
        }
    }
}