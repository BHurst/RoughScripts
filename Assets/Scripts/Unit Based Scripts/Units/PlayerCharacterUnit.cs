using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootUnit
{
    public CastBar castBar;
    public List<GameObject> buffIcons = new List<GameObject>();
    public LocusRune cTalents = new LocusRune();
    public List<Rune> knownRunes = new List<Rune>();
    public InventoryItem quickItem;
    public CharacterLevel level = new CharacterLevel();

    public Ability abilityIKnow1;
    public Ability abilityIKnow2;
    public Ability abilityIKnow3;
    public Ability abilityIKnow4;
    public Ability abilityIKnow5;
    public Ability abilityIKnow6;
    public Ability abilityIKnow7;
    public Ability abilityIKnow8;
    public Ability abilityIKnow9;
    public Ability abilityIKnow10;

    public Ability bufferedAbility;

    public event EventHandler<Status> StatusGained;
    public event EventHandler<Status> StatusLost;

    private void Start()
    {
        PlayerUnitStart();
    }

    public void PlayerUnitStart()
    {
        CreateInitial();
        LearnAbilities();
        FillHotBar();
        GameWorldReferenceClass.LearnAllRunes();
        var thing1 = ItemFactory.CreateEquipment("BasicVambrace", "Arm_Lower");
        charInventory.AddItem(thing1);
        var thing2 = ItemFactory.CreateEquipment("BasicVambrace", "Arm_Lower");
        charInventory.AddItem(thing2);
        var thing3 = ItemFactory.CreateEquipment("BasicRerebrace", "Arm_Upper");
        charInventory.AddItem(thing3);
        var thing4 = ItemFactory.CreateEquipment("BasicRerebrace", "Arm_Upper");
        charInventory.AddItem(thing4);
        var thing5 = ItemFactory.CreateEquipment("BasicCloak", "Back");
        charInventory.AddItem(thing5);
        var thing6 = ItemFactory.CreateEquipment("BasicBreastplate", "Chest");
        charInventory.AddItem(thing6);
        var thing7 = ItemFactory.CreateEquipment("BasicSabaton", "Foot");
        charInventory.AddItem(thing7);
        var thing8 = ItemFactory.CreateEquipment("BasicSabaton", "Foot");
        charInventory.AddItem(thing8);
        var thing9 = ItemFactory.CreateEquipment("BasicGauntlet", "Hand");
        charInventory.AddItem(thing9);
        var thing10 = ItemFactory.CreateEquipment("BasicGauntlet", "Hand");
        charInventory.AddItem(thing10);
        var thing11 = ItemFactory.CreateEquipment("BasicHelm", "Head");
        thing11.attatchedAbility.NameSelf();
        thing11.attatchedAbility.EffectFromInspector();
        thing11.locusRune.PlaceSimpleRune(new SimpleTalent() { modifiers = new List<ModifierGroup> { new ModifierGroup() { Stat = ModifierGroup.EStat.MoveSpeed, Aspect = ModifierGroup.EAspect.Movement, Method = ModifierGroup.EMethod.MultiplyPercent, Value = 2 } } });
        thing11.locusRune.PlaceComplexRune(new CT_ExplosiveFireOrb(), this);
        thing11.locusRune.PlaceComplexRune(new CT_HotColdSwap(), this);
        charInventory.AddItem(thing11);
        var thing12 = ItemFactory.CreateEquipment("BasicGreave", "Leg_Lower");
        charInventory.AddItem(thing12);
        var thing13 = ItemFactory.CreateEquipment("BasicGreave", "Leg_Lower");
        charInventory.AddItem(thing13);
        var thing14 = ItemFactory.CreateEquipment("BasicCuisse", "Leg_Upper");
        charInventory.AddItem(thing14);
        var thing15 = ItemFactory.CreateEquipment("BasicCuisse", "Leg_Upper");
        charInventory.AddItem(thing15);
        var thing16 = ItemFactory.CreateEquipment("BasicAmulet", "Neck");
        charInventory.AddItem(thing16);
        var thing17 = ItemFactory.CreateEquipment("BasicPauldron", "Shoulder");
        charInventory.AddItem(thing17);
        var thing18 = ItemFactory.CreateEquipment("BasicPauldron", "Shoulder");
        charInventory.AddItem(thing18);
        var thing19 = ItemFactory.CreateEquipment("BasicFaulds", "Waist");
        charInventory.AddItem(thing19);
        var thing20 = ItemFactory.CreateEquipment("BasicSword", "Weapon");
        charInventory.AddItem(thing20);
        var thing21 = ItemFactory.CreateEquipment("BasicSword", "Weapon");
        charInventory.AddItem(thing21);
    }

    public void FillHotBar()
    {
        GameObject.Find("HotbarSlot0").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow1);
        GameObject.Find("HotbarSlot1").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow2);
        GameObject.Find("HotbarSlot2").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow3);
        GameObject.Find("HotbarSlot3").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow4);
        GameObject.Find("HotbarSlot4").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow5);
        GameObject.Find("HotbarSlot5").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow6);
        GameObject.Find("HotbarSlot6").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow7);
        GameObject.Find("HotbarSlot7").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow8);
        GameObject.Find("HotbarSlot8").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow9);
        GameObject.Find("HotbarSlot9").GetComponent<SingleAbilitySlotScript>().PopulateSlot(abilityIKnow10);
    }

    public void LearnAbilities()
    {
        abilityIKnow1 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Fire Orb",
            aFormRune = new FormRune_Orb(),
            aSchoolRune = new SchoolRune_Fire(),
            aCastModeRune = new CastModeRune_CastTime(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Split() { rank = 1, triggerTag = Rune.TriggerTag.OnHit } },

            harmful = true,
            initialized = true
        };

        abilityIKnow2 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Strike",
            aFormRune = new FormRune_Strike(),
            aSchoolRune = new SchoolRune_Air(),
            aCastModeRune = new CastModeRune_CastTime(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Buff() { rank = 10, triggerTag = Rune.TriggerTag.OnCast, stat = ModifierGroup.EStat.Cast, aspect = ModifierGroup.EAspect.Rate, method = ModifierGroup.EMethod.AddPercent } },

            harmful = true,
            initialized = true
        };

        abilityIKnow3 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Self Cast",
            aFormRune = new FormRune_SelfCast(),
            aSchoolRune = new SchoolRune_Ethereal(),
            aCastModeRune = new CastModeRune_Instant(),
            aEffectRunes = new List<EffectRune>() { new EffectRune_Dash() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

            harmful = true,
            selfHarm = true,
            initialized = true
        };

        abilityIKnow4 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Nova",
            aFormRune = new FormRune_Nova(),
            aSchoolRune = new SchoolRune_Astral(),
            aCastModeRune = new CastModeRune_Instant(),
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
        };

        abilityIKnow5 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Command",
            aFormRune = new FormRune_Command(),
            aSchoolRune = new SchoolRune_Arcane(),
            aCastModeRune = new CastModeRune_Instant(),
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
        };

        abilityIKnow6 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Ice Orb",
            aFormRune = new FormRune_Orb(),
            aSchoolRune = new SchoolRune_Ice(),
            aCastModeRune = new CastModeRune_CastTime(),

            harmful = true,
            initialized = true
        };

        abilityIKnow7 = new Ability()
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
        };

        abilityIKnow8 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Weapon",
            aFormRune = new FormRune_Weapon(),
            aSchoolRune = new SchoolRune_Kinetic(),
            aCastModeRune = new CastModeRune_Instant(),

            harmful = true,
            initialized = true
        };

        abilityIKnow9 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Beam",
            aFormRune = new FormRune_Beam(),
            aSchoolRune = new SchoolRune_Arcane(),
            aCastModeRune = new CastModeRune_CastTime(),

            harmful = true,
            initialized = true
        };

        abilityIKnow10 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Zone",
            aFormRune = new FormRune_Zone(),
            aSchoolRune = new SchoolRune_Ethereal(),
            aCastModeRune = new CastModeRune_CastTime(),

            harmful = true,
            initialized = true
        };
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        InventoryItem item = new InventoryItem() { itemID = 1, itemName = "Night Shale", itemType = ItemType.Consumable, healAmount = 35, maxCharges = 2, currentCharges = 2, usable = true, usableItem = new ConsumabeHealItemUse() };
        charInventory.AddItem(item);
        SetQuickItem(0);
        RefreshStats();
    }

    public void SetQuickItem(int index)
    {
        quickItem = charInventory.Inventory[index];
        GameWorldReferenceClass.GW_CharacterPanel.quickItemSlot.SetQuickItem(charInventory.Inventory[0]);
    }

    public override void AddStatus(Status status)
    {
        activeStatuses.Add(status);
        status.currentDuration = status.maxDuration;
        StatusGained?.Invoke(this, status);
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

    public void StartCasting(Ability ability)
    {
        //Can I afford it?
        if (ability.GetCost() > unitMana)
            ErrorScript.DisplayError("Not Enough Mana");
        else if (ability.GetCost() > unitHealth)
            ErrorScript.DisplayError("Not Enough Health");
        //Is it available?
        else if (currentCastingTime == 0 && globalCooldown == 0 && (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null))
        {
            globalCooldown = 1;
            abilityPreparingToCast = ability;
            bufferedAbility = null;
        }
        //Will the cooldown/cast time runout before it would be cast?
        else if (globalCooldown <= GameWorldReferenceClass.inputBuffer)
        {
            if ((abilityPreparingToCast != null && abilityPreparingToCast.aCastModeRune.baseCastTime - currentCastingTime <= GameWorldReferenceClass.inputBuffer) || abilityPreparingToCast == null)
            {
                //Is it not on cooldown, or it is but its less than the global cooldown/input buffer
                if (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null ||
                    (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) != null && abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID).cooldown <= globalCooldown) ||
                    (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) != null && abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID).cooldown <= GameWorldReferenceClass.inputBuffer))
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
        if (abilityPreparingToCast != null && abilityPreparingToCast.initialized)
        {
            if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
            {
                animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
                abilityBeingCast = abilityPreparingToCast;
                StopCast();
                return;
            }
            movementState = MovementState.Casting;
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent.value)) * totalStats.Cast_Rate_MultiplyPercent.value;
            if (abilityPreparingToCast.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                castBar.CastUpdate(currentCastingTime / abilityPreparingToCast.aCastModeRune.baseCastTime, (abilityPreparingToCast.aCastModeRune.baseCastTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent.value) / totalStats.Cast_Rate_MultiplyPercent.value));
                if (currentCastingTime > abilityPreparingToCast.aCastModeRune.baseCastTime)
                {
                    animator.SetTrigger(abilityPreparingToCast.aFormRune.formAnimation);
                    abilityBeingCast = abilityPreparingToCast;
                    StopCast();
                    castBar.CastUpdate(0, 0);
                    return;
                }
            }
        }
    }

    public override void Cast()
    {
        movementState = MovementState.Idle;
        WorldAbility worldAbility = AbilityFactory.InstantiateWorldAbility(abilityBeingCast, primarySpellCastLocation.position, unitID, false).GetComponent<WorldAbility>();
        GlobalEventManager.AbilityCastTrigger(this, worldAbility, this, transform.position);
        if (worldAbility.wEffectRunes != null)
        {
            foreach (var rune in worldAbility.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                    rune.Effect(this, this, worldAbility);
            }
        }
        unitMana -= abilityBeingCast.GetCost();
        abilityBeingCast.cooldown = abilityBeingCast.aSchoolRune.baseCooldown;
        abilitiesOnCooldown.Add(abilityBeingCast);
        abilityPreparingToCast = null;
        abilityBeingCast = null;
    }

    public void PlayerKill()
    {
        Kill();
    }

    public void LifeCheck()
    {
        if (unitHealth < 0)
            unitHealth = 0;
        else if (unitHealth > unitMaxHealth)
            unitHealth = unitMaxHealth;

        if (unitHealth <= 0)
        {
            Kill();
        }
    }

    new public void RefreshStats()
    {

    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        IncrementTimers();
        ResolveValueStatuses();
        RegenTick();
        LifeCheck();
        if (isAlive == true)
        {
            CastingTimeCheck();
            if (bufferedAbility != null && bufferedAbility.initialized && (abilityBeingCast == null || abilityBeingCast.initialized == false) && globalCooldown == 0)
            {
                StartCasting(bufferedAbility);
            }
            if (state.Stunned == false)
            {

            }
        }
    }
}