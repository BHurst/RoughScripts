using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarAbilitySlot : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
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

    public void PopulateSlot(Ability ability)
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
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Ability.NullorUninitialized(characterPanelScripts.heldAbility.ability) && !Ability.NullorUninitialized(slotAbilityImage.abilityInSlot))//Pick up
            {
                characterPanelScripts.heldAbility.SetImage(slotAbilityImage.abilityInSlot);
                characterPanelScripts.heldAbility.ability = slotAbilityImage.abilityInSlot;
                unit.playerHotbar.RemoveSlot(slotIndex);
                TooltipController.Hide();
            }
            else if (!Ability.NullorUninitialized(characterPanelScripts.heldAbility.ability) && !Ability.NullorUninitialized(slotAbilityImage.abilityInSlot))//Swap
            {
                (characterPanelScripts.heldAbility.ability, slotAbilityImage.abilityInSlot) = (slotAbilityImage.abilityInSlot, characterPanelScripts.heldAbility.ability);
                characterPanelScripts.heldAbility.SetImage(characterPanelScripts.heldAbility.ability);
                unit.playerHotbar.PlaceSlot(slotAbilityImage.abilityInSlot, slotIndex);
                TooltipController.Hide();

            }
            else if (!Ability.NullorUninitialized(characterPanelScripts.heldAbility.ability) && Ability.NullorUninitialized(slotAbilityImage.abilityInSlot))//Put down
            {
                unit.playerHotbar.PlaceSlot(characterPanelScripts.heldAbility.ability, slotIndex);
                characterPanelScripts.heldAbility.ClearImage();
                characterPanelScripts.heldAbility.ability = null;
            }
        }
    }

    private void Update()
    {
        if (!Ability.NullorUninitialized(slotAbilityImage.abilityInSlot))
        {
            var a = unit.abilitiesOnCooldown.Find(x => x.abilityID == slotAbilityImage.abilityInSlot.abilityID);
            if (a != null)
            {
                if (a.cooldown > unit.globalCooldown)
                    cooldownImage.fillAmount = a.cooldown / a.aSchoolRune.baseCooldown;
                else
                    cooldownImage.fillAmount = unit.globalCooldown;
            }
            else if (unit.globalCooldown > 0)
            {
                cooldownImage.fillAmount = unit.globalCooldown;
            }
            else
                cooldownImage.fillAmount = 0;
            if (slotAbilityImage.abilityInSlot.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
            {
                if (dirtyReserve != unit.unitAbilityReserve.CheckReserves(slotAbilityImage.abilityInSlot.aSchoolRune.schoolRuneType))
                {
                    slotAbilityImage.ReserveText.SetText(unit.unitAbilityReserve.CheckReserves(slotAbilityImage.abilityInSlot.aSchoolRune.schoolRuneType).ToString());
                    dirtyReserve = (unit.unitAbilityReserve.CheckReserves(slotAbilityImage.abilityInSlot.aSchoolRune.schoolRuneType));
                }
            }
        }
    }
}