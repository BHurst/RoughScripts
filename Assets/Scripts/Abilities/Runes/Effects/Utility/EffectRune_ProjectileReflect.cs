using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRune_ProjectileReflect : EffectRune
{
    public EffectRune_ProjectileReflect()
    {
        triggerTag = TriggerTag.OnCast;
        runeDescription = "The spell will reflect projectiles that it collides with.";
        readableName = "Projectile Reflect";
    }
    
    public override void Effect(RootCharacter target, RootCharacter owner, _WorldAbilityForm abilityObject)
    {
        Collider[] collisionSphere;

        collisionSphere = Physics.OverlapSphere(owner.primarySpellCastLocation.position, 2, 1 << 11);

        foreach (var item in collisionSphere)
        {
            var hostileAbility = item.GetComponent<EnemyWorldAbility>();
            if (hostileAbility != null && hostileAbility.enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Projectile)
            {
                hostileAbility.reflected = true;
                item.transform.LookAt(GameWorldReferenceClass.GetUnitByID(hostileAbility.enemyAbilityStats.owner).transform.position);
            }
        }
    }
}