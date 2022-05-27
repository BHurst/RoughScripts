using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3Talent : BaseTalent
{
    public RootCharacter owner;
    public string talentDescription = "Placeholder Description.";
    public Tier3TalentTrigger trigger = Tier3TalentTrigger.None;

    public virtual void Effect(object sender, WorldAbility worldAbility)
    {
        //Ensure when making a new ability, that all of the damage mods, eg.
        //  ctAbility.aSchoolRune.schoolDamageMod = 1;
        //  ctAbility.aFormRune.formDamageMod = 1;
        //Are set to one and the override damage
        //  ctAbility.overrideDamage = 1;
        //is set to ensure that an absolute value is used
    }
    public virtual void ActivateTalent()
    {
        
    }

    public virtual void DeactivateTalent()
    {
        
    }
}

public enum Tier3TalentTrigger
{
    SpellHittingTarget,
    None
}