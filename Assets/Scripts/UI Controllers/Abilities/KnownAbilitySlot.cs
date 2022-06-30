using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KnownAbilitySlot : MonoBehaviour, IPointerClickHandler
{
    public AbilityImage abilityImage;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            UIManager.main.heldAbility.SetImage(abilityImage.abilityInSlot);
            UIManager.main.heldAbility.ability = abilityImage.abilityInSlot;
        }
    }
}