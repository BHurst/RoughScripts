using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_HotColdSwap : ComplexTalent
{
    public CT_HotColdSwap()
    {
        talentDescription = "Casting a fire spell incrases the damage of your next ice spell by 10%. Casting a ice spell incrases the damage of your next fire spell by 10%.";
        trigger = ComplexTalentTrigger.SpellHittingTarget;
    }

    public override void ActivateTalent()
    {
        GlobalEventManager.abilityCastTrigger += Effect;
    }

    public override void DeactivateTalent()
    {
        GlobalEventManager.abilityCastTrigger -= Effect;
    }

    public override void Effect(object sender, WorldAbility worldAbility)
    {
        if (worldAbility.wSchoolRune.schoolRuneType == Rune.SchoolRuneTag.Fire)
        {
            var owner = GameWorldReferenceClass.GetUnitByID(worldAbility.abilityOwner);

            if (owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_FireBoost") != null)
                owner.RemoveStatus(owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_FireBoost"));

            if (owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_IceBoost") == null)
            {
                Status newStatus = new Status()
                {
                    name = "CT_HotColdSwap_IceBoost",
                    maxDuration = 10,
                    modifierGroups = new List<ModifierGroup>(),
                    sourceUnit = owner.unitID,
                };
                newStatus.modifierGroups.Add(new ModifierGroup() { Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Stat = ModifierGroup.EStat.Ice, Value = .1f });
                newStatus.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

                owner.AddStatus(newStatus);
            }
        }
        else if (worldAbility.wSchoolRune.schoolRuneType == Rune.SchoolRuneTag.Ice)
        {
            var owner = GameWorldReferenceClass.GetUnitByID(worldAbility.abilityOwner);

            if (owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_IceBoost") != null)
                owner.RemoveStatus(owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_IceBoost"));

            if (owner.activeStatuses.Find(x => x.name == "CT_HotColdSwap_FireBoost") == null)
            {
                Status newStatus = new Status()
                {
                    name = "CT_HotColdSwap_FireBoost",
                    maxDuration = 10,
                    modifierGroups = new List<ModifierGroup>(),
                    sourceUnit = owner.unitID,
                };
                newStatus.modifierGroups.Add(new ModifierGroup() { Aspect = ModifierGroup.EAspect.Damage, Method = ModifierGroup.EMethod.AddPercent, Stat = ModifierGroup.EStat.Fire, Value = .1f });
                newStatus.imageLocation = worldAbility.wSchoolRune.runeImageLocation;

                owner.AddStatus(newStatus);
            }
        }
    }
}