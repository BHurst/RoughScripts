using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootWorldAbility : MonoBehaviour
{
    public int abilityID;
    public RootUnit abilityOwner;
    public SpellStats stats = new SpellStats();
    public Rigidbody skeleton;
    public float timer;
    public float activationTimer = 0;
    public bool started = false;
    public Vector3 previousFramePosition;
    public Quaternion previousFrameRotation;
    public List<RootUnit> hitNPCs = new List<RootUnit>();
    public List<RootUnit> previouslyHitNPCs = new List<RootUnit>();
    public GameObject closestNPC;
    public ParticleSystem pS;
    public Transform particleSpawnLocation;

    public int playerSpellIgnore = 1 << 4 | 1 << 8 | 1 << 9 | 1 << 10;

    public RaycastHit camRay;
    public RaycastHit spellRay;
    public RaycastHit forwardRay;

    public void ConsolidateKeywordBonuses()
    {
        foreach (AbilityModifierKeyword keyword in stats.abilityKeywords)
        {
            foreach (KeywordBonuses bonus in keyword.KeyBonuses)
            {
                //stats.weaponModifer += bonus.weaponModifer;
                //stats.numberOfSpells += bonus.numberOfSpells;
                //stats.abilityBaseCost += bonus.keywordBaseCost;
                //stats.abilityBaseRangeMinimum += bonus.keywordBaseRangeMinimum;
                //stats.abilityBaseRangeMaximum += bonus.keywordBaseRangeMaximum;
                //stats.abilityBaseCooldown += bonus.keywordBaseCooldown;
                //stats.abilityBasePulseTimer += bonus.keywordBasePulseTimer;
                //stats.abilityBasePulseDamage += bonus.keywordBasePulseDamage;
                //stats.abilityBaseDuration += bonus.keywordBaseDuration;
                //stats.abilityBaseInterval += bonus.keywordBaseInterval;
                //stats.abilityBaseCastTime += bonus.keywordBaseCastTime;
                //stats.abilityBaseArea += bonus.keywordBaseArea;
                //stats.abilityBaseForce += bonus.keywordBaseForce;
                //stats.randomLow *= bonus.randomLow;
                //stats.randomHigh *= bonus.randomHigh;
            }
        }
    }

    private void OnEnable()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out camRay, 100, playerSpellIgnore);
        Physics.Raycast(GameWorldReferenceClass.GW_Player.primarySpellCastLocation.position, camRay.point - GameWorldReferenceClass.GW_Player.transform.position, out spellRay, 100, playerSpellIgnore);
        //Physics.Raycast(transform.position, transform.forward, out forwardRay, 100, playerSpellIgnore);
        pS = GetComponentInChildren<ParticleSystem>();
        particleSpawnLocation = transform.Find("ParticleSpawnObject");
        //transform.rotation = Camera.main.transform.rotation;
    }

    public void ApplyStatusAreaTargets()
    {
        foreach (RootUnit target in hitNPCs)
        {
            if (stats.Statuses.Count > 0)
            {
                List<RootStatus> newStatusList = new List<RootStatus>();
                foreach (RootStatus status in stats.Statuses)
                {
                    RootStatus newStatus = status;

                    newStatusList.Add(newStatus);
                }
                target.ApplyStatusEffect(newStatusList);
            }
        }
    }

    public void GetTargets()
    {
        hitNPCs.Clear();
        Collider[] collisionSphere;

        if (!stats.abilityTags.Contains(AbilityTags.AbilityTag.Area))
        {
            closestNPC = UtilityService.ClosestObject(transform.position, .5f, 1 << 8);

            if (closestNPC != null)
            {
                if (!previouslyHitNPCs.Contains(closestNPC.GetComponent<RootUnit>()))
                    hitNPCs.Add(closestNPC.GetComponent<RootUnit>());
            }
        }
        else
        {
            collisionSphere = Physics.OverlapSphere(transform.position, stats.abilityBaseArea, 1 << 8);
            foreach (Collider c in collisionSphere)
            {
                if (c.GetComponent<RootUnit>() != null && !previouslyHitNPCs.Contains(c.GetComponent<RootUnit>()))
                    hitNPCs.Add(c.GetComponent<RootUnit>());
            }
        }
    }

    public void Pulse()
    {
        foreach (RootUnit target in hitNPCs)
        {
            if(stats.specialEffects != null)
            {
                foreach (ISpecialEffect special in stats.specialEffects)
                {
                    special.Effect(target);
                }
            }
            
            if (target.ResolveHit(this))
            {
                target.Kill();
                if (stats.abilityBaseForce > 0)
                    target.GetComponent<Rigidbody>().AddExplosionForce(stats.abilityBaseForce, transform.position, stats.abilityBaseArea, 1);
            }
            else
            {
                if (stats.abilityBaseForce > 0)
                {
                    Vector3 dir = target.transform.position - transform.position;
                    target.GetComponent<Rigidbody>().AddExplosionForce(stats.abilityBaseForce, transform.position, stats.abilityBaseArea, 1);
                }
            }
        }

        ApplyStatusAreaTargets();
    }

    public void ExecuteCollision()
    {
        RootAbility resolvingAbility = AbilityFactory.ToRootAbility(this);
        if (stats.whoShouldITarget == SpellStats.AbilityTarget.Self)
        {
            hitNPCs.Add(abilityOwner.GetComponent<RootUnit>());
        }
        else
            GetTargets();

        Pulse();
        if (!stats.abilityTags.Contains(AbilityTags.AbilityTag.Persist))
            Terminate();
    }

    public void ExectuteMeleeCollision()
    {
        RootAbility resolvingAbility = AbilityFactory.ToRootAbility(this);
        if (stats.whoShouldITarget == SpellStats.AbilityTarget.Self)
        {
            hitNPCs.Add(abilityOwner.GetComponent<RootUnit>());
        }
        else
        {
            GetTargets();
        }
        Pulse();
    }

    //void OnTriggerEnter(Collider collider)
    //{
    //    if (stats.activationStart <= activationTimer && stats.activationEnd >= activationTimer)
    //    {
    //        if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
    //        {
    //            var enemy = collider.transform.GetComponent<RootUnit>();
    //            if (enemy == null)
    //                Destroy(this.gameObject);
    //            else if (enemy.unitID != stats.abilityOwner.unitID)
    //                ExectuteCollision();
    //        }
    //        else if (stats.abilityTags.Contains(AbilityTags.AbilityTag.WeaponCast))
    //        {
    //            var enemy = collider.transform.GetComponent<RootUnit>();
    //            if (enemy != null && !previouslyHitNPCs.Contains(enemy))
    //            {
    //                hitNPCs.Add(enemy);
    //                RootAbility resolvingAbility = AbilityFactory.ToRootAbility(this);
    //                Pulse(resolvingAbility);
    //                previouslyHitNPCs.Add(enemy);
    //                hitNPCs.Clear();
    //            }
    //        }
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.transform.GetComponent<RootUnit>();
        if (enemy == null && !stats.abilityTags.Contains(AbilityTags.AbilityTag.Persist))
            Terminate();
    }

    public void Terminate()
    {
        if(pS != null)
        {
            pS.transform.SetParent(null);
        }

        Destroy(this.gameObject);
    }
}