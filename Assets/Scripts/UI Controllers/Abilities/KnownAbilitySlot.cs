using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KnownAbilitySlot : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public AbilityImage abilityImage;

    private void Start()
    {
        characterPanelScripts = GameObject.Find("UIController").GetComponent<CharacterPanelScripts>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            characterPanelScripts.heldAbility.SetImage(abilityImage.abilityInSlot);
            characterPanelScripts.heldAbility.ability = abilityImage.abilityInSlot;
        }
    }
}