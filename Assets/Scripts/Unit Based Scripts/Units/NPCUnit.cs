using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class NPCUnit : RootUnit
{
    public NavMeshAgent nav;

    void Start()
    {
        NPCUnitStart();
    }

    public void NPCUnitStart()
    {
        if (unitID == 0)
            CreateInitial();
        GameWorldReferenceClass.GW_listOfAllCharacters.Add(this);

        level.character = this.transform;

        RefreshStats();

        nav.speed = totalStats.MoveSpeed;
        nav.angularSpeed = totalStats.BaseTurnSpeed;
        nav.acceleration = totalStats.BaseAcceleration;
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        nav = GetComponent<NavMeshAgent>();
        unitID = UnityEngine.Random.Range(0, int.MaxValue);
    }

    public void NavigationManagement()
    {
        if (nav.speed < totalStats.MoveSpeed && nav.speed != 0)
            state.Slowed = true;

        if (state.Rooted == false)
        {
            nav.speed = totalStats.MoveSpeed * totalStats.BonusMoveSpeedPercent;
            nav.angularSpeed = totalStats.BaseTurnSpeed * totalStats.BonusMoveSpeedPercent;
            nav.acceleration = totalStats.BaseAcceleration * totalStats.BonusMoveSpeedPercent;
        }
        else
        {
            nav.speed = 0;
        }

        nav.angularSpeed = totalStats.BaseTurnSpeed * totalStats.BonusMoveSpeedPercent;
        nav.acceleration = totalStats.BaseAcceleration * totalStats.BonusMoveSpeedPercent;
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

    public void DeathCheck()
    {
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
                charInventory.DropEverything(this);
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

        DeathCheck();
        if (isAlive == true)
        {
            MeleeMovement();
            MovementCheck();
            CastingTimeCheck();
            if (state.Stunned == false)
            {

            }
            ResolveStatusEffects();
            abilitiesOnCooldown.UpdateCooldowns();
            ActionCD();
        }
    }
}