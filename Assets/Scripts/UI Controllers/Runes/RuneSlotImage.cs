using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RuneSlotImage : MonoBehaviour
{
    public Image schoolImage;
    public Image castModeImage;
    public Image formImage;
    public TMP_Text chargesText;

    public Ability abilityInSlot;

    public void SetImage(Ability ability)
    {
        schoolImage.sprite = Resources.Load<Sprite>(ability.aSchoolRune.runeImageLocation);
        castModeImage.sprite = Resources.Load<Sprite>(ability.aCastModeRune.runeImageLocation);
        formImage.sprite = Resources.Load<Sprite>(ability.aFormRune.runeImageLocation);

        if(ability.aCastModeRune.castModeRuneType == Rune.CastModeRuneTag.Charges)
        {
            chargesText.gameObject.SetActive(true);
            chargesText.SetText(GameWorldReferenceClass.GW_Player.unitAbilityCharges.CheckCharge(ability.aSchoolRune.schoolRuneType).ToString());
        }
        else
        {
            chargesText.SetText("");
            chargesText.gameObject.SetActive(false);
        }

        abilityInSlot = ability;
    }

    public void ClearImage()
    {
        schoolImage.sprite = null;
        castModeImage.sprite = null;
        formImage.sprite = null;
        chargesText.SetText("");
        chargesText.gameObject.SetActive(false);
        abilityInSlot = null;
    }
}