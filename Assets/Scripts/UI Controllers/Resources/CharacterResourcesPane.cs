using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterResourcesPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Button rerollButton;
    public Button rerollTalentButton;
    public UILocusRuneModification selectedRune;
    public UITalentModificationBase selectedTalent;
    public TextMeshProUGUI dustCount;
    public Resources_SelectLocusRunePane runePane;

    public TMP_Dropdown statDropdown;
    public TMP_Dropdown aspectDropdown;
    public TMP_Dropdown methodDropdown;
    public TMP_InputField valueInput;
    public Button customTalentButton;

    public GameObject AddT1Button;
    public GameObject AddT2Button;
    public GameObject AddT3Button;
    public GameObject RemoveTalentButton;

    void Start()
    {
        mainPanel.transform.position = transform.position;
        mainPanel.SetActive(false);
        selectedTalent = null;
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        runePane.DisplayAvailableRunes();
        DisplayDust();
        DisplayAllRuneOptions();
    }

    public void DisplayAllRuneOptions()
    {
        List<string> stats = new List<string>();
        stats.Add("None");
        List<string> aspects = new List<string>();
        aspects.Add("None");
        List<string> methods = new List<string>();
        methods.Add("None");
        foreach (var item in GameWorldReferenceClass.validStats)
        {
            if (!stats.Contains(item.stat.ToString()))
                stats.Add(item.stat);
            if (!aspects.Contains(item.aspect.ToString()))
                aspects.Add(item.aspect);
            if (!methods.Contains(item.method.ToString()) && item.method != "")
                methods.Add(item.method);
        }
        statDropdown.ClearOptions();
        aspectDropdown.ClearOptions();
        methodDropdown.ClearOptions();
        statDropdown.AddOptions(stats);
        aspectDropdown.AddOptions(aspects);
        methodDropdown.AddOptions(methods);
    }

    public void FilterRuneStat()
    {
        List<string> stats = new List<string>();
        string selectedStat = statDropdown.options[statDropdown.value].text;
        string selectedAspect = aspectDropdown.options[aspectDropdown.value].text;
        string selectedMethod = methodDropdown.options[methodDropdown.value].text;
        stats.Add("None");

        foreach (var item in GameWorldReferenceClass.validStats)
        {
            if ((item.aspect == selectedAspect || selectedAspect == "None") && (item.method == selectedMethod || selectedMethod == "None"))
            {
                if (!stats.Contains(item.stat.ToString()))
                    stats.Add(item.stat);
            }
        }

        statDropdown.ClearOptions();
        statDropdown.AddOptions(stats);
        int index = statDropdown.options.FindIndex(x => x.text == selectedStat);
        if (index != -1)
            statDropdown.SetValueWithoutNotify(index);
        else
            statDropdown.SetValueWithoutNotify(0);
    }

    public void FilterRuneAspect()
    {
        List<string> aspects = new List<string>();
        string selectedStat = statDropdown.options[statDropdown.value].text;
        string selectedAspect = aspectDropdown.options[aspectDropdown.value].text;
        string selectedMethod = methodDropdown.options[methodDropdown.value].text;
        aspects.Add("None");
        foreach (var item in GameWorldReferenceClass.validStats)
        {
            if ((item.stat == selectedStat || selectedStat == "None") && (item.method == selectedMethod || selectedMethod == "None"))
            {
                if (!aspects.Contains(item.aspect.ToString()))
                    aspects.Add(item.aspect);
            }
        }
        aspectDropdown.ClearOptions();
        aspectDropdown.AddOptions(aspects);
        int index = aspectDropdown.options.FindIndex(x => x.text == selectedAspect);
        if (index != -1)
            aspectDropdown.SetValueWithoutNotify(index);
        else
            aspectDropdown.SetValueWithoutNotify(0);
    }

    public void FilterRuneMethod()
    {
        List<string> methods = new List<string>();
        string selectedStat = statDropdown.options[statDropdown.value].text;
        string selectedAspect = aspectDropdown.options[aspectDropdown.value].text;
        string selectedMethod = methodDropdown.options[methodDropdown.value].text;
        methods.Add("None");
        foreach (var item in GameWorldReferenceClass.validStats)
        {
            if ((item.stat == selectedStat || selectedStat == "None") && (item.aspect == selectedAspect || selectedAspect == "None"))
            {
                if (!methods.Contains(item.method.ToString()) && item.method != "")
                    methods.Add(item.method);
            }
        }
        methodDropdown.ClearOptions();
        methodDropdown.AddOptions(methods);
        int index = methodDropdown.options.FindIndex(x => x.text == selectedMethod);
        if (index != -1)
            methodDropdown.SetValueWithoutNotify(index);
        else
            methodDropdown.SetValueWithoutNotify(0);
    }

    public void ShowCustomTalentButton()
    {
        if (statDropdown.options[statDropdown.value].text != "None" && aspectDropdown.options[aspectDropdown.value].text != "None" && methodDropdown.options[methodDropdown.value].text != "None" && !string.IsNullOrEmpty(valueInput.text))
            customTalentButton.gameObject.SetActive(true);
        else
            customTalentButton.gameObject.SetActive(false);
    }
    public void Hide()
    {
        mainPanel.SetActive(false);
        runePane.ClearSelected();
        if (selectedTalent != null)
            selectedTalent.Deselect();
        HideButtons();
    }

    private void HideButtons()
    {
        AddT1Button.SetActive(false);
        AddT2Button.SetActive(false);
        AddT3Button.SetActive(false);
        RemoveTalentButton.SetActive(false);
    }

    private void DisplaySpecificButtons()
    {
        if (selectedTalent != null)
            RemoveTalentButton.SetActive(true);
        else
            RemoveTalentButton.SetActive(false);

        if (selectedRune.LocusRune.Tier1Talents.Count < LocusRune.maxTier1Talents)
            AddT1Button.SetActive(true);
        else
            AddT1Button.SetActive(false);
        if (selectedRune.LocusRune.Tier2Talents.Count < LocusRune.maxTier2Talents)
            AddT2Button.SetActive(true);
        else
            AddT2Button.SetActive(false);
        if (selectedRune.LocusRune.Tier3Talents.Count < LocusRune.maxTier3Talents)
            AddT3Button.SetActive(true);
        else
            AddT3Button.SetActive(false);
    }

    public void AddSpecificT1Talent()
    {
        ValidStatCombo combo = new ValidStatCombo();
        combo.stat = statDropdown.options[statDropdown.value].text;
        combo.aspect = aspectDropdown.options[aspectDropdown.value].text;
        combo.method = methodDropdown.options[methodDropdown.value].text;
        if (GameWorldReferenceClass.validStats.Exists(x => x.stat == combo.stat && x.aspect == combo.aspect && x.method == combo.method))
        {
            Tier1Talent newTalent = new Tier1Talent();
            newTalent.TalentId = Guid.NewGuid();
            newTalent.cost = 1;
            newTalent.tier = BaseTalent.Tier.tier1;
            newTalent.modifier.Stat = (ModifierGroup.EStat)Enum.Parse(typeof(ModifierGroup.EStat), combo.stat);
            newTalent.modifier.Aspect = (ModifierGroup.EAspect)Enum.Parse(typeof(ModifierGroup.EAspect), combo.aspect);
            newTalent.modifier.Method = (ModifierGroup.EMethod)Enum.Parse(typeof(ModifierGroup.EMethod), combo.method);
            newTalent.modifier.Value = int.Parse(valueInput.text);
            newTalent.talentName = newTalent.modifier.ReadableName();

            selectedRune.LocusRune.PlaceT1Rune(newTalent);
            selectedRune.SetRune(selectedRune.LocusRune);
        }
    }

    public void DisplayDust()
    {
        dustCount.SetText(PlayerCharacterUnit.player.playerResources.magicDust + " Magic Dust");
    }

    public void RerollLocusRune()
    {
        if (PlayerCharacterUnit.player.playerResources.CostCheck(10))
        {
            selectedRune.SetRune(LocusRune.RandomRune());
            if (selectedTalent != null)
            {
                selectedTalent.Deselect();
            }
            selectedTalent = null;
            PlayerCharacterUnit.player.playerResources.magicDust -= 10;
            DisplayDust();
            DisplaySpecificButtons();
        }
        else
            ErrorScript.DisplayError("Not enough dust");
    }

    public void SetSelectedTalent(UITalentModificationBase pickedTalent)
    {
        if (selectedTalent == pickedTalent)
        {
            pickedTalent.Deselect();
            selectedTalent = null;
            DisplaySpecificButtons();
        }
        else
        {
            if (selectedTalent != null)
            {
                selectedTalent.Deselect();
            }
            selectedTalent = pickedTalent;
            DisplaySpecificButtons();
        }
    }

    public void Rerolltalent()
    {
        if (selectedTalent != null)
        {
            if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier1 && PlayerCharacterUnit.player.playerResources.CostCheck(2))
            {
                PlayerCharacterUnit.player.playerResources.magicDust -= 2;
                RerollTier1Talent();
                DisplayDust();
            }
            else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier2 && PlayerCharacterUnit.player.playerResources.CostCheck(4))
            {
                PlayerCharacterUnit.player.playerResources.magicDust -= 4;
                RerollTier2Talent();
                DisplayDust();
            }
            else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier3 && PlayerCharacterUnit.player.playerResources.CostCheck(8))
            {
                PlayerCharacterUnit.player.playerResources.magicDust -= 8;
                RerollTier3Talent();
                DisplayDust();
            }
            else
                ErrorScript.DisplayError("Not enough dust");
        }
    }

    void RerollTier1Talent()
    {
        ((UITier1TalentModification)selectedTalent).Initialize(Tier1Talent.NewRandomTier1Talent());
    }

    public void AddTier1Talent()
    {
        selectedRune.LocusRune.PlaceT1Rune(Tier1Talent.NewRandomTier1Talent());
        selectedRune.SetRune(selectedRune.LocusRune);
        DisplaySpecificButtons();
    }

    void RerollTier2Talent()
    {
        ((UITier2TalentModification)selectedTalent).Initialize(Tier2Talent.NewRandomTier2Talent());
    }

    public void AddTier2Talent()
    {
        selectedRune.LocusRune.PlaceT2Rune(Tier2Talent.NewRandomTier2Talent());
        selectedRune.SetRune(selectedRune.LocusRune);
        DisplaySpecificButtons();
    }

    void RerollTier3Talent()
    {

    }

    public void AddTier3Talent()
    {

    }

    public void RemoveTalent()
    {
        if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier1)
        {
            selectedRune.LocusRune.RemoveT1Rune((Tier1Talent)(selectedTalent.talentInSlot));
        }
        else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier2)
        {
            selectedRune.LocusRune.RemoveT2Rune((Tier2Talent)(selectedTalent.talentInSlot));
        }
        else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier3)
        {
        }

        selectedRune.SetRune(selectedRune.LocusRune);
        selectedTalent.Deselect();
        selectedTalent = null;
        DisplaySpecificButtons();
    }
}