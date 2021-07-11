using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootUnit
{
    public CastBar castBar;
    public List<GameObject> buffIcons = new List<GameObject>();
    public LocusRune cTalents = new LocusRune();

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
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicVambrace", "Arm_Lower"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicVambrace", "Arm_Lower"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicRerebrace", "Arm_Upper"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicRerebrace", "Arm_Upper"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicCloak", "Back"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicBreastplate", "Chest"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicSabaton", "Foot"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicSabaton", "Foot"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicGauntlet", "Hand"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicGauntlet", "Hand"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicHelm", "Head"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicGreave", "Leg_Lower"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicGreave", "Leg_Lower"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicCuisse", "Leg_Upper"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicCuisse", "Leg_Upper"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicAmulet", "Neck"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicPauldron", "Shoulder"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicPauldron", "Shoulder"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicFaulds", "Waist"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicSword", "Weapon"));
        charInventory.AddItem(ItemFactory.CreateEquipment("BasicSword", "Weapon"));
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        //cTalents.PlaceRune(1, new SimpleTalent() { modifier = new ModifierGroup() { Stat = ModifierGroup.eStat.MoveSpeed, Aspect = ModifierGroup.eAspect.Movement, Method = ModifierGroup.eMethod.MultiplyPercent, Value = 2 } });
        charInventory.AddItem(new InventoryItem() {itemID = 1, itemName = "Night Shale", itemType = ItemType.Consumable, healAmount = 35, maxCharges = 5, currentCharges = 5, usable = true, usableItem = new NightShaleUse() }  );
        RefreshStats();
    }

    public override void CastingTimeCheck()
    {
        if (currentAbilityToUse != null && currentAbilityToUse.initialized)
        {
            if (currentAbilityToUse.castModeRune.castMode == Rune.CastModeRuneTag.Instant)
            {
                Cast(currentAbilityToUse);
                StopCast();
                return;
            }
            movementState = MovementState.Casting;
            currentCastingTime += Time.deltaTime;
            if (currentAbilityToUse.castModeRune.castMode == Rune.CastModeRuneTag.CastTime)
            {
                castBar.CastUpdate(currentCastingTime / (currentAbilityToUse.castModeRune.castTime));
                if (currentCastingTime > currentAbilityToUse.castModeRune.castTime)
                {
                    Cast(currentAbilityToUse);
                    StopCast();
                    castBar.CastUpdate(0);
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
            ActionCD();
        }
    }

    public Ability abilityIKnow1 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Orb",
        formRune = new Orb_Rune(),
        schoolRune = new Fire_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        debuffRune = new Debuff_Rune { active = true, runeName = "Burn", rank = 3 },
        castModeRune = new CastTime_Rune(),

        initialized = true
    };

    public Ability abilityIKnow2 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Strike",
        formRune = new Strike_Rune(),
        schoolRune = new Air_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new CastTime_Rune(),

        initialized = true
    };

    public Ability abilityIKnow3 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Self Cast",
        formRune = new SelfCast_Rune(),
        harmRune = new Harm_Rune { active = true, selfHarm = true, rank = 5 },
        schoolRune = new Fire_Rune(),
        castModeRune = new Instant_Rune(),
        specialEffect = new Dash(),

        initialized = true
    };

    public Ability abilityIKnow4 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Nova",
        formRune = new Nova_Rune(),
        schoolRune = new Astral_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new Instant_Rune(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Strike",
            formRune = new Strike_Rune(),
            schoolRune = new Air_Rune(),
            harmRune = new Harm_Rune { active = true, rank = 5 },

            initialized = true
        },

        initialized = true
    };

    public Ability abilityIKnow5 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Command",
        formRune = new Command_Rune(),
        schoolRune = new Arcane_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 1 },
        castModeRune = new Instant_Rune(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Nova",
            formRune = new Nova_Rune(),
            schoolRune = new Astral_Rune(),
            harmRune = new Harm_Rune { active = true, rank = 3 },

            initialized = true
        },

        initialized = true
    };

    public Ability abilityIKnow6 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Wave",
        formRune = new Wave_Rune(),
        schoolRune = new Water_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new CastTime_Rune(),

        initialized = true
    };

    public Ability abilityIKnow7 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Arc",
        formRune = new Arc_Rune(),
        schoolRune = new Electricity_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new CastTime_Rune(),
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Zone", formRune = new Zone_Rune(), schoolRune = new Ethereal_Rune(), harmRune = new Harm_Rune { active = true, rank = 4 } },

        initialized = true
    };

    public Ability abilityIKnow8 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Weapon",
        formRune = new Weapon_Rune(),
        castModeRune = new Instant_Rune(),
        schoolRune = new Kinetic_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },

        initialized = true
    };
    public Ability abilityIKnow9 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Beam",
        formRune = new Beam_Rune(),
        schoolRune = new Arcane_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new CastTime_Rune(),

        initialized = true
    };

    public Ability abilityIKnow10 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Zone",
        formRune = new Zone_Rune(),
        schoolRune = new Ethereal_Rune(),
        harmRune = new Harm_Rune { active = true, rank = 5 },
        castModeRune = new CastTime_Rune(),

        initialized = true
    };
}