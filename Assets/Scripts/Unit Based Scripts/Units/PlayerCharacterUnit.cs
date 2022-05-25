using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootCharacter
{
    public CastBar castBar;
    public List<GameObject> buffIcons = new List<GameObject>();
    public LocusRune cTalents = new LocusRune();
    public List<Rune> knownRunes = new List<Rune>();
    public ConsumableInventoryItem quickItem;
    public CharacterLevel level = new CharacterLevel();
    public PlayerHotbarAbilities playerHotbar = new PlayerHotbarAbilities();
    public PlayerFloatingDamageTaken PlayerFloatingDamageTaken;
    public Ability bufferedAbility;

    public event EventHandler<Status> StatusGained;
    public event EventHandler<Status> StatusLost;

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
        thing1.locusRune.PlaceSimpleRune(new SimpleTalent() { modifiers = new List<ModifierGroup> { new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, Value = 2 } } });
        thing1.locusRune.PlaceComplexRune(new CT_ExplosiveFireOrb(), this);
        thing1.locusRune.PlaceComplexRune(new CT_HotColdSwap(), this);
        charInventory.AddItem(thing1);
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
        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Fire Orb",
            aFormRune = new FormRune_Orb(),
            aSchoolRune = new SchoolRune_Fire(),
            aCastModeRune = new CastModeRune_Charge(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Split() { rank = 1, triggerTag = Rune.TriggerTag.OnHit } },

            harmful = true,
            initialized = true
        }, 0);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Strike",
            aFormRune = new FormRune_Strike(),
            aSchoolRune = new SchoolRune_Air(),
            aCastModeRune = new CastModeRune_CastTime(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Buff() { rank = 10, triggerTag = Rune.TriggerTag.OnCast, stat = ModifierGroup.EStat.Cast, aspect = ModifierGroup.EAspect.Rate, method = ModifierGroup.EMethod.AddPercent, targetSelf = true } },

            harmful = true,
            initialized = true
        }, 1);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Self Cast",
            aFormRune = new FormRune_SelfCast(),
            aSchoolRune = new SchoolRune_Ethereal(),
            aCastModeRune = new CastModeRune_Reserve(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Dash() { rank = 10, triggerTag = Rune.TriggerTag.OnCast, targetSelf = true } },

            harmful = true,
            selfHarm = true,
            initialized = true
        }, 2);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Nova",
            aFormRune = new FormRune_Nova(),
            aSchoolRune = new SchoolRune_Astral(),
            aCastModeRune = new CastModeRune_Reserve(),
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune_Strike(),
                aSchoolRune = new SchoolRune_Air(),
                aCastModeRune = new CastModeRune_Trigger(),

                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        }, 3);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Command",
            aFormRune = new FormRune_Command(),
            aSchoolRune = new SchoolRune_Arcane(),
            aCastModeRune = new CastModeRune_Reserve(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Debuff() { rank = 10, triggerTag = Rune.TriggerTag.OnHit } },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune_Strike(),
                aSchoolRune = new SchoolRune_Air(),
                aCastModeRune = new CastModeRune_Trigger(),

                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        }, 4);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Ice Orb",
            aFormRune = new FormRune_Orb(),
            aSchoolRune = new SchoolRune_Ice(),
            aCastModeRune = new CastModeRune_CastTime(),

            harmful = true,
            initialized = true
        }, 5);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Arc",
            aFormRune = new FormRune_Arc(),
            aSchoolRune = new SchoolRune_Electricity(),
            aCastModeRune = new CastModeRune_CastTime(),
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Zone",
                aFormRune = new FormRune_Zone(),
                aSchoolRune = new SchoolRune_Ethereal(),
                aCastModeRune = new CastModeRune_Trigger(),
                harmful = true,
            },

            harmful = true,
            initialized = true
        }, 6);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Weapon",
            aFormRune = new FormRune_Weapon(),
            aSchoolRune = new SchoolRune_Kinetic(),
            aCastModeRune = new CastModeRune_Reserve(),

            harmful = true,
            initialized = true
        }, 7);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Burst",
            aFormRune = new FormRune_Burst(),
            aSchoolRune = new SchoolRune_Arcane(),
            aCastModeRune = new CastModeRune_CastTime(),

            harmful = true,
            initialized = true
        }, 8);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Zone",
            aFormRune = new FormRune_Zone(),
            aSchoolRune = new SchoolRune_Ethereal(),
            aCastModeRune = new CastModeRune_CastTime(),

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
        PlayerFloatingDamageTaken.AddHit(-value);
    }

    public override void ResolveHeal(float value, bool overTime)
    {
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

    public void ReservingCheck()
    {
        animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
        abilityBeingCast = abilityPreparingToCast;
        FinishPreparingToCast(false);
    }

    public void ManualReserve()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        castBar.CastUpdate(currentCastingTime / totalStats.baseReserveRecoveryTime, (totalStats.baseReserveRecoveryTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), false);
        if (currentCastingTime > totalStats.baseReserveRecoveryTime)
        {
            //animator.SetTrigger(abilityCharging.aFormRune.formAnimation);

            totalStats.RecoverReserve(abilityBeingReserved.aSchoolRune.schoolRuneType);
            currentCastingTime = 0;
            if (totalStats.IsReserveFull(abilityBeingReserved.aSchoolRune.schoolRuneType))
            {
                abilityBeingReserved = null;
                currentCastingTime = 0;
            }
        }
    }

    public void ChargingCheck()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        currentCastingTime = Mathf.Clamp(currentCastingTime, 0, abilityPreparingToCast.aSchoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value));
        castBar.CastUpdate(currentCastingTime / (abilityPreparingToCast.aSchoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value)), ((abilityPreparingToCast.aSchoolRune.baseCastTime * (1 +totalStats.Charge_Max_AddPercent.value)) / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), true);
    }

    public void ChargeCast()
    {
        animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
        abilityBeingCast = abilityPreparingToCast;
        ((CastModeRune_Charge)abilityBeingCast.aCastModeRune).chargeAmount = currentCastingTime / (abilityBeingCast.aSchoolRune.baseCastTime * (1 + totalStats.Charge_Max_AddPercent.value));
        FinishPreparingToCast(false);
    }

    public void CastTimeCheck()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        castBar.CastUpdate(currentCastingTime / abilityPreparingToCast.aSchoolRune.baseCastTime, (abilityPreparingToCast.aSchoolRune.baseCastTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value), false);
        if (currentCastingTime > abilityPreparingToCast.aSchoolRune.baseCastTime)
        {
            animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
            abilityBeingCast = abilityPreparingToCast;
            FinishPreparingToCast(false);
        }
    }

    public void ChannelCheck()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        totalStats.Channel_Current = Mathf.Clamp(totalStats.Channel_Current + (totalStats.Channel_Rate * Time.deltaTime), totalStats.Channel_Default, totalStats.Channel_Max);
        if (currentCastingTime > .25f)
        {
            WorldAbility worldAbility = AbilityFactory.InstantiateWorldAbility(abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, WorldAbility.CreationMethod.UnitCast).GetComponent<WorldAbility>();
            GlobalEventManager.AbilityCastTrigger(this, worldAbility, this, transform.position);
            if (worldAbility.wEffectRunes != null)
            {
                foreach (var rune in worldAbility.wEffectRunes)
                {
                    if (rune.triggerTag == Rune.TriggerTag.OnCast)
                    {
                        if (rune.targetSelf)
                            rune.Effect(this, this, worldAbility);
                    }
                }
            }

            totalStats.Mana_Current -= abilityBeingCast.GetCost();
            currentCastingTime -= .25f;
        }
    }

    public bool StartCasting(Ability ability)
    {
        if (!Ability.NullorUninitialized(abilityBeingCast))
        {
            if (abilityBeingCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
            {
                if (abilityBeingCast.abilityID.Equals(ability.abilityID))
                {
                    abilityBeingCast = null;
                    currentCastingTime = 0;
                    actionState = ActionState.Idle;
                    return false;
                }
                else
                {
                    abilityBeingCast = null;
                    currentCastingTime = 0;
                    actionState = ActionState.Idle;
                }
            }
        }
        if (!Ability.NullorUninitialized(abilityBeingReserved))
        {
            abilityBeingReserved = null;
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
        else if (ability.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve && totalStats.CheckReserves(ability.aSchoolRune.schoolRuneType) < 1)
        {
            abilityBeingReserved = ability;
            return true;
        }
        //Is it available?
        else if (actionState == ActionState.Idle && globalCooldown == 0 && (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null))
        {
            globalCooldown = 1;
            actionState = ActionState.Casting;
            abilityPreparingToCast = ability;
            bufferedAbility = null;
            return true;
        }
        //Will the cooldown/cast time runout before it would be cast?
        else if (globalCooldown <= GameWorldReferenceClass.inputBuffer)
        {
            if ((!Ability.NullorUninitialized(abilityPreparingToCast) && abilityPreparingToCast.aCastModeRune.baseCastTime - currentCastingTime <= GameWorldReferenceClass.inputBuffer) || (abilityPreparingToCast == null))
            {
                //Is it not on cooldown, or it is but its less than the global cooldown/input buffer
                Ability foundCD = abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID);
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
        if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            ReservingCheck();
        }
        else if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Channel)
        {
            //animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
            actionState = ActionState.Channeling;
            totalStats.Channel_Current = totalStats.Channel_Default;
            abilityBeingCast = abilityPreparingToCast;
            FinishPreparingToCast(false);
            return;
        }
        else if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
        {
            CastTimeCheck();
        }
        else if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charge)
        {
            ChargingCheck();
        }
    }

    public override void Cast()
    {
        actionState = ActionState.Idle;
        WorldAbility worldAbility = AbilityFactory.InstantiateWorldAbility(abilityBeingCast, primarySpellCastLocation.position, unitID, entityType, WorldAbility.CreationMethod.UnitCast).GetComponent<WorldAbility>();
        GlobalEventManager.AbilityCastTrigger(this, worldAbility, this, transform.position);
        if (worldAbility.wEffectRunes != null)
        {
            foreach (var rune in worldAbility.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                {
                    if (rune.targetSelf)
                        rune.Effect(this, this, worldAbility);
                }
            }
        }

        if (abilityBeingCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            totalStats.ExpendCharge(abilityBeingCast.aSchoolRune.schoolRuneType);

        totalStats.Mana_Current -= abilityBeingCast.GetCost();
        abilityBeingCast.cooldown = abilityBeingCast.aSchoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);
        FinishPreparingToCast(false);
        abilityBeingCast = null;
    }

    public void PlayerKill()
    {
        Kill();
    }

    public void LifeCheck()
    {
        if (totalStats.Health_Current < 0)
            totalStats.Health_Current = 0;
        else if (totalStats.Health_Current > totalStats.Health_Max)
            totalStats.Health_Current = totalStats.Health_Max;

        if (totalStats.Health_Current <= 0)
        {
            Kill();
        }
    }

    public override void StopCast()
    {
        actionState = ActionState.Idle;
        currentCastingTime = 0;
        totalStats.Channel_Current = 0;
        abilityPreparingToCast = null;
        abilityBeingCast = null;
        abilityBeingReserved = null;
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

    public void RegenTick()
    {
        if (totalStats.Health_Current < totalStats.Health_Max)
            totalStats.Health_Current = Mathf.Clamp((totalStats.Health_Current + totalStats.Health_Regeneration * Time.deltaTime), 0, totalStats.Health_Max);
        if (totalStats.Mana_Current < totalStats.Mana_Max)
            totalStats.Mana_Current = Mathf.Clamp((totalStats.Mana_Current + totalStats.Mana_Regeneration * Time.deltaTime), 0, totalStats.Mana_Max);
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        IncrementTimers();
        LifeCheck();
        if (isAlive == true)
        {
            ResolveValueStatuses();
            RegenTick();

            if (!Ability.NullorUninitialized(abilityBeingReserved))
            {
                ManualReserve();
            }
            else if (!Ability.NullorUninitialized(abilityPreparingToCast))
            {
                ActiveAbilityCheck();
            }

            if (!Ability.NullorUninitialized(bufferedAbility) && (abilityBeingCast == null || abilityBeingCast.initialized == false) && globalCooldown == 0)
            {
                StartCasting(bufferedAbility);
            }
            if (state.Stunned == false)
            {

            }
        }
        else
            GameWorldReferenceClass.Respawn();
    }
}