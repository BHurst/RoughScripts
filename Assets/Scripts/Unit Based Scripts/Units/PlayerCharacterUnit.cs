using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerCharacterUnit : RootUnit
{
    public CastBar castBar;
    public List<GameObject> buffIcons = new List<GameObject>();
    public TalentCollection cTalents = new TalentCollection();

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
        //availableAbilities[0].stats.abilityKeywords.Add(KeywordDictionary.Area());
        charInventory.AddItem(ItemFactory.CreateGoreHead());
        charInventory.AddItem(ItemFactory.CreateDashSword());
        charInventory.AddItem(ItemFactory.CreateWizardRobe());
        charInventory.AddItem(ItemFactory.CreateMindOfMatterAmulet());
    }

    void CreateInitial()
    {
        doll.character = this;
        doll.DetermineStats();
        speech = ConversationFactory.AddDefaultConversation(unitName);
        unitID = Guid.NewGuid();
        GameWorldReferenceClass.GW_listOfAllUnits.Add(this);
        cTalents.simpleTalents.Add(new SimpleTalent() { modifier = new Modifier() { Mod = Modifier.StatModifiers.Orb_Damage_Flat, ModAmount = 5 } });

        RefreshStats();
    }

    new public void CastingTimeCheck()
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
        foreach (var talent in cTalents.simpleTalents)
        {
            totalStats.IncreaseStat(talent.modifier.Mod, talent.modifier.ModAmount);
        }
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
            MovementCheck();
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
        formRune = new Orb(),
        schoolRunes = new List<SchoolRune>() { new Fire() },
        harmRune = new Harm { rank = 5 },
        debuffRune = new Debuff { runeName = "Burn", rank = 3 },
        castModeRune = new CastTime(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Arc",
            formRune = new Arc(),
            schoolRunes = new List<SchoolRune>() { new Air() },
            harmRune = new Harm { rank = 4 },
            abilityToTrigger = new Ability()
            {
                abilityID = Guid.Empty,
                abilityName = "Strike",
                formRune = new Strike(),
                schoolRunes = new List<SchoolRune>() { new Air() },
                harmRune = new Harm { rank = 3 }
            }
        }
    };

    public Ability abilityIKnow2 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Strike",
        formRune = new Strike(),
        schoolRunes = new List<SchoolRune>() { new Air() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new CastTime()
    };

    public Ability abilityIKnow3 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Self Cast",
        formRune = new SelfCast(),
        harmRune = new Harm { selfHarm = true, rank = 5 },
        schoolRunes = new List<SchoolRune>() { new Fire() },
        castModeRune = new Instant(),
        specialEffect = new Dash()
    };

    public Ability abilityIKnow4 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Nova",
        formRune = new Nova(),
        schoolRunes = new List<SchoolRune>() { new Astral() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new Instant(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Strike",
            formRune = new Strike(),
            schoolRunes = new List<SchoolRune>() { new Air() },
            harmRune = new Harm { rank = 5 }
        }
    };

    public Ability abilityIKnow5 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Command",
        formRune = new Command(),
        schoolRunes = new List<SchoolRune>() { new Arcane() },
        harmRune = new Harm { rank = 1 },
        castModeRune = new Instant(),
        abilityToTrigger = new Ability()
        {
            abilityID = Guid.Empty,
            abilityName = "Nova",
            formRune = new Nova(),
            schoolRunes = new List<SchoolRune>() { new Astral() },
            harmRune = new Harm { rank = 3 }
        }
    };

    public Ability abilityIKnow6 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Wave",
        formRune = new Wave(),
        schoolRunes = new List<SchoolRune>() { new Water() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new CastTime()
    };

    public Ability abilityIKnow7 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Arc",
        formRune = new Arc(),
        schoolRunes = new List<SchoolRune>() { new Electricity() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new CastTime(),
        abilityToTrigger = new Ability() { abilityID = Guid.Empty, abilityName = "Zone", formRune = new Zone(), schoolRunes = new List<SchoolRune>() { new Ethereal() }, harmRune = new Harm { rank = 4 } }
    };

    public Ability abilityIKnow8 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Weapon",
        formRune = new Weapon(),
        castModeRune = new Instant(),
        schoolRunes = new List<SchoolRune>() { new Kinetic() },
        harmRune = new Harm { rank = 5 }
    };
    public Ability abilityIKnow9 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Beam",
        formRune = new Beam(),
        schoolRunes = new List<SchoolRune>() { new Arcane() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new CastTime()
    };

    public Ability abilityIKnow10 = new Ability()
    {
        abilityID = Guid.Empty,
        abilityName = "Zone",
        formRune = new Zone(),
        schoolRunes = new List<SchoolRune>() { new Ethereal() },
        harmRune = new Harm { rank = 5 },
        castModeRune = new CastTime()
    };
}