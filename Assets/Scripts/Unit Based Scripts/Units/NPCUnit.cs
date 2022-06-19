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
    public RootCharacter currentTarget;
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
        CreateInitial();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        nav.speed = 5;
    }

    void CreateInitial()
    {
        entityType = EntityType.Character;
        unitEquipment.character = this;
        lootManager.dropTables.Add(new L1_BasicEnemy_Drop());
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        primarySpellCastLocation = transform;
        LearnAbilities();
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

    public void NavigationManagement()
    {
        //if (nav.speed < totalStats.MovementSpeed && nav.speed != 0)
        //    state.Slowed = true;

        //if (state.Rooted == false)
        //{
        nav.speed = totalStats.MovementSpeed;
        //}
        //else
        //{
        //    nav.speed = 0;
        //}
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

    public void MeleeMovement()
    {

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

    public override void ActiveAbilityCheck()
    {
        if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Attack)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
        {
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            if (currentCastingTime > abilityPreparingToCast.schoolRune.baseCastTime)
            {
                abilityBeingCast = abilityPreparingToCast;
                Cast();
                currentCastingTime = 0;
                abilityPreparingToCast = null;
                abilityBeingCast = null;
            }
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
        {
            actionState = ActionState.Channeling;
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            totalStats.Channel_Current = Mathf.Clamp(totalStats.Channel_Current + (totalStats.Channel_Rate * Time.deltaTime), totalStats.Channel_Default, totalStats.Channel_Max);
            if (currentCastingTime > .25f)
            {
                if (totalStats.Mana_Current - abilityPreparingToCast.GetCost() < 0)
                {
                    abilityPreparingToCast = null;
                    currentCastingTime = 0;
                    totalStats.Channel_Current = totalStats.Channel_Default;
                    actionState = ActionState.Idle;
                    return;
                }
                abilityBeingCast = abilityPreparingToCast;
                Cast();

                totalStats.Mana_Current -= abilityPreparingToCast.GetCost();
                currentCastingTime -= .25f;
            }
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
        {
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            currentCastingTime = Mathf.Clamp(currentCastingTime, 0, abilityPreparingToCast.schoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value));
            if(currentCastingTime >= abilityPreparingToCast.schoolRune.baseCastTime)
            {
                actionState = ActionState.Casting;
                abilityBeingCast = abilityPreparingToCast;
                Cast();
            }
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            actionState = ActionState.Casting;
            abilityBeingCast = abilityPreparingToCast;
            Cast();
            currentCastingTime = 0;
            abilityPreparingToCast = null;
        }
    }

    public override void Cast()
    {
        var cmType = abilityBeingCast.castModeRune.castModeRuneType;
        totalStats.Mana_Current -= abilityBeingCast.GetCost() / (1 + totalStats.Mana_Cost_AddPercent.value) / totalStats.Mana_Cost_MultiplyPercent.value;
        abilityBeingCast.cooldown = abilityBeingCast.schoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);

        BasicAbilityForm worldAbility = AbilityFactory.InstantiateBasicWorldAbility((BasicAbility)abilityBeingCast, primarySpellCastLocation.position + new Vector3(0, 1), unitID, entityType, RootAbility.CreationMethod.UnitCast, null).GetComponent<BasicAbilityForm>();
        worldAbility.targetPreference = currentTarget.transform;
        GlobalEventManager.AbilityCastTrigger(this, worldAbility, this, transform.position);
        if (worldAbility.ability.effectRunes != null)
        {
            foreach (var rune in worldAbility.ability.effectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                {
                    if (rune.targetSelf)
                        rune.Effect(this, this, worldAbility);
                }
            }
        }

        abilityBeingCast.abilityStateManager.ApplyStateOnCast(this);

        if (cmType == Rune.CastModeRuneTag.Attack)
        {
            actionState = ActionState.Attacking;
        }
        else if (cmType == Rune.CastModeRuneTag.CastTime)
        {
            actionState = ActionState.Idle;

            if (abilityBeingCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
                totalStats.ExpendCharge(abilityBeingCast.schoolRune.schoolRuneType);

            currentCastingTime = 0;
            abilityPreparingToCast = null;
            abilityBeingCast = null;
        }
        else if (cmType == Rune.CastModeRuneTag.Channel)
        {
            abilityBeingCast = null;
        }
        else if (cmType == Rune.CastModeRuneTag.Charge)
        {
            actionState = ActionState.Idle;
        }
        else if (cmType == Rune.CastModeRuneTag.Instant)
        {
            actionState = ActionState.Idle;
        }
        else if (cmType == Rune.CastModeRuneTag.Reserve)
        {
            actionState = ActionState.Idle;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.GetComponent<RootUnit>() != null)
    //        ResolveSizeCollision(this, collision.collider.GetComponent<RootUnit>());
    //}

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
                MeleeMovement();
            }
            if (!RootAbility.NullorUninitialized(abilityPreparingToCast))
                ActiveAbilityCheck();
        }
    }
}