using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RootStatus {

    public enum StatusTarget
    {
        Self,
        Target,
        Ground
    }

    public enum ChargesRemovedBy
    {
        AnyAbility,
        CastSpell,
        CastAttack,
        DoDamage,
        Nothing,
        TakeDamage,
        TakeSpell,
        TakeAttack,
    }

    public enum StatusClassification
    {
        Ailment,
        Bleed,
        Blessing,
        Block,
        Burn,
        Curse,
        Debilitate,
        Detriment,
        Enhancement,
        Gear,
        Imbue,
        None,
        Poison,
        Shield,
        Unstable,
        Weave
    }

    public int statusID = 0;
    public string statusName = "None";
    public string statusOwner = "Chaotic Energies";
    public bool statusIsToggle = false;
    public float statusBaseDuration = 0;
    public float statusBaseCharges = 0;
    public ChargesRemovedBy statusChargesRemoval = ChargesRemovedBy.Nothing;
    public float statusHealthChangePerSecond = 0;
    public float statusWeaponModifier = 0;
    public float statusSpellModifier = 0;
    public SpellStats.AbilitySchool statusBaseDamageType;
    public List<AbilityTags.AbilityTag> AbilityTags = new List<AbilityTags.AbilityTag>();
    public StatusClassification statusClassification = StatusClassification.None;
    public float statusBaseStatusChance = 100;
    public string statusBaseEffect = "";
    public List<Modifier> statusStatsToModify = new List<Modifier>();
    public bool multiUnitStackable = false;
    public bool stackable = false;
    public StatusTarget whoShouldITarget;
    public bool hasSpecialEffect = false;
    public List<ISpecialEffect> specialEffects;
    public RootUnit statusTarget;

    public void ActivateEffect()
    {
        
    }
}