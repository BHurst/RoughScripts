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
    }

    public override void ActivateTalent()
    {
        GlobalEventManager.abilityCastTrigger += Effect;
        GameWorldReferenceClass.GW_Player.totalStats.GlobalHitDamage_Damage_MultiplyPercent.Increase(-.5f);
    }

    public override void DeactivateTalent()
    {
        GlobalEventManager.abilityCastTrigger -= Effect;
        GameWorldReferenceClass.GW_Player.totalStats.GlobalHitDamage_Damage_MultiplyPercent.Decrease(-.5f);
    }

    public override void Effect(object sender, WorldAbility worldAbility)
    {
        EffectRune_DamageOverTime newEffect = new EffectRune_DamageOverTime();
        newEffect.damage = DamageManager.CalculateAbilityAttacker(worldAbility) / 5;
        newEffect.duration = 5;
        if (worldAbility.wEffectRunes == null)
            worldAbility.wEffectRunes = new List<EffectRune>();
        worldAbility.wEffectRunes.Add(newEffect);
    }
}