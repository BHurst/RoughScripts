using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_ProjectileReflect : EffectRune
{
    public EffectRune_ProjectileReflect()
    {
        triggerTag = TriggerTag.OnCast;
    }
    
    public override void Effect(RootUnit target, RootUnit owner, WorldAbility worldAbility)
    {
        Collider[] collisionSphere;

        collisionSphere = Physics.OverlapSphere(owner.primarySpellCastLocation.position, 2, 1 << 11);

        foreach (var item in collisionSphere)
        {
            var ability = item.GetComponent<EnemyWorldAbility>();
            if (ability != null && ability.enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Projectile)
            {
                ability.reflected = true;
                item.transform.LookAt(GameWorldReferenceClass.GetUnitByID(ability.enemyAbilityStats.owner).transform.position);
            }
        }
    }
}