using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterResourcesPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Button rerollButton;
    public Button rerollTalentButton;
    public UILocusRuneModification selectedRune;
    public UITalentModificationBase selectedTalent;
    public TextMeshProUGUI dustCount;
    public Resources_SelectLocusRunePane runePane;

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