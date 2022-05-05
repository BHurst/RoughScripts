using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SingleAbilitySlotScript : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public PlayerCharacterUnit unit;
    public Ability abilityInSlot;
    public int slotIndex;
    public Image cooldownImage;
    public RuneSlotImage slotImage;
    int dirtyCharges = -1;

    private void Awake()
    {
        unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
    }

    public void PopulateSlot(Ability ability)
    {
        abilityInSlot = ability;
        slotImage.SetImage(abilityInSlot);
    }

    public void DepopulateSlot()
    {
        abilityInSlot = null;
        slotImage.ClearImage();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if ((characterPanelScripts.heldAbility.ability == null || !characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Pick up
            {
                characterPanelScripts.heldAbility.gameObject.SetActive(true);
                characterPanelScripts.heldAbility.SetImage(abilityInSlot);
                characterPanelScripts.heldAbility.ability = abilityInSlot;
                unit.playerHotbar.RemoveSlot(slotIndex);
            }
            else if ((characterPanelScripts.heldAbility.ability != null && characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Swap
            {
                slotImage.SetImage(characterPanelScripts.heldAbility.ability);
                characterPanelScripts.heldAbility.SetImage(abilityInSlot);
                (characterPanelScripts.heldAbility.ability, abilityInSlot) = (abilityInSlot, characterPanelScripts.heldAbility.ability);
                unit.playerHotbar.PlaceSlot(abilityInSlot, slotIndex);

            }
            else if ((characterPanelScripts.heldAbility.ability != null && characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot == null || !abilityInSlot.initialized))//Put down
            {
                unit.playerHotbar.PlaceSlot(characterPanelScripts.heldAbility.ability, slotIndex);
                characterPanelScripts.heldAbility.ClearImage();
                characterPanelScripts.heldAbility.ability = null;
                characterPanelScripts.heldAbility.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (abilityInSlot != null && abilityInSlot.initialized)
        {
            var a = unit.abilitiesOnCooldown.Find(x => x.abilityID == abilityInSlot.abilityID);
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
            if (abilityInSlot.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charges)
            {
                if (dirtyCharges != unit.unitAbilityCharges.CheckCharge(abilityInSlot.aSchoolRune.schoolRuneType))
                {
                    slotImage.chargesText.SetText(unit.unitAbilityCharges.CheckCharge(abilityInSlot.aSchoolRune.schoolRuneType).ToString());
                    dirtyCharges = (unit.unitAbilityCharges.CheckCharge(abilityInSlot.aSchoolRune.schoolRuneType));
                }
            }
        }
    }
}