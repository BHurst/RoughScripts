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
            abilityName = "Orb",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Orb },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Fire, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },
            aEffectRunes = new List<EffectRune>() { new Split() { rank = 1, triggerTag = Rune.TriggerTag.OnHit } },

            harmful = true,
            initialized = true
        };

        abilityIKnow2 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Strike",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Strike },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Air, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 10 },
            aEffectRunes = new List<EffectRune>() { new Buff() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

            harmful = true,
            initialized = true
        };

        abilityIKnow3 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Self Cast",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.SelfCast },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Ethereal, rank = 0 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            aEffectRunes = new List<EffectRune>() { new Dash() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

            harmful = true,
            selfHarm = true,
            initialized = true
        };

        abilityIKnow4 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Nova",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Nova },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Astral, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Strike },
                aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Air, rank = 5 },

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
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Command },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Arcane, rank = 2 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            aEffectRunes = new List<EffectRune>() { new Debuff() { rank = 10, triggerTag = Rune.TriggerTag.OnHit } },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Strike",
                aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Orb },
                aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Air, rank = 1 },

                harmful = true,
                initialized = true
            },

            harmful = true,
            initialized = true
        };

        abilityIKnow6 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Wave",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Wave },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Water, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },

            harmful = true,
            initialized = true
        };

        abilityIKnow7 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Arc",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Arc },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Electricity, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.NewGuid(),
                abilityName = "Zone",
                aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Zone },
                aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Ethereal, rank = 5 },
                harmful = true,
            },

            harmful = true,
            initialized = true
        };

        abilityIKnow8 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Weapon",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Weapon },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Kinetic, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },

            harmful = true,
            initialized = true
        };

        abilityIKnow9 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Beam",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Beam },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Arcane, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },

            harmful = true,
            initialized = true
        };

        abilityIKnow10 = new Ability()
        {
            abilityID = Guid.NewGuid(),
            abilityName = "Zone",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Zone },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Ethereal, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },

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

    public void StartCasting(Ability ability)
    {
        if (currentCastingTime > 0)
            ErrorScript.DisplayError("Busy Casting");
        else if (currentCastingTime == 0 && globalCooldown == 0 && (abilitiesOnCooldown.Find(x => x.abilityID == ability.abilityID) == null))
            queuedAbility = ability;
    }

    public override void CastingTimeCheck()
    {
        if (queuedAbility != null && queuedAbility.initialized)
        {
            if (queuedAbility.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
            {
                GetComponent<Animator>().Play("MainHandCast");
                abilityBeingCast = queuedAbility;
                globalCooldown = 1;
                abilityBeingCast.cooldown = abilityBeingCast.aCastModeRune.Cooldown();
                abilitiesOnCooldown.Add(abilityBeingCast);
                StopCast();
                return;
            }
            movementState = MovementState.Casting;
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent)) * totalStats.Cast_Rate_MultiplyPercent;
            if (queuedAbility.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                castBar.CastUpdate(currentCastingTime / queuedAbility.aCastModeRune.BaseCastTime(), (queuedAbility.aCastModeRune.BaseCastTime() / (1 + totalStats.Cast_Rate_AddPercent) / totalStats.Cast_Rate_MultiplyPercent) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent) / totalStats.Cast_Rate_MultiplyPercent));
                if (currentCastingTime > queuedAbility.aCastModeRune.BaseCastTime())
                {
                    GetComponent<Animator>().Play("MainHandCast");
                    abilityBeingCast = queuedAbility;
                    globalCooldown = 1;
                    abilityBeingCast.cooldown = abilityBeingCast.aCastModeRune.Cooldown();
                    abilitiesOnCooldown.Add(abilityBeingCast);
                    StopCast();
                    castBar.CastUpdate(0, 0);
                    return;
                }
            }
        }
    }

    public void Cast()
    {
        movementState = MovementState.Idle;
        GameObject abilityResult = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}", abilityBeingCast.aFormRune.formRuneType)), primarySpellCastLocation.position, new Quaternion()) as GameObject;
        GameObject particles = Instantiate(Resources.Load(String.Format("Prefabs/Abilities/Forms/{0}_Graphic/{1}_{0}_Graphic", abilityBeingCast.aFormRune.formRuneType, abilityBeingCast.aSchoolRune.schoolRuneType)), abilityResult.transform.position, new Quaternion()) as GameObject;
        particles.transform.SetParent(abilityResult.transform);
        WorldAbility worldAbility = abilityResult.GetComponent<WorldAbility>();
        worldAbility.Construct(abilityBeingCast, unitID);

        if (worldAbility.wEffectRunes != null)
        {
            foreach (var rune in worldAbility.wEffectRunes)
            {
                if (rune.triggerTag == Rune.TriggerTag.OnCast)
                    rune.Effect(this, this, worldAbility);
            }
        }
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
        LifeCheck();
        ResolveValueStatuses();
        if (isAlive == true)
        {
            CastingTimeCheck();
            if (state.Stunned == false)
            {

            }
        }
    }
}