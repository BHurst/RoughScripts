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
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if ((characterPanelScripts.heldAbility.ability == null || !characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Pick up
            {
                characterPanelScripts.heldAbility.gameObject.SetActive(true);
                characterPanelScripts.heldAbility.SetImage(abilityInSlot);
                ClearImage();
                characterPanelScripts.heldAbility.ability = abilityInSlot;
                abilityInSlot = null;
            }
            else if ((characterPanelScripts.heldAbility.ability != null && characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot != null && abilityInSlot.initialized))//Swap
            {
                SetImage(characterPanelScripts.heldAbility.ability);
                characterPanelScripts.heldAbility.SetImage(abilityInSlot);
                (characterPanelScripts.heldAbility.ability, abilityInSlot) = (abilityInSlot, characterPanelScripts.heldAbility.ability);
            }
            else if ((characterPanelScripts.heldAbility.ability != null && characterPanelScripts.heldAbility.ability.initialized) && (abilityInSlot == null || !abilityInSlot.initialized))//Put down
            {
                SetImage(characterPanelScripts.heldAbility.ability);
                characterPanelScripts.heldAbility.ClearImage();
                abilityInSlot = characterPanelScripts.heldAbility.ability;
                characterPanelScripts.heldAbility.ability = null;
                characterPanelScripts.heldAbility.gameObject.SetActive(false);
            }
        }
    }

    public void SetImage(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.runeImageLocation);
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.runeImageLocation);
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
    }
}