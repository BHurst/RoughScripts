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
    public CharacterLevel level = new CharacterLevel();
    public PlayerHotbarAbilities playerHotbar = new PlayerHotbarAbilities();
    public PlayerFloatingDamageTaken PlayerFloatingDamageTaken;
    public RootAbility bufferedAbility;
    public List<LocusRuneItem> availableLocusRuneItems = new List<LocusRuneItem>();
    public PlayerResources playerResources = new PlayerResources();

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
        entityType = EntityType.Player;
        unitEquipment.character = this;
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        LearnAbilities();
        GameWorldReferenceClass.LearnAllRunes();
        InventoryItem item = new Consumable_Item_NightShale();
        charInventory.owner = unitID;
        charInventory.AddItem(item);
        charInventory.SetQuickItem(0);
        var thing1 = ItemFactory.CreateEquipment("BasicHelm", EquipmentSlot.SlotType.Head);
        thing1.mods.Add(new ModifierGroup() { Stat = ModifierGroup.EStat.Movement, Aspect = ModifierGroup.EAspect.Rate, Method = ModifierGroup.EMethod.MultiplyPercent, Value = 2 });
        thing1.attatchedAbility = new LightningLob_Data(unitID, entityType);
        charInventory.AddItem(thing1);
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        availableLocusRuneItems.Add(new LocusRuneItem() { LocusRune = LocusRune.RandomRune() });
        RefreshStats();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 25; i++)
        {
            charInventory.AddItem(ItemFactory.CreateRandomEquipment());
        }
        watch.Stop();
        Debug.Log(watch.ElapsedMilliseconds + " to create 25 equipment items in the players inventory");
        RigParticles();
    }

    public void LearnAbilities()
    {

        BasicAbility ability1 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability1, 0);
        knownAbilities.Add(ability1);

        //playerHotbar.PlaceSlot(new LightningLob_Data(unitID, entityType), 1);

        BasicAbility ability3 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability3, 2);
        knownAbilities.Add(ability3);

        BasicAbility ability4 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability4, 3);
        knownAbilities.Add(ability4);

        BasicAbility ability5 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability5, 4);
        knownAbilities.Add(ability5);

        BasicAbility ability6 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability6, 5);
        knownAbilities.Add(ability6);

        BasicAbility ability7 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability7, 6);
        knownAbilities.Add(ability7);

        BasicAbility ability8 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability8, 7);
        knownAbilities.Add(ability8);

        BasicAbility ability9 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability9, 8);
        knownAbilities.Add(ability9);

        BasicAbility ability10 = new BasicAbility()
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
        };

        playerHotbar.PlaceSlot(ability10, 9);
        knownAbilities.Add(ability10);
    }

    public override void InflictDamage(float value, bool overTime)
    {
        totalStats.ModifyHealth(-value);
        PlayerFloatingDamageTaken.AddHit(-value);
    }

    public override void InflictHealing(float value, bool overTime)
    {
        totalStats.ModifyHealth(value);
        PlayerFloatingDamageTaken.AddHit(value);
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