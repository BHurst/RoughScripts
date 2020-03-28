using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot {

    public int slotIndex;
    public int middleManAbilityId;
    public bool hasAbility = false;
    public int abilityInSlotId = 0;
    public Sprite abilityInSlotImage;

    public void SelfPop(int id)
    {
        abilityInSlotId = id;
        hasAbility = true;
        GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = id;
        GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].hasAbility = true;
    }

    public void SlotClick()
    {
        if (GameWorldReferenceClass.HeldAbility.hasAbility == true)
        {
            if (hasAbility)
            {
                middleManAbilityId = GameWorldReferenceClass.HeldAbility.abilityInSlotId;
                GameWorldReferenceClass.HeldAbility.abilityInSlotId = GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = middleManAbilityId;
            }
            else
            {
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = GameWorldReferenceClass.HeldAbility.abilityInSlotId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].hasAbility = true;
                GameWorldReferenceClass.HeldAbility.abilityInSlotId = 0;
                GameWorldReferenceClass.HeldAbility.hasAbility = false;
            }
            HotbarPane.RefreshHotbar();
        }
        else
        {
            if (hasAbility)
            {
                GameWorldReferenceClass.GW_Player.CastCheck(GameWorldReferenceClass.GetAbilityFromId(GameWorldReferenceClass.GW_Player, abilityInSlotId));
            }
        }
    }

    public void SlotDrag()
    {
        if (GameWorldReferenceClass.HeldAbility.hasAbility == false)
        {
            if (hasAbility)
            {
                GameWorldReferenceClass.HeldAbility.abilityInSlotId = GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId;
                GameWorldReferenceClass.HeldAbility.hasAbility = true;
                CharacterAbilitiesPane.previousHotbarSlot = slotIndex;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = 0;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].hasAbility = false;
                HotbarPane.RefreshHotbar();
            }
        }
    }

    public void SlotDrop()
    {
        if (GameWorldReferenceClass.HeldAbility.hasAbility == true)
        {
            if (hasAbility)
            {
                middleManAbilityId = GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = GameWorldReferenceClass.HeldAbility.abilityInSlotId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[CharacterAbilitiesPane.previousHotbarSlot].abilityInSlotId = middleManAbilityId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[CharacterAbilitiesPane.previousHotbarSlot].hasAbility = true;
                GameWorldReferenceClass.HeldAbility.abilityInSlotId = 0;
                GameWorldReferenceClass.HeldAbility.hasAbility = false;
                HotbarPane.RefreshHotbar();
            }
            else
            {
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].abilityInSlotId = GameWorldReferenceClass.HeldAbility.abilityInSlotId;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[slotIndex].hasAbility = true;
                GameWorldReferenceClass.GW_Player.hotbarAbilities[CharacterAbilitiesPane.previousHotbarSlot].hasAbility = false;
                GameWorldReferenceClass.HeldAbility.abilityInSlotId = 0;
                GameWorldReferenceClass.HeldAbility.hasAbility = false;
                HotbarPane.RefreshHotbar();
            }
        }
    }
}