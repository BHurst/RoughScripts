using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3_DotConvert : Tier3Talent
{
    public T3_DotConvert()
    {
        talentName = "Dot Donvert";
        cost = 2;
        talentDescription = "Half of all hit damage is dealt immediately and the other half over 5 seconds";
        trigger = Tier3TalentTrigger.SpellHittingTarget;
        tier = Tier.tier3;
    }

    public override void ActivateTalent()
    {
        GlobalEventManager.abilityCastTrigger += Effect;
        PlayerCharacterUnit.player.totalStats.GlobalHitDamage_Damage_MultiplyPercent.Increase(-.5f);
    }

    public override void DeactivateTalent()
    {
        GlobalEventManager.abilityCastTrigger -= Effect;
        PlayerCharacterUnit.player.totalStats.GlobalHitDamage_Damage_MultiplyPercent.Decrease(-.5f);
    }

    public override void Effect(object sender, _WorldAbilityForm abilityObject)
    {
        EffectRune_DamageOverTime newEffect = new EffectRune_DamageOverTime();
        newEffect.damage = abilityObject.ability.snapshot.damage / 5;
        newEffect.duration = 5;
        if (abilityObject.ability.effectRunes == null)
            abilityObject.ability.effectRunes = new List<EffectRune>();
        abilityObject.ability.effectRunes.Add(newEffect);
    }
}