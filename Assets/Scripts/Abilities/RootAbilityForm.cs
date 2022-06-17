using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootAbilityForm : MonoBehaviour
{
    public AbilityChaperone chaperone;
    public RootAbility ability;
    public Transform targetPreference;

    public float timer = 0;
    public RaycastHit spellRay;
    public RaycastHit camRay;
    public Rigidbody skeleton;
    public ParticleSystem pS;

    public virtual bool ApplyHit(RootCharacter target)
    {
        return false;
    }

    public virtual bool ApplyDoT(RootCharacter target)
    {
        return false;
    }

    public virtual void ApplyAreaDoT(RootCharacter target)
    {
        
    }

    public bool CanIHit(RootCharacter target, AbilityChaperone chaperone, RootAbility.TargettingType targettingType)
    {
        if(target.isAlive && target.unitID != ability.abilityOwner)
        {
            if (targettingType == RootAbility.TargettingType.Multiple)
                return true;
            if (targettingType == RootAbility.TargettingType.Single && !chaperone.previousTargets.Contains(target))
                return true;
        }
        return false;
    }
}