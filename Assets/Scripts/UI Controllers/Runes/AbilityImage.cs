using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityImage : MonoBehaviour
{
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;
    public TMP_Text ReserveText;
    public UITooltipTrigger tooltipInfo;
    public BaseAbility abilityInSlot;

    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
    }

    public void SetTooltipInfo(RootCharacter unit)
    {
        tooltipInfo.headerContent = abilityInSlot.abilityName;
        tooltipInfo.shorthandContent = abilityInSlot.GetCost().ToString() + " Mana\n" + unit.totalStats.GetUnitCastTime(abilityInSlot) + "s cast time\nRank: " + abilityInSlot.schoolRune.rank;

        if (abilityInSlot is BasicAbility)
        {
            BasicAbility ability = (BasicAbility)abilityInSlot;
            tooltipInfo.bodyContent = ability.formRune.GetTooltipDescription(unit.totalStats, ability);

            tooltipInfo.tertiaryContent = "";
            if (!BaseAbility.NullorUninitialized(ability.abilityToTrigger))
                tooltipInfo.tertiaryContent += "Will trigger " + ability.abilityToTrigger.abilityName + " on hit.";
        }
        if (abilityInSlot.effectRunes != null && abilityInSlot.effectRunes.Count > 0)
        {
            if (tooltipInfo.tertiaryContent != "")
                tooltipInfo.tertiaryContent += "\n";
            for (int i = 0; i < abilityInSlot.effectRunes.Count; i++)
            {
                tooltipInfo.tertiaryContent += abilityInSlot.effectRunes[i].runeDescription;
                if (i != abilityInSlot.effectRunes.Count - 1)
                    tooltipInfo.tertiaryContent += "\n";
            }
        }
    }

    public void SetImage(BaseAbility ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.schoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.castModeRune.runeImageLocation);
        if (ability is BasicAbility)
            formImage.sprite = Resources.Load<Sprite>(((BasicAbility)ability).formRune.runeImageLocation);
    }
    public void Populate(BaseAbility ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.schoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.castModeRune.runeImageLocation);
        if (ability is BasicAbility)
            formImage.sprite = Resources.Load<Sprite>(((BasicAbility)ability).formRune.runeImageLocation);

        if (ability.castModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            ReserveText.gameObject.SetActive(true);
            ReserveText.SetText(PlayerCharacterUnit.player.totalStats.CheckReserves(ability.schoolRune.schoolRuneType).ToString());
        }
        else
        {
            ReserveText.SetText("");
            ReserveText.gameObject.SetActive(false);
        }

        abilityInSlot = ability;
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
        ReserveText.SetText("");
        ReserveText.gameObject.SetActive(false);
        abilityInSlot = null;
    }
}