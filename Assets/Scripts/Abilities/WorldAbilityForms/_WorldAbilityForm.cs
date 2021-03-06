using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _WorldAbilityForm : MonoBehaviour
{
    public float timer = 0;
    public float duration = 0;
    public RaycastHit spellRay;
    public RaycastHit camRay;
    public Rigidbody skeleton;
    public ParticleSystem pS;
    public WorldAbility wA;

    public void InitialCreation()
    {
        wA = GetComponent<WorldAbility>();
        skeleton = GetComponent<Rigidbody>();
        pS = GetComponentInChildren<ParticleSystem>();
    }

    public void FaceOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
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

    public void PositionAtOwnerTarget()
    {
        Physics.Raycast(GameWorldReferenceClass.GW_PlayerCamera.transform.position, GameWorldReferenceClass.GW_PlayerCamera.transform.forward, out camRay, 100, ~(1 << 11 | 1 << 12));
        Physics.Raycast(GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).primarySpellCastLocation.position, out spellRay, 100, ~(1 << 11 | 1 << 12));
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
        transform.position = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).transform.position;
    }

    public void PositionAtOwnerCastLocation()
    {
        transform.position = GameWorldReferenceClass.GetUnitByID(wA.abilityOwner).primarySpellCastLocation.position;
    }

    public void TriggerParticleBurst(int index)
    {
        //If a particle system does not exist for long enough, burst will not trigger. No particles will be present thus immediately destroying it.
        if (pS.emission.burstCount > 0)
            pS.Emit((int)pS.emission.GetBurst(index).count.constant);
    }

    public void CalculateAttackerStats()
    {
        DamageManager.CalculateAbilityAttacker(wA);
    }

    public void CreateTriggerAbility(Vector3 location, Transform? preference)
    {
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", wA.abilityToTrigger.aFormRune.formRuneType.ToString()))) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", wA.abilityToTrigger.aFormRune.formRuneType.ToString(), wA.abilityToTrigger.aSchoolRune.schoolRuneType.ToString()))) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(wA.abilityToTrigger, wA.abilityOwner);
        abilityResult.transform.position = location;
        worldAbility.previousTargets.AddRange(wA.previousTargets);
        worldAbility.isTriggered = true;
        abilityResult.transform.rotation = this.transform.rotation;

        if (preference != null)
            worldAbility.targetPreference = preference;
            
    }

    public void ApplyHit(RootUnit target)
    {
        if((target.unitID == wA.abilityOwner && wA.harmful && wA.selfHarm) || target.unitID != wA.abilityOwner)
            DamageManager.CalculateAbilityDefender(target.unitID, wA);

        if(wA.wEffectRunes != null)
        {
            foreach (var rune in wA.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnHit)
                    rune.Effect(target, GameWorldReferenceClass.GetUnitByID(wA.abilityOwner), wA);
            }
        }
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

    public void Tick()
    {
        if (duration == 0)
            TriggerParticleBurst(0);
        timer += Time.deltaTime;
        if (timer > duration)
            Terminate();
    }
}