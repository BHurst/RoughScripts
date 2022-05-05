using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class NPCUnit : RootUnit
{
    public int level = 1;
    public int xpReward = 200;
    public NavMeshAgent nav;
    public Patrol pat;
    public List<EnemyAbility> knownAbilities = new List<EnemyAbility>();
    public EnemyAbility currentAbility;
    public RootUnit currentTarget;
    [HideInInspector]
    public LootTable lootTable;
    public Vector3 currentTargetPoint;

    void Start()
    {
        NPCUnitStart();
    }

    public void NPCUnitStart()
    {
        if (unitID == null)
            CreateInitial();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        lootTable = GetComponent<LootTable>();

        RefreshStats();
        pat = GetComponent<Patrol>();
        nav.speed = 5;
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
        if (nav.speed < totalStats.MoveSpeed.value && nav.speed != 0)
            state.Slowed = true;

        if (state.Rooted == false)
        {
            nav.speed = totalStats.MoveSpeed.value * totalStats.MoveSpeed_Movement_AddPercent.value;
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
        List<WorldItem> theDrop = lootTable.CreateDrop();
        if (theDrop != null && theDrop.Count > 0)
        {
            foreach (var item in theDrop)
            {
                GameObject itemBeingCreated = Instantiate(Resources.Load("BlankItem")) as GameObject;
                WorldItem wI = itemBeingCreated.GetComponent<WorldItem>();

                wI.inventoryItem = item.inventoryItem.Clone();
                wI.transform.position = new Vector3(UnityEngine.Random.Range(-.25f, .25f) + transform.position.x, .25f + transform.position.y, UnityEngine.Random.Range(-.25f, .25f) + transform.position.z);
                wI.transform.LookAt(transform);
                wI.transform.Rotate(0, 180, 0);
                wI.GetComponent<Rigidbody>().velocity = itemBeingCreated.transform.forward * UnityEngine.Random.Range(4f, 7f);
                wI.transform.rotation = UnityEngine.Random.rotation;
                wI.transform.SetParent(GameObject.Find("Items").transform);
                wI.gameObject.SetActive(true);
            }
        }
    }

    public void LifeCheck()
    {
        if (totalStats.Health_Current.value < 0)
            totalStats.Health_Current.value = 0;
        else if (totalStats.Health_Current.value > totalStats.Health_Max.value)
            totalStats.Health_Current.value = totalStats.Health_Max.value;

        if (isAlive == true)
        {
            if (totalStats.Health_Current.value <= 0)
            {
                NPCKill();
                DropLoot();
                GameWorldReferenceClass.GW_Player.level.CalculateRewardExperience(level, xpReward);
            }
        }
    }

    public void MeleeMovement()
    {

    }

    public void FindTarget()
    {
        currentTarget = GameWorldReferenceClass.GetInAreaPlayer(20, transform.position);
    }

    public void ChaseTarget()
    {
        if (knownAbilities.Count > 0 && currentTarget != null && currentAbility == null && Vector3.Distance(transform.position, currentTarget.transform.position) < 15)
        {
            if (UtilityService.LineOfSightCheckRootUnit(transform.position + eyesOffset, currentTarget) != new Vector3())
            {
                currentTargetPoint = currentTarget.transform.position;
                currentAbility = knownAbilities[0];
            }
            else
            {
                currentAbility = null;
                currentCastingTime = 0;
            }
        }
    }

    public override void CastingTimeCheck()
    {
        if (currentAbility != null)
        {
            currentCastingTime += Time.deltaTime;
            if (currentCastingTime > currentAbility.enemyAbilityStats.castTime)
            {
                var newA = currentAbility.CreateWorldAbility(unitID);
                newA.gameObject.layer = 11;
                if (newA.enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Projectile)
                {
                    newA.transform.position = transform.position;
                    Vector3 leadPosition = UtilityService.FirstOrderIntercept(transform.position, new Vector3(), newA.enemyAbilityStats.speed, currentTarget.transform.position, currentTarget.GetComponent<Rigidbody>().velocity);
                    newA.transform.LookAt(leadPosition + new Vector3(0, currentTarget.GetComponent<CapsuleCollider>().height / 2, 0));
                }
                else if (newA.enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Area_Hit)
                {
                    newA.transform.position = currentTargetPoint;
                }
                currentCastingTime = 0;
                currentAbility = null;
                return;
            }
        }
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
        

        LifeCheck();
        if (isAlive == true)
        {
            if (currentTarget == null)
                FindTarget();
            ChaseTarget();
            MeleeMovement();
            CastingTimeCheck();
            ResolveValueStatuses();
            if (state.Stunned == false)
            {

            }
        }
    }
}