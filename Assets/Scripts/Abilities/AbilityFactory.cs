using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityFactory
{
    public static RootAbility ToRootAbility(RootWorldAbility rWA)
    {
        RootAbility newRA = new RootAbility();

        newRA.abilityID = rWA.abilityID;
        newRA.stats = rWA.stats;

        return newRA;
    }

    public static RootWorldAbility ToRootWorldAbility(RootAbility rA)
    {
        RootWorldAbility newRWA = new RootWorldAbility();

        newRWA.abilityID = rA.abilityID;
        newRWA.stats = rA.stats;

        return newRWA;
    }

    //

    //Utility
    public static RootAbility CreateCharm()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Utility,
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Charm";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage(){ baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Utility });
        //NewAbility.stats.abilityBaseRangeMaximum = 3;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.whoShouldITarget = SpellStats.AbilityTarget.Target;

        //Charm newEffect = new Charm();
        //NewAbility.stats.specialEffects.Add(newEffect);
        //newEffect.specialEffectName = "Charm";

        return NewAbility;
    }

    //Physical
    public static RootAbility CreateDash()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Instant,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.SelfTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.SelfCast
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Dash";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Utility;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.whoShouldITarget = SpellStats.AbilityTarget.Self;
        //RootStatus newStatus = new RootStatus();

        //Dash newEffect = new Dash();
        //NewAbility.stats.specialEffects.Add(newEffect);
        //newEffect.specialEffectName = "Dash";
        
        return NewAbility;
    }

    public static RootAbility CreateBash()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Instant,
        //    AbilityTags.AbilityTag.WeaponCast,
        //    AbilityTags.AbilityTag.SingleTarget
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Bash";
        //NewAbility.stats.weaponModifer = 1.4f;
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Melee";
        ////NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Physical });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Physical;
        //NewAbility.stats.abilityBaseRangeMaximum = 3;
        //NewAbility.stats.abilityBaseCooldown = 5f;
        //RootStatus newStatus = new RootStatus();

        return NewAbility;
    }

    public static RootAbility CreateLacerate()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Instant,
        //    AbilityTags.AbilityTag.WeaponCast,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Physical,
        //    AbilityTags.AbilityTag.Duration
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Lacerate";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Melee";
        ////NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Physical });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Physical;
        //NewAbility.stats.abilityBaseRangeMaximum = 3f;
        //NewAbility.stats.abilityBaseCooldown = 3f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.WeaponCast,
        //    AbilityTags.AbilityTag.Duration,
        //    AbilityTags.AbilityTag.Physical
        //};

        //newStatus.statusName = "Laceration";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 16f;
        //newStatus.statusBaseInterval = 2f;
        //newStatus.statusBaseTicks = 8f;
        //newStatus.statusWeaponModifier = .2f;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Physical;
        //newStatus.statusClassification = RootStatus.StatusClassification.Bleed;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateSwordAura()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Buff,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Persist,
        //    AbilityTags.AbilityTag.Area,
        //    AbilityTags.AbilityTag.SingleTarget
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Sword Aura";
        //NewAbility.stats.weaponModifer = 1.4f;
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Warrior/Knight/SwordAura";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 3, abilityBaseDamageType = SpellStats.AbilitySchool.Physical });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Physical;
        //NewAbility.stats.abilityBaseDuration = 120f;
        //NewAbility.stats.abilityBasePulseTimer = .5f;
        //NewAbility.stats.abilityBaseArea = 3f;
        //NewAbility.stats.abilityBaseRangeMaximum = 2;
        //NewAbility.stats.abilityBaseCooldown = 5f;
        //RootStatus newStatus = new RootStatus();

        return NewAbility;
    }

    public static RootAbility CreateShockwave()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.Area,
        //    AbilityTags.AbilityTag.Physical,
        //    AbilityTags.AbilityTag.Knockback,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.SelfCast
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Shockwave";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Warrior/Shockwave";
        //NewAbility.stats.abilityRequiresTarget = false;
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 10, abilityBaseDamageType = SpellStats.AbilitySchool.Physical });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Physical;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //NewAbility.stats.abilityBaseArea = 5f;
        //NewAbility.stats.abilityBaseForce = 100f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Disorient,
        //    AbilityTags.AbilityTag.Physical
        //};

        //newStatus.statusName = "Shockwave";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 3f;
        //newStatus.statusBaseInterval = 3f;
        //newStatus.statusBaseTicks = 1f;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Physical;
        //newStatus.statusClassification = RootStatus.StatusClassification.Detriment;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    //Arcane
    public static RootAbility CreatePulse()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Instant,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.Arcane,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Spell
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Pulse";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityRequiresLos = true;
        //NewAbility.stats.numberOfSpells = 1;
        //NewAbility.stats.abilityBaseCost = 0;
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 5, abilityBaseDamageType = SpellStats.AbilitySchool.Arcane });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Arcane;
        //NewAbility.stats.abilityBaseRangeMinimum = 0;
        //NewAbility.stats.abilityBaseRangeMaximum = 10f;
        //NewAbility.stats.abilityBaseCooldown = 0f;
        //NewAbility.stats.abilityBaseDuration = 0f;
        //NewAbility.stats.abilityBaseCastTime = 0f;
        //NewAbility.stats.abilityBaseArea = 0;
        return NewAbility;
    }

    public static RootAbility CreateStreamline()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Instant,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.SelfTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Buff,
        //    AbilityTags.AbilityTag.Arcane
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Streamline";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Arcane });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Arcane;
        //NewAbility.stats.abilityBaseCooldown = 90f;
        //NewAbility.stats.whoShouldITarget = SpellStats.AbilityTarget.Self;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.Buff,
        //    AbilityTags.AbilityTag.Arcane,
        //    AbilityTags.AbilityTag.Charges
        //};

        //newStatus.statusName = "Streamline";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 15f;
        //newStatus.statusBaseInterval = 15f;
        //newStatus.statusBaseTicks = 1f;
        //newStatus.statusBaseCharges = 3f;
        //newStatus.statusChargesRemoval = RootStatus.ChargesRemovedBy.CastSpell;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Arcane;
        //newStatus.statusClassification = RootStatus.StatusClassification.Imbue;
        //newStatus.statusStatsToModify.Add(new Modifier() { Mod = Modifier.StatModifiers.CooldownReduction, ModAmount = .5f });
        //newStatus.statusStatsToModify.Add(new Modifier() { Mod = Modifier.StatModifiers.BonusCastSpeedPercent, ModAmount = 1.5f });
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Self;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateSwell()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Channel,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Buff,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Arcane
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Swell";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Arcane });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Arcane;
        //NewAbility.stats.abilityBaseCastTime = 15f;
        //NewAbility.stats.abilityBaseInterval = 1f;
        //NewAbility.stats.whoShouldITarget = SpellStats.AbilityTarget.Self;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.Buff,
        //    AbilityTags.AbilityTag.Arcane
        //};

        //newStatus.statusName = "Swell";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 15f;
        //newStatus.statusBaseInterval = 15f;
        //newStatus.statusBaseTicks = 15f;
        //newStatus.stackable = true;
        //newStatus.statusClassification = RootStatus.StatusClassification.Imbue;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Self;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    //Fire
    public static RootAbility CreateFireball()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Fire,
        //    AbilityTags.AbilityTag.Projectile,
        //    AbilityTags.AbilityTag.Duration
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Fireball";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Mage/Fireball";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 10, abilityBaseDamageType = SpellStats.AbilitySchool.Fire });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Fire;
        //NewAbility.stats.abilityBaseRangeMaximum = 10f;
        //NewAbility.stats.abilityBaseCooldown = 3f;
        //NewAbility.stats.abilityBaseDuration = 5f;
        //NewAbility.stats.abilityBaseCastTime = 1.5f;
        //NewAbility.stats.abilityBaseSpeed = 30f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage
        //};

        //newStatus.statusName = "Burn";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusIsToggle = false;
        //newStatus.statusBaseDuration = 3f;
        //newStatus.statusBaseInterval = 1f;
        //newStatus.statusBaseTicks = 3f;
        //newStatus.statusBaseDamage = 1;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Fire;
        //newStatus.statusClassification = RootStatus.StatusClassification.Burn;
        //newStatus.statusBaseStatusChance = 15;
        //newStatus.statusBaseEffect = "None";
        //newStatus.multiUnitStackable = true;
        //newStatus.stackable = true;
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateFireDice()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Fire,
        //    AbilityTags.AbilityTag.Projectile,
        //    AbilityTags.AbilityTag.Duration,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Random
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Fire Dice";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Fireball";
        //NewAbility.stats.numberOfSpells = 5;
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 3, abilityBaseDamageType = SpellStats.AbilitySchool.Fire });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Fire;
        //NewAbility.stats.abilityBaseRangeMaximum = 10f;
        //NewAbility.stats.abilityBaseCooldown = 3f;
        //NewAbility.stats.abilityBaseDuration = 5f;
        //NewAbility.stats.abilityBaseCastTime = 1.5f;
        //NewAbility.stats.abilityBaseSpeed = 20f;
        //NewAbility.stats.randomLow = 1;
        //NewAbility.stats.randomHigh = 6;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage
        //};

        //newStatus.statusName = "Burn";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusIsToggle = false;
        //newStatus.statusBaseDuration = 3f;
        //newStatus.statusBaseInterval = 1f;
        //newStatus.statusBaseTicks = 3f;
        //newStatus.statusBaseDamage = 1;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Fire;
        //newStatus.statusClassification = RootStatus.StatusClassification.Burn;
        //newStatus.statusBaseStatusChance = 15;
        //newStatus.statusBaseEffect = "None";
        //newStatus.multiUnitStackable = true;
        //newStatus.stackable = true;
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateImmolate()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Fire,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Duration
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Immolate";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Mage/Immolate";
        ////NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Fire });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Fire;
        //NewAbility.stats.abilityBaseRangeMaximum = 10;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage
        //};

        //newStatus.statusName = "Immolation";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 5f;
        //newStatus.statusBaseInterval = 1f;
        //newStatus.statusBaseTicks = 5f;
        //newStatus.statusBaseDamage = 3;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Fire;
        //newStatus.statusClassification = RootStatus.StatusClassification.Burn;
        //newStatus.statusBaseStatusChance = 100;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateConflagration()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.Area,
        //    AbilityTags.AbilityTag.Fire,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Knockback
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Conflagration";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityRequiresLos = false;
        //NewAbility.stats.numberOfSpells = 1;
        //NewAbility.stats.abilityBaseCost = 0;
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 50, abilityBaseDamageType = SpellStats.AbilitySchool.Fire });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Fire;
        //NewAbility.stats.abilityBaseRangeMinimum = 0;
        //NewAbility.stats.abilityBaseRangeMaximum = 0;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 2f;
        //NewAbility.stats.abilityBaseArea = 5f;
        //NewAbility.stats.abilityBaseForce = 300f;

        return NewAbility;
    }

    //Water
    public static RootAbility CreateSpeedBoost()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Utility,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Water,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Buff
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Speed";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Utility });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Water;
        //NewAbility.stats.abilityBaseRangeMaximum = 10;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Buff
        //};

        //newStatus.statusName = "Speed";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusIsToggle = false;
        //newStatus.statusBaseDuration = 5f;
        //newStatus.statusBaseInterval = 5f;
        //newStatus.statusBaseTicks = 1;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Utility;
        //newStatus.statusClassification = RootStatus.StatusClassification.Enhancement;
        //newStatus.statusBaseEffect = "None";
        //newStatus.statusStatsToModify.Add(new Modifier() { Mod = Modifier.StatModifiers.BonusMoveSpeedPercent, ModAmount = 1.5f });
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Self;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateCleanse()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Utility,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Water
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Cleanse";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Water });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Water;
        //NewAbility.stats.abilityBaseRangeMaximum = 15;
        //NewAbility.stats.abilityBaseCooldown = 15f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.statusName = "Cleanse";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Water;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;
        //newStatus.hasSpecialEffect = true;

        //Cleanse newEffect = new Cleanse();
        //NewAbility.stats.specialEffects.Add(newEffect);
        //newEffect.specialEffectName = "Cleanse";

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    //Nature
    

    //Air
    public static RootAbility CreateCloudBurst()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Utility,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Ethereal,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Buff
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Rile Soul";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/Buff";
        //NewAbility.stats.abilityRequiresLos = false;
        //NewAbility.stats.numberOfSpells = 1;
        //NewAbility.stats.abilityBaseCost = 0;
        //NewAbility.stats.abilityBaseDamage = 0;
        //NewAbility.stats.abilityBaseDamageType = SpellStats.AbilitySchool.Ethereal;
        //NewAbility.stats.abilityBaseRangeMinimum = 0;
        //NewAbility.stats.abilityBaseRangeMaximum = 0;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //NewAbility.stats.abilityBaseArea = 0;
        //NewAbility.stats.abilityBaseCollisionRadius = .5f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.statusName = "Rile Soul";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 5f;
        //newStatus.statusBaseInterval = 5f;
        //newStatus.statusBaseTicks = 1f;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Ethereal;
        //newStatus.statusBaseEffect = "None";
        //newStatus.statusStatsToModify.Add(Modifier.StatModifiers.BonusDamagePercent);
        //newStatus.statusStatModifyAmount = 1.2f;
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Self;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateLightningStrike()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.Air,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Spell
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Lightning Strike";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Druid/LightningStrike";
        //NewAbility.stats.abilityRequiresLos = true;
        //NewAbility.stats.numberOfSpells = 1;
        //NewAbility.stats.abilityBaseCost = 0;
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 10, abilityBaseDamageType = SpellStats.AbilitySchool.Air });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Air;
        //NewAbility.stats.abilityBaseRangeMinimum = 0;
        //NewAbility.stats.abilityBaseRangeMaximum = 10f;
        //NewAbility.stats.abilityBaseCooldown = 0f;
        //NewAbility.stats.abilityBaseDuration = 0f;
        //NewAbility.stats.abilityBaseCastTime = .5f;
        //NewAbility.stats.abilityBaseArea = 0;
        return NewAbility;
    }

    //Ethereal
    public static RootAbility CreateRileSoul()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Utility,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.Ethereal,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Buff
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Rile Soul";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Ethereal });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Ethereal;
        //NewAbility.stats.abilityBaseRangeMaximum = 10;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseCastTime = 1f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.statusName = "Rile Soul";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 5f;
        //newStatus.statusBaseInterval = 5f;
        //newStatus.statusBaseTicks = 1f;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Ethereal;
        //newStatus.statusClassification = RootStatus.StatusClassification.Enhancement;
        //newStatus.statusBaseEffect = "None";
        //newStatus.statusStatsToModify.Add(new Modifier() { Mod = Modifier.StatModifiers.BonusDamagePercent, ModAmount = 1.2f });
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Self;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    public static RootAbility CreateRipSoul()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.Channel,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Ethereal
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Rip Soul";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Adherent/RipSoul";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 5, abilityBaseDamageType = SpellStats.AbilitySchool.Ethereal });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Ethereal;
        //NewAbility.stats.abilityBaseRangeMaximum = 10;
        //NewAbility.stats.abilityBaseCooldown = 10f;
        //NewAbility.stats.abilityBaseCastTime = 4f;
        //NewAbility.stats.abilityBaseInterval = .4f;

        return NewAbility;
    }

    public static RootAbility CreateWeaken()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Debuff,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.ImmediateTravel,
        //    AbilityTags.AbilityTag.SingleTarget,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Ethereal
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Weaken";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Civilian/Buff";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 0, abilityBaseDamageType = SpellStats.AbilitySchool.Ethereal });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Ethereal;
        //NewAbility.stats.abilityBaseRangeMaximum = 10;
        //NewAbility.stats.abilityBaseCooldown = 10f;
        //NewAbility.stats.abilityBaseCastTime = 1.5f;
        //RootStatus newStatus = new RootStatus();

        //newStatus.AbilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Debuff
        //};

        //newStatus.statusName = "Weak";
        //newStatus.statusID = Random.Range(int.MinValue, int.MaxValue);
        //newStatus.statusBaseDuration = 25f;
        //newStatus.statusBaseInterval = 25f;
        //newStatus.statusBaseTicks = 1f;
        //newStatus.statusBaseDamageType = SpellStats.AbilitySchool.Ethereal;
        //newStatus.statusClassification = RootStatus.StatusClassification.Curse;
        //newStatus.statusBaseStatusChance = 100;
        //newStatus.statusBaseEffect = "None";
        //newStatus.whoShouldITarget = RootStatus.StatusTarget.Target;

        //NewAbility.stats.Statuses.Add(newStatus);
        return NewAbility;
    }

    //Astral
    public static RootAbility CreateRift()
    {
        RootAbility NewAbility = new RootAbility();

        //NewAbility.stats.abilityTags = new List<AbilityTags.AbilityTag>
        //{
        //    AbilityTags.AbilityTag.Damage,
        //    AbilityTags.AbilityTag.CastTime,
        //    AbilityTags.AbilityTag.Spell,
        //    AbilityTags.AbilityTag.Area,
        //    AbilityTags.AbilityTag.Astral,
        //    AbilityTags.AbilityTag.Projectile,
        //    AbilityTags.AbilityTag.HandCast,
        //    AbilityTags.AbilityTag.Pulse
        //};

        //NewAbility.abilityID = Random.Range(int.MinValue, int.MaxValue);
        //NewAbility.stats.abilityName = "Rift";
        //NewAbility.stats.abilityPrefabLocation = "Prefabs/Spells/ClassSpells/BaseClasses/Adherent/Astromancer/Rift";
        //NewAbility.stats.abilityDamageComponents.Add(new Damage() { baseDamage = 5, abilityBaseDamageType = SpellStats.AbilitySchool.Astral });
        //NewAbility.stats.abilitySchool = SpellStats.AbilitySchool.Astral;
        //NewAbility.stats.abilityBaseRangeMaximum = 15f;
        //NewAbility.stats.abilityBaseCooldown = 1f;
        //NewAbility.stats.abilityBaseDuration = 10f;
        //NewAbility.stats.abilityBasePulseTimer = .2f;
        //NewAbility.stats.abilityBasePulseDamage = 5;
        //NewAbility.stats.abilityBaseCastTime = 2f;
        //NewAbility.stats.abilityBaseArea = 5f;
        //NewAbility.stats.abilityBaseSpeed = 1f;

        return NewAbility;
    }

}