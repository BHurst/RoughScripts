using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_ExplosiveFireOrb : ComplexTalent
{
    public CT_ExplosiveFireOrb()
    {
        talentDescription = "Your Fire based Orb abilities explode on contact, creating a Rank 2 Fire Nova.";
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
            Ability ctAbility = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Explosive Fire Orb Effect",
                aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Nova },
                aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Fire, rank = 2 },
                aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant, rank = 1 },

                harmful = true,
                initialized = true
            };

            AbilityFactory.InstantiateWorldAbility(ctAbility, ((_WorldAbilityForm)sender).wA.transform.position, worldAbility.abilityOwner, true).GetComponent<WorldAbility>();
        }
    }
}