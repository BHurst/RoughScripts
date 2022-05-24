﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootCharacter : RootEntity
{
    public int team = 2;
    public bool inCombat = false;
    public bool hasSpeech = false;
    public Hostility hostility;
    public bool isAlive = true;
    public Ability abilityPreparingToCast = null;
    public Ability abilityBeingCast = null;
    public Ability abilityBeingReserved = null;
    public float currentCastingTime = 0;
    public float talkRange = 3.2f;
    public float attackTimer = 0;
    public float moveAbilityTimer = 0;
    public int size = 2;
    public bool attackable = true;
    public Transform primarySpellCastLocation;
    public Transform mainhandWeapon;
    public Transform offhandWeaponLocation;
    public float waistHight = 1f;
    public CharacterInventory charInventory = new CharacterInventory();
    public UnitStats totalStats = new UnitStats();
    public UnitAttributes attributes = new UnitAttributes();
    public UnitStates state = new UnitStates();
    public CharacterSpeech speech = new CharacterSpeech();
    public EquipmentDoll unitEquipment = new EquipmentDoll();
    public float globalCooldown = 0;
    public List<Ability> abilitiesOnCooldown = new List<Ability>();
    public PopupTextManager popupTextManager;
    public List<Status> activeStatuses = new List<Status>();
    public float timer;
    public ActionState actionState = ActionState.Idle;
    public MovementState movementState = MovementState.Idle;
    public SprintState sprintState = SprintState.Idle;
    public bool pushedBeyondMaxSpeed = false;
    public Vector3 eyesOffset = new Vector3(0, 2, 0);
    public UnitAbilityReserve unitAbilityReserve = new UnitAbilityReserve();
    public Animator animator;
    public Rigidbody unitBody;
    public UnitUIManager uiCollection;

    private void OnBecameInvisible()
    {
        uiCollection.Hide();
    }

    private void OnBecameVisible()
    {
        uiCollection.Show();
    }

    public void BasicStart()
    {
        InitializeUnitUI();
    }

    public void InitializeUnitUI()
    {
        uiCollection = GetComponent<UnitUIManager>();
        GameObject newUICollection = Instantiate(Resources.Load("Prefabs/UIComponents/UnitUICollectionObject")) as GameObject;
        newUICollection.name = gameObject.name + "UICollectionObject";
        newUICollection.transform.SetParent(GameObject.Find("UnitUICollection").transform);
        newUICollection.transform.position = new Vector3(-200, -200, 0);
        uiCollection.parentPane = newUICollection.transform;
        Transform anchor = transform.Find("UnitUIAnchor");
        if (anchor != null)
            uiCollection.DelayedStart(anchor, newUICollection.transform.Find("Floating_Damage").GetComponent<FloatingDamage>(), newUICollection.transform.Find("Floating_Healing").GetComponent<FloatingHealing>(), GameObject.Find(newUICollection.name).GetComponent<CanvasGroup>());
        else
            uiCollection.DelayedStart(transform, newUICollection.transform.Find("Floating_Damage").GetComponent<FloatingDamage>(), newUICollection.transform.Find("Floating_Healing").GetComponent<FloatingHealing>(), GameObject.Find(newUICollection.name).GetComponent<CanvasGroup>());

        uiCollection.enemyHealthBar = newUICollection.transform.Find("DamagedHealthBar").GetComponent<EnemyHealthBar>();
        uiCollection.enemyHealthBar.character = this;
    }

    public void Shove(float pushForce, Vector3 direction)
    {
        unitBody.AddForce(direction * pushForce, ForceMode.Impulse);
        pushedBeyondMaxSpeed = true;
    }

    public void IncrementTimers()
    {
        timer += Time.deltaTime;
        moveAbilityTimer += Time.deltaTime;
        globalCooldown = Mathf.Clamp(globalCooldown -= Time.deltaTime, 0, 100);
        if (abilitiesOnCooldown.Count > 0)
        {
            for (int i = abilitiesOnCooldown.Count - 1; i > -1; i--)
            {
                abilitiesOnCooldown[i].cooldown = Mathf.Clamp(abilitiesOnCooldown[i].cooldown -= Time.deltaTime, 0, 100000000);
                if (abilitiesOnCooldown[i].cooldown == 0)
                    abilitiesOnCooldown.RemoveAt(i);
            }
        }
    }

    bool PickupRangeCheck(WorldItem currentItemTarget)
    {
        if (Vector3.Distance(currentItemTarget.transform.position, this.transform.position) <= 1)
            return true;
        else
            return false;
    }

    public bool InteractRangeCheck(WorldObject currentInteractTarget)
    {
        if (Vector3.Distance(currentInteractTarget.transform.position, this.transform.position) <= currentInteractTarget.distanceToBeInteracted)
            return true;
        else
            return false;
    }

    public virtual void AddStatus(Status status)
    {
        Status foundStatus = activeStatuses.Find(x => x.name == status.name);

        if (foundStatus != null)
        {
            if (status.refreshable)
            {
                foundStatus.currentDuration = status.maxDuration;
            }
            if (status.stackable)
            {
                if (status.stacks < status.maxStacks)
                    foundStatus.stacks++;
            }
        }

        activeStatuses.Add(status);
        status.currentDuration = status.maxDuration;
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.IncreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public virtual void RemoveStatus(Status status)
    {
        activeStatuses.Remove(status);
        status.setToRemove = true;
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.DecreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public virtual void ResolveHit(float value, bool overTime)
    {
        if (value != 0)
        {
            if (overTime)
                uiCollection.floatingDamage.AddDot(value);
            else
                uiCollection.floatingDamage.AddHit(value, value / totalStats.Health_Max);
        }
    }

    public virtual void ResolveHeal(float value, bool overTime)
    {
        if (value != 0)
        {
            if (overTime)
                uiCollection.floatingHealing.AddHot(value);
            else
                uiCollection.floatingHealing.AddHit(value);
        }
    }

    public void ResolveValueStatuses()
    {
        float totalStatusChange = 0;

        for (int i = activeStatuses.Count - 1; i > -1; i--)
        {
            totalStatusChange -= activeStatuses[i].rate * Time.deltaTime;
            activeStatuses[i].currentDuration -= Time.deltaTime;
            if (activeStatuses[i].currentDuration <= 0)
            {
                RemoveStatus(activeStatuses[i]);
            }
        }
        if (totalStatusChange != 0)
        {
            DamageManager.CalculateStatusDamage(this, totalStatusChange);
            if (totalStatusChange > 0)
                ResolveHeal(totalStatusChange, true);
            else
                ResolveHit(-totalStatusChange, true);
        }
    }

    public virtual void ActiveAbilityCheck()
    {
        if (abilityPreparingToCast != null && abilityPreparingToCast.initialized)
        {
            if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            {
                Cast(abilityPreparingToCast);
                StopCast();
                return;
            }
            currentCastingTime += Time.deltaTime;
            if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                if (currentCastingTime > abilityPreparingToCast.aCastModeRune.baseCastTime)
                {
                    Cast(abilityPreparingToCast);
                    StopCast();
                    return;
                }
            }
        }
    }

    public virtual void Cast()
    {

    }

    public void Cast(Ability ability)
    {
        actionState = ActionState.Idle;
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", ability.aFormRune.formRuneType))) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", ability.aFormRune.formRuneType, ability.aSchoolRune.schoolRuneType))) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(ability, unitID, entityType);
        abilityResult.transform.position = primarySpellCastLocation.position;

        if (worldAbility.wEffectRunes != null)
        {
            foreach (var rune in worldAbility.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                    rune.Effect(this, this, worldAbility);
            }
        }
    }

    public void Kill()
    {
        totalStats.Health_Current = 0;
        isAlive = false;
        state.ClearState();
    }

    public virtual void StopCast()
    {
        currentCastingTime = 0;
        abilityPreparingToCast = null;
    }
}

public enum ActionState
{
    Idle,
    Animating,
    Attacking,
    Casting,
    Channeling
}

public enum MovementState
{
    Idle,
    Moving
}

public enum SprintState
{
    Idle,
    Sprinting
}

public enum Hostility
{
    Hostile,
    Passive
}