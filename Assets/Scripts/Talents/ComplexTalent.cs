using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTalent : Talent
{
    public RootUnit owner;
    public string talentDescription = "Placeholder Description.";
    public ComplexTalentTrigger trigger = ComplexTalentTrigger.None;

    public virtual void Effect(object sender, WorldAbility worldAbility)
    {

    }
    public virtual void ActivateTalent()
    {
        
    }

    public virtual void DeactivateTalent()
    {
        
    }
}

public enum ComplexTalentTrigger
{
    SpellHittingTarget,
    None
}