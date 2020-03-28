using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWorldAbility : RootWorldAbility
{
    RaycastHit spellHit;
    public float spellDuration;
    public float pulseTimer = 0f;

    private void Start()
    {
        skeleton = GetComponent<Rigidbody>();

        spellDuration = stats.abilityBaseDuration;
        if (stats.whoShouldITarget != SpellStats.AbilityTarget.Self && !stats.abilityTags.Contains(AbilityTags.AbilityTag.Buff))
        {
            if (camRay.collider != null)
            {
                transform.LookAt(camRay.point);
            }
            else
            {
                transform.LookAt(transform.position + Camera.main.transform.forward * 100);
            }
        }

        if(stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile) && stats.abilityTags.Contains(AbilityTags.AbilityTag.Local))
        {

        }
        if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
        {
            skeleton.velocity = transform.forward * stats.abilityBaseSpeed;
        }
        else if(stats.abilityTags.Contains(AbilityTags.AbilityTag.Local))
        {
            transform.position = abilityOwner.transform.position;
        }
        else
        {
            Physics.Raycast(transform.position, transform.forward, out spellRay);
            transform.position = spellRay.point;

            ExecuteCollision();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!stats.abilityTags.Contains(AbilityTags.AbilityTag.Duration) && !stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
        {
            ExecuteCollision();
        }
        else
        {
            if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Local))
            {
                transform.position = abilityOwner.transform.position;
            }

            if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Persist))
            {
                if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Pulse))
                {
                    pulseTimer += Time.deltaTime;
                    if (pulseTimer >= stats.abilityBasePulseTimer)
                    {
                        GetTargets();
                        Pulse();
                        pulseTimer = 0;
                    }
                }
            }

            if(stats.abilityTags.Contains(AbilityTags.AbilityTag.Duration))
            {
                spellDuration -= Time.deltaTime;
                if (stats.abilityBaseDuration <= spellDuration)
                    Terminate();
            }

            if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
            {
                skeleton.velocity = transform.forward * stats.abilityBaseSpeed;

                if (stats.abilityBasePulseTimer > 0)
                {
                    timer += Time.deltaTime;
                    if (timer >= stats.abilityBasePulseTimer)
                    {
                        GetTargets();
                        RootAbility resolvingAbility = AbilityFactory.ToRootAbility(this);
                        Pulse();
                        timer = 0;
                    }
                }
            }

            activationTimer += Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        if (stats.activationStart <= activationTimer && stats.activationEnd >= activationTimer && stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
        {
            if (!started)
            {
                previousFramePosition = transform.position;
                previousFrameRotation = transform.rotation;
                started = true;
            }
            else
            {
                Physics.SphereCast(previousFramePosition, transform.GetComponent<SphereCollider>().radius, transform.position - previousFramePosition, out spellHit, Vector3.Distance(transform.position, previousFramePosition));

                if (spellHit.collider != null && spellHit.collider.transform != this.transform)
                    Kolide(spellHit.collider);

                previousFramePosition = transform.position;
                previousFrameRotation = transform.rotation;
            }
        }
    }

    void Kolide(Collider collider)
    {
        if (stats.activationStart <= activationTimer && stats.activationEnd >= activationTimer)
        {
            var enemy = collider.transform.GetComponent<RootUnit>();
            if (enemy == null && !stats.abilityTags.Contains(AbilityTags.AbilityTag.Persist))
                Terminate();
            else if (enemy.unitID != abilityOwner.GetComponent<RootUnit>().unitID)
                ExecuteCollision();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (stats.abilityTags.Contains(AbilityTags.AbilityTag.Projectile))
            Kolide(collider);
    }
}