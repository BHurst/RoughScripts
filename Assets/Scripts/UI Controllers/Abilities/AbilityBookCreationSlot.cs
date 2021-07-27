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
}