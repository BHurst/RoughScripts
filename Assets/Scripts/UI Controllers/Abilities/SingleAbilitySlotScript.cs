﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SingleAbilitySlotScript : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public RootUnit unit;
    public Ability abilityInSlot;
    public int slotIndex;
    public Image cooldownImage;

    public void PopulateSlot(Ability ability)
    {
        abilityInSlot = ability;
        GetComponentInChildren<Text>().text = ability.abilityName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (characterPanelScripts.heldAbility.heldAbility == null && abilityInSlot != null)//Pick up
            {
                characterPanelScripts.heldAbility.abilityName.text = abilityInSlot.abilityName;
                GetComponentInChildren<Text>().text = "";
                characterPanelScripts.heldAbility.heldAbility = abilityInSlot;
                abilityInSlot = null;
            }
            else if (characterPanelScripts.heldAbility.heldAbility != null && abilityInSlot != null)//Swap
            {
                GetComponentInChildren<Text>().text = characterPanelScripts.heldAbility.abilityName.text;
                characterPanelScripts.heldAbility.abilityName.text = abilityInSlot.abilityName;
                (characterPanelScripts.heldAbility.heldAbility, abilityInSlot) = (abilityInSlot, characterPanelScripts.heldAbility.heldAbility);
            }
            else if (characterPanelScripts.heldAbility.heldAbility != null && abilityInSlot == null)//Put down
            {
                GetComponentInChildren<Text>().text = characterPanelScripts.heldAbility.abilityName.text;
                characterPanelScripts.heldAbility.abilityName.text = "";
                abilityInSlot = characterPanelScripts.heldAbility.heldAbility;
                characterPanelScripts.heldAbility = null;
            }
        }
    }

    private void Update()
    {
        var a = unit.abilitiesOnCooldown.Find(x => x.abilityID == abilityInSlot.abilityID);
        if (a != null)
        {
            if (a.cooldown > unit.globalCooldown)
                cooldownImage.fillAmount = 1 - (a.cooldown / a.aCastModeRune.Cooldown());
            else
                cooldownImage.fillAmount = 1 - unit.globalCooldown;
        }
        else if(unit.globalCooldown > 0)
        {
            cooldownImage.fillAmount = 1 - unit.globalCooldown;
        }
        else
            cooldownImage.fillAmount = 1;
    }
}