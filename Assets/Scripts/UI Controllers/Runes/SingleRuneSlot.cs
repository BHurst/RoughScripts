using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SingleRuneSlot : MonoBehaviour, IPointerClickHandler
{
    public AbilityRunePane abilityRunePane;
    public int runeIndex;
    public Rune rune;

    private void Start()
    {
        abilityRunePane = GameObject.Find("CharacterAbilityBook").GetComponent<AbilityRunePane>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(rune is FormRune form)
            {
                abilityRunePane.FormRuneIcon.text = rune.runeName;
                abilityRunePane.ActiveFormRune = form;
            }
            else if (rune is CastModeRune cast)
            {
                abilityRunePane.CastModeRuneIcon.text = rune.runeName;
                abilityRunePane.ActiveCastModeRune = cast;
            }
            else if (rune is SchoolRune school)
            {
                abilityRunePane.SchoolRuneIcon.text = rune.runeName;
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