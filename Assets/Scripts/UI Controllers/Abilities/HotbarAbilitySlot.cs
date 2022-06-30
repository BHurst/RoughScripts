﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarAbilitySlot : MonoBehaviour, IPointerClickHandler
{
    public PlayerCharacterUnit unit;
    public int slotIndex;
    public Image cooldownImage;
    public AbilityImage slotAbilityImage;
    int dirtyReserve = -1;

    private void Awake()
    {
        unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
        slotAbilityImage = GetComponentInChildren<AbilityImage>();
    }

    public void PopulateSlot(RootAbility ability)
    {
        slotAbilityImage.Populate(ability);
        slotAbilityImage.SetTooltipInfo(unit);
    }

    public void DepopulateSlot()
    {
        slotAbilityImage.ClearImage();
        slotAbilityImage.tooltipInfo.Clear();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Cursor.visible)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (RootAbility.NullorUninitialized(UIManager.main.heldAbility.ability) && !RootAbility.NullorUninitialized(slotAbilityImage.abilityInSlot))//Pick up
                {
                    UIManager.main.heldAbility.SetImage(slotAbilityImage.abilityInSlot);
                    UIManager.main.heldAbility.ability = slotAbilityImage.abilityInSlot;
                    unit.playerHotbar.RemoveSlot(slotIndex);
                    UITooltipController.Hide();
                }
                else if (!RootAbility.NullorUninitialized(UIManager.main.heldAbility.ability) && !RootAbility.NullorUninitialized(slotAbilityImage.abilityInSlot))//Swap
                {
                    (UIManager.main.heldAbility.ability, slotAbilityImage.abilityInSlot) = (slotAbilityImage.abilityInSlot, UIManager.main.heldAbility.ability);
                    UIManager.main.heldAbility.SetImage(UIManager.main.heldAbility.ability);
                    unit.playerHotbar.PlaceSlot(slotAbilityImage.abilityInSlot, slotIndex);
                    UITooltipController.Hide();

                }
                else if (!RootAbility.NullorUninitialized(UIManager.main.heldAbility.ability) && RootAbility.NullorUninitialized(slotAbilityImage.abilityInSlot))//Put down
                {
                    unit.playerHotbar.PlaceSlot(UIManager.main.heldAbility.ability, slotIndex);
                    UIManager.main.heldAbility.ClearImage();
                    UIManager.main.heldAbility.ability = null;
                }
            }
        }
    }

    private void Update()
    {
        if (!RootAbility.NullorUninitialized(slotAbilityImage.abilityInSlot))
        {
            var a = unit.abilitiesOnCooldown.Find(x => x.abilityID == slotAbilityImage.abilityInSlot.abilityID);
            if (a != null)
            {
                if (a.cooldown > unit.globalCooldown)
                    cooldownImage.fillAmount = a.cooldown / a.schoolRune.baseCooldown;
                else
                    cooldownImage.fillAmount = unit.globalCooldown;
            }
            else if (unit.globalCooldown > 0)
            {
                cooldownImage.fillAmount = unit.globalCooldown;
            }
            else
                cooldownImage.fillAmount = 0;
            if (slotAbilityImage.abilityInSlot.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            {
                if (dirtyReserve != unit.totalStats.CheckReserves(slotAbilityImage.abilityInSlot.schoolRune.schoolRuneType))
                {
                    slotAbilityImage.ReserveText.SetText(unit.totalStats.CheckReserves(slotAbilityImage.abilityInSlot.schoolRune.schoolRuneType).ToString());
                    dirtyReserve = (unit.totalStats.CheckReserves(slotAbilityImage.abilityInSlot.schoolRune.schoolRuneType));
                }
            }
        }
    }
}