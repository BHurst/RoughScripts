using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityBookCreationSlot : MonoBehaviour, IPointerClickHandler
{
    public CharacterPanelScripts characterPanelScripts;
    public RootCharacter unit;
    public Ability abilityInSlot;
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;
    UITooltipTrigger tooltipInfo;

    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        unit = PlayerCharacterUnit.player;
    }

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
        }
    }

    public void SetTooltipInfo()
    {
        tooltipInfo.headerContent = abilityInSlot.abilityName;
        tooltipInfo.shorthandContent = abilityInSlot.GetCost().ToString() + " Mana\n" + unit.totalStats.GetUnitCastTime(abilityInSlot) + "s cast time";
        tooltipInfo.bodyContent = abilityInSlot.aFormRune.GetTooltipDescription(unit.totalStats, abilityInSlot);

        tooltipInfo.tertiaryContent = "";
        if (!Ability.NullorUninitialized(abilityInSlot.abilityToTrigger))
            tooltipInfo.tertiaryContent += "Will trigger " + abilityInSlot.abilityToTrigger.abilityName + " on hit.";
        if (abilityInSlot.aEffectRunes != null && abilityInSlot.aEffectRunes.Count > 0)
        {
            if (tooltipInfo.tertiaryContent != "")
                tooltipInfo.tertiaryContent += "\n";
            for (int i = 0; i < abilityInSlot.aEffectRunes.Count; i++)
            {
                tooltipInfo.tertiaryContent += abilityInSlot.aEffectRunes[i].runeDescription;
                if (i != abilityInSlot.aEffectRunes.Count - 1)
                    tooltipInfo.tertiaryContent += "\n";
            }
        }
    }

    public void SetImage(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.runeImageLocation);
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.runeImageLocation);
        SetTooltipInfo();
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
        tooltipInfo.Clear();
    }
}