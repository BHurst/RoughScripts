using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityBookCreationSlot : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public RootUnit unit;
    public Ability abilityInSlot;
    public RuneSlotImage slotImage;

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
}