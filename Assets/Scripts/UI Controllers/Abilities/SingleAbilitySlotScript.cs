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
    TooltipTrigger tooltipInfo;

    private void Awake()
    {
        tooltipInfo = GetComponent<TooltipTrigger>();
        unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
    }

    public void SetTooltipInfo()
    {
        tooltipInfo.headerContent = abilityInSlot.abilityName;
        tooltipInfo.shorthandContent = abilityInSlot.GetCost().ToString() + " Mana\n" + unit.totalStats.GetUnitCastTime(abilityInSlot) + "s cast time";
        tooltipInfo.bodyContent = "Deals " + DamageManager.TooltipAbilityDamage(unit.totalStats, abilityInSlot).ToString() + " " + abilityInSlot.aSchoolRune.schoolRuneType + " damage.";

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

    public void PopulateSlot(Ability ability)
    {
        abilityInSlot = ability;
        slotImage.SetImage(abilityInSlot);
        SetTooltipInfo();
    }

    public void DepopulateSlot()
    {
        abilityInSlot = null;
        slotImage.ClearImage();
        tooltipInfo.Clear();
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