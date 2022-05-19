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
    public InventoryItem quickItem;
    public CharacterLevel level = new CharacterLevel();
    public PlayerHotbarAbilities playerHotbar = new PlayerHotbarAbilities();

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
        var thing1 = ItemFactory.CreateEquipment("BasicHelm", EquipmentInventoryItem.EquipmentSlot.Head);
        thing1.locusRune.PlaceSimpleRune(new SimpleTalent() { modifiers = new List<ModifierGroup> { new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, Value = 2 } } });
        thing1.locusRune.PlaceComplexRune(new CT_ExplosiveFireOrb(), this);
        thing1.locusRune.PlaceComplexRune(new CT_HotColdSwap(), this);
        charInventory.AddItem(thing1);
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        charInventory.AddItem(ItemFactory.CreateRandomEquipment());
    }

    public void LearnAbilities()
    {
        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Fire Orb",
            aFormRune = new FormRune_Orb(),
            aSchoolRune = new SchoolRune_Fire(),
            aCastModeRune = new CastModeRune_CastTime(),
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
            aCastModeRune = new CastModeRune_Charges(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Dash() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

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
            aCastModeRune = new CastModeRune_Charges(),
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune_Strike(),
                aSchoolRune = new SchoolRune_Air(),

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
            aCastModeRune = new CastModeRune_Charges(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Debuff() { rank = 10, triggerTag = Rune.TriggerTag.OnHit } },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune_Strike(),
                aSchoolRune = new SchoolRune_Air(),

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
            aCastModeRune = new CastModeRune_Charges(),

            harmful = true,
            initialized = true
        }, 7);

        playerHotbar.PlaceSlot(new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Beam",
            aFormRune = new FormRune_Beam(),
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
        unitEquipment.DetermineStats();
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
        quickItem = charInventory.Inventory[index];
        GameWorldReferenceClass.GW_CharacterPanel.quickItemSlot.SetQuickItem(charInventory.Inventory[0]);
    }

    public override void ResolveHit(float value, bool overTime)
    {
    }

    public override void ResolveHeal(float value)
    {
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

    public void ChargingCheck()
    {
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        castBar.CastUpdate(currentCastingTime / unitAbilityCharges.baseChargeRecoveryTime, (unitAbilityCharges.baseChargeRecoveryTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value));
        if (currentCastingTime > unitAbilityCharges.baseChargeRecoveryTime)
        {
            //animator.SetTrigger(abilityCharging.aFormRune.formAnimation);

            unitAbilityCharges.RecoverCharge(abilityCharging.aSchoolRune.schoolRuneType);
            currentCastingTime = 0;
            if (unitAbilityCharges.IsChargeFull(abilityCharging.aSchoolRune.schoolRuneType))
            {
                abilityCharging = null;
                currentCastingTime = 0;
            }
            return;
        }
    }

    public void StartCasting(Ability ability)
    {
        //Can I afford it?
        if (ability.GetCost() > totalStats.Mana_Current)
            ErrorScript.DisplayError("Not Enough Mana");
        else if (ability.GetCost() > totalStats.Health_Current)
            ErrorScript.DisplayError("Not Enough Health");
        else if ((ability.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charges && (unitAbilityCharges.CheckCharge(ability.aSchoolRune.schoolRuneType) <= 0)))
            ErrorScript.DisplayError("No Charges Left");
        //Is it available?
        else if (actionState == ActionState.Idle && globalCooldown == 0 && (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null))
        {
            globalCooldown = 1;
            actionState = ActionState.Casting;
            abilityPreparingToCast = ability;
            bufferedAbility = null;
        }
        //Will the cooldown/cast time runout before it would be cast?
        else if (globalCooldown <= GameWorldReferenceClass.inputBuffer)
        {
            if ((abilityPreparingToCast != null && abilityPreparingToCast.aCastModeRune.baseCastTime - currentCastingTime <= GameWorldReferenceClass.inputBuffer) || abilityPreparingToCast == null)
            {
                //Is it not on cooldown, or it is but its less than the global cooldown/input buffer
                Ability foundCD = abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID);
                if (foundCD == null || (foundCD != null && foundCD.cooldown <= globalCooldown) || (foundCD != null && foundCD.cooldown <= GameWorldReferenceClass.inputBuffer))
                {
                    bufferedAbility = ability;
                }
            }

        }
        //Am I busy?
        else if (currentCastingTime > 0)
            ErrorScript.DisplayError("Busy Casting");
    }

    public override void CastingTimeCheck()
    {
        if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant || abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charges)
        {
            animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
            abilityBeingCast = abilityPreparingToCast;
            FinishPreparingToCast();
            return;
        }
        currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
        if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
        {
            castBar.CastUpdate(currentCastingTime / abilityPreparingToCast.aSchoolRune.baseCastSpeed, (abilityPreparingToCast.aSchoolRune.baseCastSpeed / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value));
            if (currentCastingTime > abilityPreparingToCast.aSchoolRune.baseCastSpeed)
            {
                animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
                abilityBeingCast = abilityPreparingToCast;
                FinishPreparingToCast();
                castBar.CastUpdate(0, 0);
                return;
            }
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
                    if(rune.targetSelf)
                        rune.Effect(this, this, worldAbility);
                }
            }
        }

        if (abilityBeingCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charges)
            unitAbilityCharges.ExpendCharge(abilityBeingCast.aSchoolRune.schoolRuneType);

        totalStats.Mana_Current -= abilityBeingCast.GetCost();
        abilityBeingCast.cooldown = abilityBeingCast.aSchoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);
        FinishPreparingToCast();
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
        abilityPreparingToCast = null;
        abilityBeingCast = null;
        abilityCharging = null;
        bufferedAbility = null;
    }

    public void FinishPreparingToCast()
    {
        currentCastingTime = 0;
        abilityPreparingToCast = null;
        abilityCharging = null;
    }

    new public void RefreshStats()
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

            if (abilityPreparingToCast != null && abilityPreparingToCast.initialized)
            {
                CastingTimeCheck();
            }
            else if (abilityCharging != null && abilityCharging.initialized)
            {
                ChargingCheck();
            }

            if (bufferedAbility != null && bufferedAbility.initialized && (abilityBeingCast == null || abilityBeingCast.initialized == false) && globalCooldown == 0)
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