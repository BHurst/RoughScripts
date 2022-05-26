using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISimpleTalent : UITalentBase, IPointerClickHandler
{
    private void Awake()
    {
        tooltipInfo = GetComponent<UITooltipTrigger>();
        outline = GetComponent<Outline>();
        characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialize(SimpleTalent simpleTalent)
    {
        talentInSlot = simpleTalent;
        SetTooltipInfo();
        if (simpleTalent.modifiers[0].Method == ModifierGroup.EMethod.Flat)
        text.SetText("+");
        else if (simpleTalent.modifiers[0].Method == ModifierGroup.EMethod.AddPercent)
            text.SetText("%");
        else if (simpleTalent.modifiers[0].Method == ModifierGroup.EMethod.MultiplyPercent)
            text.SetText("%");

        if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Air)
            background.color = Color.white;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Arcane)
            background.color = Color.magenta;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Astral)
            background.color = Color.yellow;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Earth)
            background.color = Color.grey;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Electricity)
            background.color = Color.yellow;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Ethereal)
            background.color = Color.cyan;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Fire)
            background.color = Color.red;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Ice)
            background.color = Color.cyan;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Kinetic)
            background.color = Color.gray;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Life)
            background.color = Color.green;
        else if (simpleTalent.modifiers[0].Stat == ModifierGroup.EStat.Water)
            background.color = Color.blue;
    }

    public void SetTooltipInfo()
    {
        if (tooltipInfo == null)
            tooltipInfo = GetComponent<UITooltipTrigger>();

        SimpleTalent simpleTalent = (SimpleTalent)talentInSlot;

        tooltipInfo.headerContent = simpleTalent.talentName;
        tooltipInfo.shorthandContent = simpleTalent.cost.ToString();
        tooltipInfo.bodyContent = "";
        for (int i = 0; i < simpleTalent.modifiers.Count; i++)
        {
            tooltipInfo.bodyContent += simpleTalent.modifiers[i].ReadableName();
            if (i < simpleTalent.modifiers.Count)
                tooltipInfo.bodyContent += "\n";
        }
        
        tooltipInfo.tertiaryContent = "";
    }

    public override void Toggle()
    {
        SimpleTalent simpleTalent = (SimpleTalent)talentInSlot;

        if (active)
        {
            GameWorldReferenceClass.GW_Player.simpleTalents.Add(simpleTalent);
            foreach (var modifier in simpleTalent.modifiers)
            {
                GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(modifier.Stat, modifier.Aspect, modifier.Method, modifier.Value);
            }
            characterTalents.UpdatePoints(simpleTalent.cost);
            active = false;
            outline.enabled = false;
        }
        else
        {
            if (simpleTalent.cost > GameWorldReferenceClass.GW_Player.level.availableTalentPoints)
            {
                ErrorScript.DisplayError("Not enough talent points");
            }
            else
            {
                GameWorldReferenceClass.GW_Player.simpleTalents.Remove(simpleTalent);
                foreach (var modifier in simpleTalent.modifiers)
                {
                    GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(modifier.Stat, modifier.Aspect, modifier.Method, modifier.Value);
                }
                characterTalents.UpdatePoints(-simpleTalent.cost);
                active = true;
                outline.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }
}