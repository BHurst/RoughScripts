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
    
    public override void Effect(RootCharacter target, RootCharacter owner, RootAbilityForm abilityObject)
    {
        Collider[] collisionSphere;

        collisionSphere = Physics.OverlapSphere(owner.primarySpellCastLocation.position, 2, 1 << 11);

        foreach (var item in collisionSphere)
        {
            RootAbilityForm hostileAbility = item.GetComponent<RootAbilityForm>();
            if (hostileAbility != null && hostileAbility.formType == RootAbilityForm.FormType.Projectile)
            {
                item.transform.LookAt(GameWorldReferenceClass.GetUnitByID(hostileAbility.ability.abilityOwner).transform.position);
                hostileAbility.ability.abilityOwner = owner.unitID;
            }
        }
    }
}