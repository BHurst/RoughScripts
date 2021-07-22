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
        for (int i = 0; i < 20; i++)
        {
            AbilitySlot newTempSlot = new AbilitySlot() { slotIndex = i };
            hotbarAbilities.Add(newTempSlot);
        }

        PlayerUnitStart();
    }

    public void PlayerUnitStart()
    {
        CreateInitial();
        LearnAbilities();
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

    public void LearnAbilities()
    {
        abilityIKnow1 = new Ability()
         {
             abilityID = Guid.Empty,
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
            abilityID = Guid.Empty,
            abilityName = "Strike",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Strike },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Air, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 10 },
            aEffectRunes = new List<EffectRune>() { new BuffIncreaseCastSpeed() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

            harmful = true,
            initialized = true
        };

        abilityIKnow3 = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Self Cast",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.SelfCast },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Fire, rank = 1 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            aEffectRunes = new List<EffectRune>() { new BuffIncreaseCastSpeed() { rank = 10, triggerTag = Rune.TriggerTag.OnCast } },

            harmful = true,
            selfHarm = true,
            initialized = true
        };

        abilityIKnow4 = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Nova",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Nova },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Astral, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.Empty,
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
            abilityID = Guid.Empty,
            abilityName = "Point",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Point },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Arcane, rank = 2 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },
            aEffectRunes = new List<EffectRune>() { new DebuffIncreaseDamageTaken() { rank = 10, triggerTag = Rune.TriggerTag.OnHit } },

            harmful = true,
            initialized = true
        };

        abilityIKnow6 = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Wave",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Wave },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Water, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },

            harmful = true,
            initialized = true
        };

        abilityIKnow7 = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Arc",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Arc },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Electricity, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.Empty,
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
            abilityID = Guid.Empty,
            abilityName = "Weapon",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Weapon },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Kinetic, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.Instant },

            harmful = true,
            initialized = true
        };

        abilityIKnow9 = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Beam",
            aFormRune = new FormRune() { formRuneType = Rune.FormRuneTag.Beam },
            aSchoolRune = new SchoolRune() { schoolRuneType = Rune.SchoolRuneTag.Arcane, rank = 5 },
            aCastModeRune = new CastModeRune() { castModeRuneType = Rune.CastModeRuneTag.CastTime, rank = 1 },

            harmful = true,
            initialized = true
        };

        abilityIKnow10 = new Ability()
        {
            abilityID = Guid.Empty,
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
        //cTalents.PlaceRune(1, new SimpleTalent() { modifier = new ModifierGroup() { Stat = ModifierGroup.eStat.MoveSpeed, Aspect = ModifierGroup.eAspect.Movement, Method = ModifierGroup.eMethod.MultiplyPercent, Value = 2 } });
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

    public override void CastingTimeCheck()
    {
        if (currentAbilityToUse != null && currentAbilityToUse.initialized)
        {
            if (currentAbilityToUse.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Instant)
            {
                Cast(currentAbilityToUse);
                StopCast();
                return;
            }
            movementState = MovementState.Casting;
            currentCastingTime += (Time.deltaTime + (Time.deltaTime * totalStats.Cast_Rate_AddPercent)) * totalStats.Cast_Rate_MultiplyPercent;
            if (currentAbilityToUse.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.CastTime)
            {
                castBar.CastUpdate(currentCastingTime / currentAbilityToUse.aCastModeRune.BaseCastTime(), (currentAbilityToUse.aCastModeRune.BaseCastTime() / (1 + totalStats.Cast_Rate_AddPercent) / totalStats.Cast_Rate_MultiplyPercent) - (currentCastingTime / (1 + totalStats.Cast_Rate_AddPercent) / totalStats.Cast_Rate_MultiplyPercent));
                if (currentCastingTime > currentAbilityToUse.aCastModeRune.BaseCastTime())
                {
                    Cast(currentAbilityToUse);
                    StopCast();
                    castBar.CastUpdate(0, 0);
                    return;
                }
            }
        }
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
            abilitiesOnCooldown.UpdateCooldowns();
        }
    }
}