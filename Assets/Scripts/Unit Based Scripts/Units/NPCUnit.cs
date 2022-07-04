using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class NPCUnit : RootCharacter
{
    public int level = 1;
    public int xpReward = 200;
    public NavMeshAgent nav;
    public Patrol pat;
    [HideInInspector]
    public LootManager lootManager;
    public Vector3 currentTargetPoint;

    void Start()
    {
        BasicStart();
        NPCUnitStart();
    }

    public void NPCUnitStart()
    {
        lootManager = GetComponent<LootManager>();
        pat = GetComponent<Patrol>();
        nav = GetComponent<NavMeshAgent>();
        entityType = EntityType.Character;
        unitEquipment.character = this;
        lootManager.dropTables.Add(new L1_BasicEnemy_Drop());
        GetSpeech();
        unitID = Guid.NewGuid();
        charInventory.owner = unitID;
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        primarySpellCastLocation = transform;
        LearnAbilities();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        nav.speed = 5;
    }

    public void LearnAbilities()
    {
        knownAbilities = new List<RootAbility>();

        knownAbilities.Add(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Character,
            abilityName = "Fire Orb",
            formRune = new FormRune_Orb(),
            schoolRune = new SchoolRune_Fire(),
            castModeRune = new CastModeRune_CastTime(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            predictProjectileLocation = true,
            harmful = true,
            initialized = true
        });
    }

    public void GetSpeech()
    {
        speech = ConversationFactory.GetSpeech("Goodie", 1);
    }

    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void EnableRigidForce()
    {
        var force = nav.velocity;
        nav.enabled = false;
        GetComponent<Rigidbody>().drag = .1f;
        GetComponent<Rigidbody>().angularDrag = .05f;
        GetComponent<Rigidbody>().AddForce(force + transform.forward, ForceMode.Impulse);
        //Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.Find("Terrain").GetComponent<Collider>(), false);
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

    public void DropLoot()
    {
        List<InventoryItem> theDrop = lootManager.CreateDrop();
        if (theDrop != null && theDrop.Count > 0)
        {
            foreach (var item in theDrop)
            {
                GameObject itemBeingCreated = Instantiate(Resources.Load("BlankItem")) as GameObject;
                WorldItem wI = itemBeingCreated.GetComponent<WorldItem>();

                wI.inventoryItem = item.Clone();
                wI.transform.position = new Vector3(UnityEngine.Random.Range(-.25f, .25f) + transform.position.x, .25f + transform.position.y, UnityEngine.Random.Range(-.25f, .25f) + transform.position.z);
                wI.transform.LookAt(transform);
                wI.transform.Rotate(0, 180, 0);
                wI.GetComponent<Rigidbody>().velocity = itemBeingCreated.transform.forward * UnityEngine.Random.Range(4f, 7f);
                wI.transform.rotation = UnityEngine.Random.rotation;
                wI.transform.SetParent(GameObject.Find("Items").transform);
                wI.gameObject.SetActive(true);
                wI.GetComponent<Renderer>().material.SetColor("_Color", wI.inventoryItem.GetRarityColor());
            }
        }
    }

    public override void LifeCheck()
    {
        if (totalStats.Health_Current < 0)
            totalStats.Health_Current = 0;
        else if (totalStats.Health_Current > totalStats.Health_Max)
            totalStats.Health_Current = totalStats.Health_Max;

        if (isAlive == true)
        {
            if (totalStats.Health_Current <= 0)
            {
                NPCKill();
                DropLoot();
                PlayerCharacterUnit.player.level.CalculateRewardExperience(level, xpReward);
            }
        }
    }

    public void FindTarget()
    {
        currentTarget = GameWorldReferenceClass.GetInAreaPlayer(20, transform.position);
    }

    public void ChaseTarget()
    {
        if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.transform.position) < 15)
        {
            if (UtilityService.LineOfSightCheckRootUnit(transform.position + eyesOffset, currentTarget) != new Vector3())
            {
                if (RootAbility.NullorUninitialized(abilityPreparingToCast))
                {
                    abilityPreparingToCast = knownAbilities[0];
                }
                currentTargetPoint = currentTarget.transform.position;
            }
            else
            {
                abilityPreparingToCast = null;
                currentCastingTime = 0;
            }
        }
    }

    void Update()
    {
        StandardUnitTick();

        if (isAlive == true)
        {
            if (hostility == Hostility.Hostile)
            {
                if (currentTarget == null)
                    FindTarget();
                ChaseTarget();
            }
            if (!RootAbility.NullorUninitialized(abilityPreparingToCast))
                ActiveAbilityCheck();
        }
    }
}