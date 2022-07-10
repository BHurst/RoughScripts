using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterResourcesPane : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject creationPanel;
    public Button rerollButton;
    public Button rerollTalentButton;
    public Button addCustomTalentButton;
    public UILocusRuneModification selectedRune;
    public UITalentModificationBase selectedTalent;
    public TextMeshProUGUI dustCount;
    public TextMeshProUGUI customDustCost;
    public Resources_SelectLocusRunePane runePane;

    public TMP_Dropdown statDropdown;
    public TMP_Dropdown aspectDropdown;
    public TMP_Dropdown methodDropdown;
    public TMP_Dropdown valueDropdown;
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
        selectedRune.Hide();
        HideRuneModificationElements();
        DisplayDust();
        DisplayAllRuneOptions();
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
        runePane.ClearSelected();
        if (selectedTalent != null)
            selectedTalent.Deselect();
        HideRuneModificationElements();
    }

    public void SetRuneToModify(LocusRuneItem locusRune)
    {
        selectedRune.SetRune(locusRune);
        ShowRuneModificationElements();
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

        DetermineCustomTalentCost();
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

        DetermineCustomTalentCost();
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

        DetermineCustomTalentCost();
    }

    public void FilterRuneValues()
    {
        if (statDropdown.options[statDropdown.value].text != "None" && aspectDropdown.options[aspectDropdown.value].text != "None" && methodDropdown.options[methodDropdown.value].text != "None")
        {
            ModifierBaseManager newManager = new ModifierBaseManager(false);
            List<string> values = new List<string>();
            ModifierGroup.EStat selectedStat = (ModifierGroup.EStat)Enum.Parse(typeof(ModifierGroup.EStat), statDropdown.options[statDropdown.value].text);
            ModifierGroup.EAspect selectedAspect = (ModifierGroup.EAspect)Enum.Parse(typeof(ModifierGroup.EAspect), aspectDropdown.options[aspectDropdown.value].text);
            ModifierGroup.EMethod selectedMethod = (ModifierGroup.EMethod)Enum.Parse(typeof(ModifierGroup.EMethod), methodDropdown.options[methodDropdown.value].text);
            foreach (var item in newManager.GetModifiersByAll_Talents(selectedStat, selectedAspect, selectedMethod))
            {
                values.Add(item.RangeLow.ToString() + " - " + item.RangeHigh);
            }
            valueDropdown.ClearOptions();
            valueDropdown.AddOptions(values);
        }
        else
            valueDropdown.ClearOptions();

        DetermineCustomTalentCost();
    }

    public void DetermineCustomTalentCost()
    {
        int value = 0;
        if (statDropdown.options[statDropdown.value].text != "None")
            value += 15;
        if (aspectDropdown.options[aspectDropdown.value].text != "None")
            value += 10;
        if (methodDropdown.options[methodDropdown.value].text != "None")
            value += 5;
        customDustCost.SetText(value.ToString());
    }

    public void ShowCustomTalentButton()
    {
        if (statDropdown.options[statDropdown.value].text != "None" || aspectDropdown.options[aspectDropdown.value].text != "None" || methodDropdown.options[methodDropdown.value].text != "None")
            customTalentButton.gameObject.SetActive(true);
        else
            customTalentButton.gameObject.SetActive(false);
    }

    private void HideRuneModificationElements()
    {
        AddT1Button.SetActive(false);
        AddT2Button.SetActive(false);
        AddT3Button.SetActive(false);
        rerollButton.gameObject.SetActive(false);
        rerollTalentButton.gameObject.SetActive(false);
        RemoveTalentButton.SetActive(false);
        statDropdown.gameObject.SetActive(false);
        aspectDropdown.gameObject.SetActive(false);
        methodDropdown.gameObject.SetActive(false);
        valueDropdown.gameObject.SetActive(false);
        addCustomTalentButton.gameObject.SetActive(false);
        customDustCost.gameObject.SetActive(false);
}

    private void ShowRuneModificationElements()
    {
        DisplaySpecificButtons();
        rerollButton.gameObject.SetActive(true);
        rerollTalentButton.gameObject.SetActive(true);
        statDropdown.gameObject.SetActive(true);
        aspectDropdown.gameObject.SetActive(true);
        methodDropdown.gameObject.SetActive(true);
        valueDropdown.gameObject.SetActive(true);
        addCustomTalentButton.gameObject.SetActive(true);
        customDustCost.gameObject.SetActive(true);
    }

    private void DisplaySpecificButtons()
    {
        if (selectedTalent != null)
            RemoveTalentButton.SetActive(true);
        else
            RemoveTalentButton.SetActive(false);

        if (selectedRune.LocusRune.locusRune.Tier1Talents.Count < LocusRune.maxTier1Talents)
            AddT1Button.SetActive(true);
        else
            AddT1Button.SetActive(false);
        if (selectedRune.LocusRune.locusRune.Tier2Talents.Count < LocusRune.maxTier2Talents)
            AddT2Button.SetActive(true);
        else
            AddT2Button.SetActive(false);
        if (selectedRune.LocusRune.locusRune.Tier3Talents.Count < LocusRune.maxTier3Talents)
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
        if (combo.stat != "None" && combo.aspect != "None" && combo.method != "None")
        {
            if (GameWorldReferenceClass.validStats.Exists(x => x.stat == combo.stat && x.aspect == combo.aspect && x.method == combo.method))
            {
                Tier1Talent newTalent = new Tier1Talent();
                newTalent.TalentId = Guid.NewGuid();
                newTalent.cost = 1;
                newTalent.tier = BaseTalent.Tier.tier1;
                newTalent.modifier.Stat = (ModifierGroup.EStat)Enum.Parse(typeof(ModifierGroup.EStat), combo.stat);
                newTalent.modifier.Aspect = (ModifierGroup.EAspect)Enum.Parse(typeof(ModifierGroup.EAspect), combo.aspect);
                newTalent.modifier.Method = (ModifierGroup.EMethod)Enum.Parse(typeof(ModifierGroup.EMethod), combo.method);
                var split = valueDropdown.options[valueDropdown.value].text.Split(" - ");
                newTalent.modifier.Value = UnityEngine.Random.Range(int.Parse(split[0]), int.Parse(split[1]) + 1);
                newTalent.talentName = newTalent.modifier.ReadableName();

                selectedRune.LocusRune.locusRune.PlaceT1Rune(newTalent);
                selectedRune.SetRune(selectedRune.LocusRune);
                return;
            }
        }
        else
        {
            Tier1Talent newTalent = new Tier1Talent();
            ModifierGroup newModGroup = ModifierBaseManager.main.SelectRandomModifiers(ModifierBaseManager.main.GetModifiersByAll_Talents((ModifierGroup.EStat)Enum.Parse(typeof(ModifierGroup.EStat), combo.stat),
                (ModifierGroup.EAspect)Enum.Parse(typeof(ModifierGroup.EAspect), combo.aspect),
                (ModifierGroup.EMethod)Enum.Parse(typeof(ModifierGroup.EMethod), combo.method)),
                1)[0];
            newTalent.TalentId = Guid.NewGuid();
            newTalent.cost = 1;
            newTalent.tier = BaseTalent.Tier.tier1;
            newTalent.modifier.Stat = newModGroup.Stat;
            newTalent.modifier.Aspect = newModGroup.Aspect;
            newTalent.modifier.Method = newModGroup.Method;
            newTalent.modifier.Value = newModGroup.Value;
            newTalent.talentName = newTalent.modifier.ReadableName();

            selectedRune.LocusRune.locusRune.PlaceT1Rune(newTalent);
            selectedRune.SetRune(selectedRune.LocusRune);
        }

        PlayerCharacterUnit.player.playerResources.magicDust -= int.Parse(customDustCost.text);
        DisplayDust();
    }

    public void DisplayDust()
    {
        dustCount.SetText(PlayerCharacterUnit.player.playerResources.magicDust + " Magic Dust");
    }

    public void RerollLocusRune()
    {
        if (PlayerCharacterUnit.player.playerResources.CostCheck(10))
        {
            PlayerCharacterUnit.player.availableLocusRuneItems.Find(x => x.itemID == selectedRune.LocusRune.itemID).locusRune = LocusRune.RandomRune();
            selectedRune.SetRune(selectedRune.LocusRune);
            if (selectedTalent != null)
            {
                selectedTalent.Deselect();
            }
            selectedTalent = null;
            PlayerCharacterUnit.player.playerResources.magicDust -= 10;
            DisplayDust();
            DisplaySpecificButtons();
            runePane.RefreshAfterChanges();
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
        runePane.RefreshAfterChanges();
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

            runePane.RefreshAfterChanges();
        }
    }

    void RerollTier1Talent()
    {
        ((UITier1TalentModification)selectedTalent).Initialize(Tier1Talent.NewRandomTier1Talent());
    }

    public void AddTier1Talent()
    {
        selectedRune.LocusRune.locusRune.PlaceT1Rune(Tier1Talent.NewRandomTier1Talent());
        selectedRune.SetRune(selectedRune.LocusRune);
        DisplaySpecificButtons();
        runePane.RefreshAfterChanges();
    }

    void RerollTier2Talent()
    {
        ((UITier2TalentModification)selectedTalent).Initialize(Tier2Talent.NewRandomTier2Talent());
    }

    public void AddTier2Talent()
    {
        selectedRune.LocusRune.locusRune.PlaceT2Rune(Tier2Talent.NewRandomTier2Talent());
        selectedRune.SetRune(selectedRune.LocusRune);
        DisplaySpecificButtons();
        runePane.RefreshAfterChanges();
    }

    void RerollTier3Talent()
    {

    }

    public void AddTier3Talent()
    {

        runePane.RefreshAfterChanges();
    }

    public void RemoveTalent()
    {
        if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier1)
        {
            selectedRune.LocusRune.locusRune.RemoveT1Rune((Tier1Talent)(selectedTalent.talentInSlot));
        }
        else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier2)
        {
            selectedRune.LocusRune.locusRune.RemoveT2Rune((Tier2Talent)(selectedTalent.talentInSlot));
        }
        else if (selectedTalent.talentInSlot.tier == BaseTalent.Tier.tier3)
        {
        }

        selectedRune.SetRune(selectedRune.LocusRune);
        selectedTalent.Deselect();
        selectedTalent = null;
        DisplaySpecificButtons();
        runePane.RefreshAfterChanges();
    }
}