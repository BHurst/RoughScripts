using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SingleRuneSlot : MonoBehaviour, IPointerClickHandler
{
    public AbilityRunePane abilityRunePane;
    public UITooltipTrigger tooltipInfo;
    public int runeIndex;
    public Rune rune;

    private void Start()
    {
        abilityRunePane = GameObject.Find("CharacterAbilityRuneCanvas").GetComponent<AbilityRunePane>();
    }
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
    }

    public void SetTooltipInfo()
    {
        tooltipInfo.headerContent = rune.runeName;
        tooltipInfo.shorthandContent = "Empty for now";
        tooltipInfo.bodyContent = rune.runeDescription;

        tooltipInfo.tertiaryContent = "Also empty for now";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(rune is FormRune form)
            {
                abilityRunePane.FormRuneIcon.sprite = Resources.Load<Sprite>(rune.runeImageLocation);
                abilityRunePane.ActiveFormRune = form;
            }
            else if (rune is CastModeRune cast)
            {
                abilityRunePane.CastModeRuneIcon.sprite = Resources.Load<Sprite>(rune.runeImageLocation);
                abilityRunePane.ActiveCastModeRune = cast;
            }
            else if (rune is SchoolRune school)
            {
                abilityRunePane.SchoolRuneIcon.sprite = Resources.Load<Sprite>(rune.runeImageLocation);
                abilityRunePane.ActiveSchoolRune = school;
            }
            else if (rune is EffectRune effect)
            {
                abilityRunePane.EffectRuneIcon.text = rune.runeName;
                abilityRunePane.ActiveEffectRune = effect;
            }
        }
    }
}