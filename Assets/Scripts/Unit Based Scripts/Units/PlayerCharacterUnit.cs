using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootCharacter
{
    public static PlayerCharacterUnit player;
    public CastBar castBar;
    public List<GameObject> buffIcons = new List<GameObject>();
    public List<Rune> knownRunes = new List<Rune>();
    public ConsumableInventoryItem quickItem;
    public CharacterLevel level = new CharacterLevel();
    public PlayerHotbarAbilities playerHotbar = new PlayerHotbarAbilities();
    public PlayerFloatingDamageTaken PlayerFloatingDamageTaken;
    public RootAbility bufferedAbility;
    public List<LocusRuneItem> availableLocusRuneItems = new List<LocusRuneItem>();
    public PlayerResources playerResources = new PlayerResources();

    public event EventHandler<Status> StatusGained;
    public event EventHandler<Status> StatusLost;

    private void Awake()
    {
        player = this;
    }

    private void Start()
    {
        unitBody = GetComponent<Rigidbody>();
        PlayerUnitStart();
    }

    public void PlayerUnitStart()
    {
        CreateInitial();
        LearnAbilities();
        GameWorldReferenceClass.LearnAllRunes();
        var thing1 = ItemFactory.CreateEquipment("BasicHelm", EquipmentSlot.SlotType.Head);
        thing1.mods.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, Value = 2 });
        charInventory.AddItem(thing1);
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        var watch = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 25; i++)
        {
            charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        }
        watch.Stop();
        Debug.Log(watch.ElapsedMilliseconds + " to create 25 equipment items in the players inventory");
    }

    public void LearnAbilities()
    {
        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Fire Orb",
            formRune = new FormRune_Orb(),
            schoolRune = new SchoolRune_Fire(),
            castModeRune = new CastModeRune_Charge(),
            effectRunes = new List<EffectRune>() { new EffectRune_Split() { rank = 1, triggerTag = Rune.TriggerTag.OnHit } },
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            initialized = true
        }, 0);

        playerHotbar.PlaceSlot(new LightningLob_Data(unitID, entityType), 1);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Self Cast",
            formRune = new FormRune_SelfCast(),
            schoolRune = new SchoolRune_Ethereal(),
            castModeRune = new CastModeRune_Reserve(),
            effectRunes = new List<EffectRune>() { new EffectRune_Dash() { rank = 10, triggerTag = Rune.TriggerTag.OnCast, targetSelf = true } },
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            selfHarm = true,
            initialized = true
        }, 2);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Nova",
            formRune = new FormRune_Nova(),
            schoolRune = new SchoolRune_Astral(),
            castModeRune = new CastModeRune_Reserve(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            abilityToTrigger = new BasicAbility()
            {
                abilityID = Guid.NewGuid(),
                abilityOwner = unitID,
                ownerEntityType = EntityType.Player,
                abilityName = "Strike",
                formRune = new FormRune_Strike(),
                schoolRune = new SchoolRune_Air(),
                castModeRune = new CastModeRune_Trigger(),
                snapshot = new CalculatedAbilityStats(),
                abilityStateManager = new AbilityStateManager(),
                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        }, 3);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Command",
            formRune = new FormRune_Command(),
            schoolRune = new SchoolRune_Arcane(),
            castModeRune = new CastModeRune_Reserve(),
            effectRunes = new List<EffectRune>() { new EffectRune_Debuff() { rank = 10, triggerTag = Rune.TriggerTag.OnHit } },
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            abilityToTrigger = new BasicAbility()
            {
                abilityID = Guid.NewGuid(),
                abilityOwner = unitID,
                ownerEntityType = EntityType.Player,
                abilityName = "Strike",
                formRune = new FormRune_Strike(),
                schoolRune = new SchoolRune_Air(),
                castModeRune = new CastModeRune_Trigger(),
                snapshot = new CalculatedAbilityStats(),
                abilityStateManager = new AbilityStateManager(),
                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        }, 4);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Ice Orb",
            formRune = new FormRune_Orb(),
            schoolRune = new SchoolRune_Ice(),
            castModeRune = new CastModeRune_CastTime(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            initialized = true
        }, 5);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Arc",
            formRune = new FormRune_Arc(),
            schoolRune = new SchoolRune_Electricity(),
            castModeRune = new CastModeRune_CastTime(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            abilityToTrigger = new BasicAbility()
            {
                abilityID = Guid.NewGuid(),
                abilityOwner = unitID,
                ownerEntityType = EntityType.Player,
                abilityName = "Zone",
                formRune = new FormRune_Zone(),
                schoolRune = new SchoolRune_Ethereal(),
                castModeRune = new CastModeRune_Trigger(),
                snapshot = new CalculatedAbilityStats(),
                abilityStateManager = new AbilityStateManager(),
                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        }, 6);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Weapon",
            formRune = new FormRune_Orb(),
            schoolRune = new SchoolRune_Kinetic(),
            castModeRune = new CastModeRune_Channel(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            initialized = true
        }, 7);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Burst",
            formRune = new FormRune_Burst(),
            schoolRune = new SchoolRune_Arcane(),
            castModeRune = new CastModeRune_CastTime(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            initialized = true
        }, 8);

        playerHotbar.PlaceSlot(new BasicAbility()
        {
            abilityID = Guid.NewGuid(),
            abilityOwner = unitID,
            ownerEntityType = EntityType.Player,
            abilityName = "Zone",
            formRune = new FormRune_Zone(),
            schoolRune = new SchoolRune_Ethereal(),
            castModeRune = new CastModeRune_CastTime(),
            snapshot = new CalculatedAbilityStats(),
            abilityStateManager = new AbilityStateManager(),
            harmful = true,
            initialized = true
        }, 9);
    }

    void CreateInitial()
    {
        entityType = EntityType.Player;
        unitEquipment.character = this;
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        InventoryItem item = new Consumable_Item_NightShale();
        charInventory.AddItem(item);
        SetQuickItem(0);
        RefreshStats();
    }

    public void SetQuickItem(int index)
    {
        quickItem = (ConsumableInventoryItem)charInventory.Inventory[index];
        GameWorldReferenceClass.GW_CharacterPanel.quickItemSlot.SetQuickItem((ConsumableInventoryItem)charInventory.Inventory[0]);
    }

    public override void ResolveHit(float value, bool overTime)
    {
        totalStats.ModifyHealth(-value);
        PlayerFloatingDamageTaken.AddHit(-value);
    }

    public override void ResolveHeal(float value, bool overTime)
    {
        totalStats.ModifyHealth(value);
        PlayerFloatingDamageTaken.AddHit(value);
    }

    public override void AddStatus(Status status)
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
            return;
        }

        activeStatuses.Add(status);
        StatusGained?.Invoke(this, status);
        status.currentDuration = status.maxDuration;
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.IncreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public override void RemoveStatus(Status status)
    {
        activeStatuses.Remove(status);
        StatusLost?.Invoke(this, status);
        foreach (ModifierGroup modifierGroup in status.modifierGroups)
        {
            totalStats.DecreaseStat(modifierGroup.Stat, modifierGroup.Aspect, modifierGroup.Method, modifierGroup.Value);
        }
    }

    public void ManualReserve()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        castBar.CastUpdate(currentCastingTime / totalStats.baseReserveRecoveryTime, (totalStats.baseReserveRecoveryTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), false);
        if (currentCastingTime > totalStats.baseReserveRecoveryTime)
        {
            //animator.SetTrigger(abilityCharging.aFormRune.formAnimation);

            totalStats.RecoverReserve(abilityPreparingToCast.schoolRune.schoolRuneType);
            currentCastingTime = 0;
            if (totalStats.IsReserveFull(abilityPreparingToCast.schoolRune.schoolRuneType))
            {
                abilityPreparingToCast = null;
                currentCastingTime = 0;
                actionState = ActionState.Idle;
            }
        }
    }

    public void ChargeCast()
    {
        actionState = ActionState.Casting;
        animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
        abilityBeingCast = abilityPreparingToCast;
        ((CastModeRune_Charge)abilityBeingCast.castModeRune).chargeAmount = currentCastingTime / (abilityBeingCast.schoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value));
        FinishPreparingToCast(false);
    }

    public bool StartCasting(RootAbility ability)
    {
        if (actionState == ActionState.Channeling)
        {
            if (abilityPreparingToCast.abilityID.Equals(ability.abilityID))
            {
                abilityPreparingToCast = null;
                currentCastingTime = 0;
                actionState = ActionState.Idle;
                return false;
            }
            else
            {
                abilityPreparingToCast = null;
                currentCastingTime = 0;
                actionState = ActionState.Idle;
            }
        }
        if (actionState == ActionState.Reserving)
        {
            abilityPreparingToCast = null;
            currentCastingTime = 0;
            actionState = ActionState.Idle;
        }
        //Can I afford it?
        if (ability.GetCost() > totalStats.Mana_Current)
        {
            ErrorScript.DisplayError("Not Enough Mana");
            return false;
        }
        else if (ability.GetCost() > totalStats.Health_Current)
        {
            ErrorScript.DisplayError("Not Enough Health");
            return false;
        }
        else if (ability.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve && totalStats.CheckReserves(ability.schoolRune.schoolRuneType) < 1)
        {
            abilityPreparingToCast = ability;
            actionState = ActionState.Reserving;
            return true;
        }
        //Is it available?
        else if (actionState == ActionState.Idle && globalCooldown == 0 && (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null))
        {
            globalCooldown = 1;
            actionState = ActionState.PreparingAbility;
            abilityPreparingToCast = ability;
            bufferedAbility = null;

            if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            {
                animator.SetTrigger(ability.GetPrepareAnimation());
            }
            else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
            {
                animator.SetTrigger(ability.GetPrepareAnimation());
            }
            else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                animator.SetTrigger(ability.GetPrepareAnimation());
            }
            else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
            {
                animator.SetTrigger(ability.GetPrepareAnimation());
            }

            return true;
        }
        //Will the cooldown/cast time runout before it would be cast?
        else if (globalCooldown <= GameWorldReferenceClass.inputBuffer)
        {
            if (actionState == ActionState.Idle || actionState == ActionState.Casting || (!RootAbility.NullorUninitialized(abilityPreparingToCast) && abilityPreparingToCast.castModeRune.baseCastTime - currentCastingTime <= GameWorldReferenceClass.inputBuffer))
            {
                //Is it not on cooldown, or it is but its less than the global cooldown/input buffer
                RootAbility foundCD = abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID);
                if (foundCD == null || (foundCD != null && foundCD.cooldown <= globalCooldown) || (foundCD != null && foundCD.cooldown <= GameWorldReferenceClass.inputBuffer))
                {
                    bufferedAbility = ability;
                    return true;
                }
            }

        }
        //Am I busy?
        else if (currentCastingTime > 0)
        {
            ErrorScript.DisplayError("Busy Casting");
            return false;
        }
        return false;
    }

    public override void ActiveAbilityCheck()
    {
        if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Attack)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
        {
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            castBar.CastUpdate(currentCastingTime / abilityPreparingToCast.schoolRune.baseCastTime, (abilityPreparingToCast.schoolRune.baseCastTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), false);
            if (currentCastingTime > abilityPreparingToCast.schoolRune.baseCastTime)
            {
                animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
                actionState = ActionState.Casting;
                abilityBeingCast = abilityPreparingToCast;
                FinishPreparingToCast(false);
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
            castBar.CastUpdate(currentCastingTime / (abilityPreparingToCast.schoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value)), ((abilityPreparingToCast.schoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value)) / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), true);
        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
        {

        }
        else if (abilityPreparingToCast.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            actionState = ActionState.Casting;
            animator.SetTrigger(abilityPreparingToCast.GetCastAnimation());
            abilityBeingCast = abilityPreparingToCast;
            FinishPreparingToCast(false);
        }
    }

    public override void Cast()
    {
        var cmType = abilityBeingCast.castModeRune.castModeRuneType;
        totalStats.Mana_Current -= abilityBeingCast.GetCost() / (1 + totalStats.Mana_Cost_AddPercent.value) / totalStats.Mana_Cost_MultiplyPercent.value;
        abilityBeingCast.cooldown = abilityBeingCast.schoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);

        RootAbilityForm worldAbility = null;

        if (abilityBeingCast is BasicAbility)
            worldAbility = AbilityFactory.InstantiateBasicWorldAbility((BasicAbility)abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, RootAbility.CreationMethod.UnitCast, null).GetComponent<BasicAbilityForm>();
        else if (abilityBeingCast is UniqueAbility)
            worldAbility = AbilityFactory.InstantiateUniqueWorldAbility((UniqueAbility)abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, RootAbility.CreationMethod.UnitCast, null).GetComponent<UniqueAbilityForm>();
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

            FinishPreparingToCast(false);
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

    public void PlayerKill()
    {
        Kill();
    }

    public override void StopCast()
    {
        actionState = ActionState.Idle;
        currentCastingTime = 0;
        totalStats.Channel_Current = totalStats.Channel_Default;
        abilityPreparingToCast = null;
        abilityBeingCast = null;
        abilityPreparingToCast = null;
        bufferedAbility = null;
    }

    public void FinishPreparingToCast(bool continueShowingCastBar)
    {
        currentCastingTime = 0;
        castBar.CastUpdate(0, 0, continueShowingCastBar);
        abilityPreparingToCast = null;
    }

    public void RefreshStats()
    {
        totalStats.InitializeStats();
    }

    public override void RegenTick()
    {
        if (state.Decaying == false)
            if (totalStats.Health_Current < totalStats.Health_Max)
                totalStats.Health_Current = Mathf.Clamp((totalStats.Health_Current + totalStats.Health_Regeneration * Time.deltaTime), 0, totalStats.Health_Max);
        if (totalStats.Mana_Current < totalStats.Mana_Max)
            totalStats.Mana_Current = Mathf.Clamp((totalStats.Mana_Current + totalStats.Mana_Regeneration * Time.deltaTime), 0, totalStats.Mana_Max);
    }

    private void Update()
    {
        StandardUnitTick();

        if (isAlive == true)
        {
            if (actionState == ActionState.Reserving)
            {
                ManualReserve();
            }
            else if (actionState == ActionState.PreparingAbility || actionState == ActionState.Channeling)
            {
                ActiveAbilityCheck();
            }
            else if (actionState != ActionState.Casting)
            {
                actionState = ActionState.Idle;
            }

            if (!RootAbility.NullorUninitialized(bufferedAbility) && (abilityBeingCast == null || abilityBeingCast.initialized == false) && globalCooldown == 0)
            {
                StartCasting(bufferedAbility);
            }
        }
        else
            GameWorldReferenceClass.Respawn();
    }
}