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
        doll.AddEquipment(ItemFactory.CreateEquipment("GoreHelm"));
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        //cTalents.PlaceRune(1, new SimpleTalent() { modifier = new ModifierGroup() { Stat = ModifierGroup.eStat.MoveSpeed, Aspect = ModifierGroup.eAspect.Movement, Method = ModifierGroup.eMethod.MultiplyPercent, Value = 2 } });
        charInventory.Inventory.Add(new NightShale());
        RefreshStats();
    }

    public override void CastingTimeCheck()
    {
        if (currentAbilityToUse != null)
        {
            if (currentAbilityToUse.castModeRune.castMode == Rune.CastModeRuneTag.Instant)
            {
                Cast(currentAbilityToUse);
                currentAbilityToUse = null;
                currentCastingTime = 0;
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
                    currentAbilityToUse = null;
                    castBar.CastUpdate(0);
                    currentCastingTime = 0;
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
        schoolRunes = new List<SchoolRune>() { new Fire_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        debuffRune = new Debuff_Rune { runeName = "Burn", rank = 3 },
        castModeRune = new CastTime_Rune()
    };

    public Ability abilityIKnow2 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Strike",
        formRune = new Strike_Rune(),
        schoolRunes = new List<SchoolRune>() { new Air_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new CastTime_Rune()
    };

    public Ability abilityIKnow3 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Self Cast",
        formRune = new SelfCast_Rune(),
        harmRune = new Harm_Rune { selfHarm = true, rank = 5 },
        schoolRunes = new List<SchoolRune>() { new Fire_Rune() },
        castModeRune = new Instant_Rune(),
        specialEffect = new Retreat()
    };

    public Ability abilityIKnow4 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Nova",
        formRune = new Nova_Rune(),
        schoolRunes = new List<SchoolRune>() { new Astral_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new Instant_Rune(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Strike",
            formRune = new Strike_Rune(),
            schoolRunes = new List<SchoolRune>() { new Air_Rune() },
            harmRune = new Harm_Rune { rank = 5 }
        }
    };

    public Ability abilityIKnow5 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Command",
        formRune = new Command_Rune(),
        schoolRunes = new List<SchoolRune>() { new Arcane_Rune() },
        harmRune = new Harm_Rune { rank = 1 },
        castModeRune = new Instant_Rune(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Nova",
            formRune = new Nova_Rune(),
            schoolRunes = new List<SchoolRune>() { new Astral_Rune() },
            harmRune = new Harm_Rune { rank = 3 }
        }
    };

    public Ability abilityIKnow6 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Wave",
        formRune = new Wave_Rune(),
        schoolRunes = new List<SchoolRune>() { new Water_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new CastTime_Rune()
    };

    public Ability abilityIKnow7 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Arc",
        formRune = new Arc_Rune(),
        schoolRunes = new List<SchoolRune>() { new Electricity_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new CastTime_Rune(),
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Zone", formRune = new Zone_Rune(), schoolRunes = new List<SchoolRune>() { new Ethereal_Rune() }, harmRune = new Harm_Rune { rank = 4 } }
    };

    public Ability abilityIKnow8 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Weapon",
        formRune = new Weapon_Rune(),
        castModeRune = new Instant_Rune(),
        schoolRunes = new List<SchoolRune>() { new Kinetic_Rune() },
        harmRune = new Harm_Rune { rank = 5 }
    };
    public Ability abilityIKnow9 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Beam",
        formRune = new Beam_Rune(),
        schoolRunes = new List<SchoolRune>() { new Arcane_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new CastTime_Rune()
    };

    public Ability abilityIKnow10 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Zone",
        formRune = new Zone_Rune(),
        schoolRunes = new List<SchoolRune>() { new Ethereal_Rune() },
        harmRune = new Harm_Rune { rank = 5 },
        castModeRune = new CastTime_Rune()
    };
}