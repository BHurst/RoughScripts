using System.Collections;
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
    public RuneSlotImage slotImage;
    int dirtyCharges = -1;

    public void PopulateSlot(Ability ability)
    {
        abilityInSlot = ability;
        slotImage.SetImage(abilityInSlot);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if ((characterPanelScripts.heldAbility.heldAbility == null || !characterPanelScripts.heldAbility.heldAbility.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Pick up
            {
                characterPanelScripts.heldAbility.gameObject.SetActive(true);
                characterPanelScripts.heldAbility.abilityIcon.SetImage(abilityInSlot);
                slotImage.ClearImage();
                characterPanelScripts.heldAbility.heldAbility = abilityInSlot;
                abilityInSlot = null;
            }
            else if ((characterPanelScripts.heldAbility.heldAbility != null && characterPanelScripts.heldAbility.heldAbility.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Swap
            {
                slotImage.SetImage(characterPanelScripts.heldAbility.heldAbility);
                characterPanelScripts.heldAbility.abilityIcon.SetImage(abilityInSlot);
                (characterPanelScripts.heldAbility.heldAbility, abilityInSlot) = (abilityInSlot, characterPanelScripts.heldAbility.heldAbility);
            }
            else if ((characterPanelScripts.heldAbility.heldAbility != null && characterPanelScripts.heldAbility.heldAbility.initialized) && (abilityInSlot == null || !abilityInSlot.initialized))//Put down
            {
                slotImage.SetImage(characterPanelScripts.heldAbility.heldAbility);
                characterPanelScripts.heldAbility.abilityIcon.ClearImage();
                abilityInSlot = characterPanelScripts.heldAbility.heldAbility;
                characterPanelScripts.heldAbility.heldAbility = null;
                characterPanelScripts.heldAbility.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
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