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
    public FormType formType;

    public void DelayedStart()
    {
        ability = GetComponent<RootAbilityForm>().ability;
        skeleton = GetComponent<Rigidbody>();
        if (ability is BasicAbility)
            pS = GetComponentInChildren<ParticleSystem>();
        gameObject.layer = 11;

        if (ability.creation != RootAbility.CreationMethod.Triggered)
        {
            CalculateAttackerStats();
            if (ability.GetAbilityToTrigger() != null)
            {
                var loopingAbilityCheck = ability.GetAbilityToTrigger();
                while (loopingAbilityCheck != null)
                {
                    DamageManager.CalculateAbilityAttacker(ability.GetAbilityToTrigger());
                    if (loopingAbilityCheck.GetAbilityToTrigger() != null)
                        loopingAbilityCheck = loopingAbilityCheck.GetAbilityToTrigger();
                    else
                        loopingAbilityCheck = null;
                }
            }
        }
    }

    public void Tick()
    {
        timer += Time.deltaTime;
        if (timer > ability.snapshot.duration)
            Terminate();
    }

    public void Terminate()
    {
        if (pS != null)
        {
            pS.transform.SetParent(null);
            pS.transform.localScale = new Vector3(1, 1, 1); //When a scaled object parent is removed, the particle system takes on that scale.
        }

        Destroy(this.gameObject);
    }

    public void Obliterate()
    {
        Destroy(this.gameObject);
    }

    public void FaceOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
        if (camRay.collider != null)
            transform.LookAt(spellRay.point);
        else
        {
            transform.LookAt(GameWorldReferenceClass.GW_PlayerCamera.transform.position + GameWorldReferenceClass.GW_PlayerCamera.transform.forward * 1000);
        }
    }

    public void FaceNewTarget(Transform target)
    {
        transform.LookAt(target);
    }

    public void ProjectileLocationPredict(Transform target)
    {
        Vector3 leadPosition = UtilityService.FirstOrderIntercept(transform.position, new Vector3(), 15f, target.transform.position, target.GetComponent<Rigidbody>().velocity);
        transform.LookAt(leadPosition + new Vector3(0, target.GetComponent<CapsuleCollider>().height / 2, 0));
    }

    public void PositionAtOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
        if (camRay.collider != null)
            transform.position = spellRay.point;
        else
        {
            transform.position = GameWorldReferenceClass.GW_PlayerCamera.transform.position + GameWorldReferenceClass.GW_PlayerCamera.transform.forward * 1000;
        }
    }

    public void PositionAtNewTarget(Transform target)
    {
        transform.position = target.position;
    }

    public void PositionAtOwner()
    {
        transform.position = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).unitBody.transform.position;
    }

    public void PositionAtOwnerCastLocation()
    {
        transform.position = GameWorldReferenceClass.GetUnitByID(ability.abilityOwner).primarySpellCastLocation.position;
    }

    public void CalculateAttackerStats()
    {
        if (ability.ownerEntityType != RootEntity.EntityType.Hazard)
            DamageManager.CalculateAbilityAttacker(ability);
    }

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
        if (target.isAlive && target.unitID != ability.abilityOwner)
        {
            if (targettingType == RootAbility.TargettingType.Multiple)
                return true;
            if (targettingType == RootAbility.TargettingType.Single && !chaperone.previousTargets.Contains(target))
                return true;
        }
        return false;
    }

    public enum FormType
    {
        None,
        Projectile,
        Area
    }
}