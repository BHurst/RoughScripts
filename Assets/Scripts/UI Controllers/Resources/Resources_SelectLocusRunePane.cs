using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resources_SelectLocusRunePane : MonoBehaviour
{
    public CharacterResourcesPane resourcesPane;
    public GameObject LocusRuneListContent;
    public GameObject selectedLocusRuneListObject;
    public LocusRuneItem selectedLocusRuneItem;
    public Image SelectedRuneImage;
    public TextMeshProUGUI SelectedRuneText;
    public TextMeshProUGUI breakdownButtonText;
    public GameObject mainContent;

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
        selectedLocusRuneListObject = null;
        selectedLocusRuneItem = null;
        SelectedRuneText.SetText("");
        SelectedRuneImage.sprite = null;
        breakdownButtonText.SetText("");
    }

    public void DisplayRuneInfo(Resources_UILocusRuneItem item)
    {
        string newText = "";

        foreach (var mod in item.RuneItem.LocusRune.Tier1Talents)
        {
            newText += mod.modifier.ReadableName() + "\n";
        }
        selectedLocusRuneListObject = item.gameObject;
        breakdownButtonText.SetText("Breakdown into " + selectedLocusRuneItem.LocusRune.breakdownRefund + " dust");
        SelectedRuneText.SetText(newText);
    }

    public void Breakdown()
    {
        PlayerCharacterUnit.player.playerResources.magicDust += selectedLocusRuneItem.LocusRune.breakdownRefund;
        resourcesPane.DisplayDust();
        PlayerCharacterUnit.player.availableLocusRuneItems.Remove(selectedLocusRuneItem);
        Destroy(selectedLocusRuneListObject);
        ClearSelected();
    }
}