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
    public Ability abilityInSlot;

    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
    }

    public void SetTooltipInfo(RootCharacter unit)
    {
        tooltipInfo.headerContent = abilityInSlot.abilityName;
        tooltipInfo.shorthandContent = abilityInSlot.GetCost().ToString() + " Mana\n" + unit.totalStats.GetUnitCastTime(abilityInSlot) + "s cast time\nRank: " + abilityInSlot.aSchoolRune.rank;
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
    }
    public void Populate(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.runeImageLocation);
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.runeImageLocation);

        if(ability.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Reserve)
        {
            ReserveText.gameObject.SetActive(true);
            ReserveText.SetText(PlayerCharacterUnit.player.totalStats.CheckReserves(ability.aSchoolRune.schoolRuneType).ToString());
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