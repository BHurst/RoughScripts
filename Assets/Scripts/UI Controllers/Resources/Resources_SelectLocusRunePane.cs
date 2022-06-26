using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resources_SelectLocusRunePane : MonoBehaviour
{
    public CharacterResourcesPane resourcesPane;
    public GameObject LocusRuneListContent;
    public LocusRuneItem selectedLocusRuneItem;
    public Image SelectedRuneImage;
    public TextMeshProUGUI SelectedRuneText;
    public TextMeshProUGUI breakdownButtonText;
    public GameObject mainContent;
    public Resources_UILocusRuneItem lastSelected;

    public void DisplayAvailableRunes()
    {
        foreach (Transform kid in LocusRuneListContent.transform)
            Destroy(kid.gameObject);

        foreach (var item in PlayerCharacterUnit.player.availableLocusRuneItems)
        {
            Resources_UILocusRuneItem runeToDisplay = (Instantiate(Resources.Load("Prefabs/UIComponents/PlayerResources/UI_Resources_LocusRuneItem"), LocusRuneListContent.transform) as GameObject).GetComponent<Resources_UILocusRuneItem>();
            runeToDisplay.RuneItem = item;
        }
    }

    public void ClearSelected()
    {
        selectedLocusRuneItem = null;
        SelectedRuneText.SetText("");
        SelectedRuneImage.sprite = null;
        breakdownButtonText.SetText("");
        lastSelected = null;
    }

    public void RefreshAfterChanges()
    {
        DisplayAvailableRunes();
        DisplayRuneInfo(lastSelected);
    }

    public void DisplayRuneInfo(Resources_UILocusRuneItem item)
    {
        string newText = "";
        foreach (var mod in item.RuneItem.LocusRune.Tier1Talents)
        {
            newText += mod.modifier.ReadableName() + "\n";
        }
        breakdownButtonText.SetText("Breakdown into " + selectedLocusRuneItem.LocusRune.breakdownRefund + " dust");
        SelectedRuneText.SetText(newText);
    }

    public void Breakdown()
    {
        PlayerCharacterUnit.player.playerResources.magicDust += selectedLocusRuneItem.LocusRune.breakdownRefund;
        resourcesPane.DisplayDust();
        PlayerCharacterUnit.player.availableLocusRuneItems.Remove(selectedLocusRuneItem);
        Destroy(lastSelected.gameObject);
        ClearSelected();
    }

    public void SelectRuneToModify()
    {
        resourcesPane.SetRuneToModify(selectedLocusRuneItem);
    }
}