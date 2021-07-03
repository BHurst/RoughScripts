using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class NPCUnit : RootUnit
{
    public NavMeshAgent nav;
    public List<Ability> knownAbilities = new List<Ability>();
    public List<EnemyAbilitySO> enemyAbilitySOs = new List<EnemyAbilitySO>();

    void Start()
    {
        NPCUnitStart();
    }

    public void NPCUnitStart()
    {
        if (unitID == null)
            CreateInitial();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);

        foreach (EnemyAbilitySO enemyAbilitySO in enemyAbilitySOs)
        {
            Ability newAbility = new Ability();

            newAbility.abilityID = enemyAbilitySO.ability.abilityID;
            newAbility.abilityName = enemyAbilitySO.ability.abilityName;
            newAbility.castModeRune = enemyAbilitySO.ability.castModeRune;
            newAbility.schoolRune = enemyAbilitySO.ability.schoolRune;
            newAbility.formRune = enemyAbilitySO.ability.formRune;
            if (enemyAbilitySO.ability.buffRune.runeId != 0)
                newAbility.buffRune = enemyAbilitySO.ability.buffRune;
            if (enemyAbilitySO.ability.debuffRune.runeId != 0)
                newAbility.debuffRune = enemyAbilitySO.ability.debuffRune;
            if (enemyAbilitySO.ability.harmRune.runeId != 0)
                newAbility.harmRune = enemyAbilitySO.ability.harmRune;
            if (enemyAbilitySO.ability.healRune.runeId != 0)
                newAbility.healRune = enemyAbilitySO.ability.healRune;
            newAbility.specialEffect = null;
            newAbility.abilityToTrigger = null;
            newAbility.initialized = true;

            knownAbilities.Add(newAbility);
        }

        level.character = this.transform;

        RefreshStats();

        nav.speed = totalStats.MoveSpeed;
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        nav = GetComponent<NavMeshAgent>();
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
    }

    public void NavigationManagement()
    {
        if (nav.speed < totalStats.MoveSpeed && nav.speed != 0)
            state.Slowed = true;

        if (state.Rooted == false)
        {
            nav.speed = totalStats.MoveSpeed * totalStats.MoveSpeed_Movement_AddPercent;
        }
        else
        {
            nav.speed = 0;
        }
    }

    public void GetSpeech()
    {
        speech = ConversationFactory.LoadSpeech(unitName, speech.speechStage);
    }

    void Spawn()
    {

    }

    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void EnableRigidForce()
    {
        nav.updatePosition = false;
        nav.updateRotation = false;
        GetComponent<Rigidbody>().drag = .1f;
        GetComponent<Rigidbody>().angularDrag = .05f;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("Terrain").GetComponent<Collider>(), false);
    }

    public void DisableRigidForce()
    {
        nav.nextPosition = transform.position;
        nav.updatePosition = true;
        nav.updateRotation = true;
        GetComponent<Rigidbody>().drag = Mathf.Infinity;
        GetComponent<Rigidbody>().angularDrag = Mathf.Infinity;
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("Terrain").GetComponent<Collider>(), true);
    }

    public void NPCKill()
    {
        Kill();
        nav.ResetPath();
        nav.isStopped = true;
        EnableRigidForce();
    }

    public void LifeCheck()
    {
        if (unitHealth < 0)
            unitHealth = 0;
        else if (unitHealth > unitMaxHealth)
            unitHealth = unitMaxHealth;

        if (isAlive == true)
        {
            if (unitHealth <= 0)
            {
                Kill();
            }
        }
        else if (isAlive == false)
        {
            if (droppedItems == false)
            {
                charInventory.DropEverything();
                droppedItems = true;
            }

            if (unitHealth > 0)
            {
                isAlive = true;
                nav.isStopped = false;
                DisableRigidForce();
                droppedItems = false;
            }
        }
    }

    public void MeleeMovement()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.GetComponent<RootUnit>() != null)
    //        ResolveSizeCollision(this, collision.collider.GetComponent<RootUnit>());
    //}

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        timer += Time.deltaTime;
        if (knownAbilities.Count > 0)
            currentAbilityToUse = knownAbilities[0];

        LifeCheck();
        if (isAlive == true)
        {
            MeleeMovement();
            CastingTimeCheck();
            ResolveValueStatuses();
            if (state.Stunned == false)
            {

            }
            abilitiesOnCooldown.UpdateCooldowns();
            ActionCD();
        }
    }
}