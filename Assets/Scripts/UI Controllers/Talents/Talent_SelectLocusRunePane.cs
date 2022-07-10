using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Talent_SelectLocusRunePane : MonoBehaviour
{
    public GameObject LocusRuneListContent;
    public LocusRuneItem selectedLocusRuneItem;
    public Image SelectedRuneImage;
    public TextMeshProUGUI SelectedRuneText;
    public UITalentBranchNode selectedSlot;
    public GameObject mainContent;

    public void Show(UITalentBranchNode current)
    {
        foreach (Transform kid in LocusRuneListContent.transform)
            Destroy(kid.gameObject);

        foreach (var item in PlayerCharacterUnit.player.availableLocusRuneItems)
        {
            Talent_UILocusRuneItem runeToDisplay = (Instantiate(Resources.Load("Prefabs/UIComponents/Talents/UI_Talent_LocusRuneItem"), LocusRuneListContent.transform) as GameObject).GetComponent<Talent_UILocusRuneItem>();
            runeToDisplay.RuneItem = item;
        }

        selectedSlot = current;
        mainContent.SetActive(true);
    }

    public void Hide()
    {
        mainContent.SetActive(false);
        selectedLocusRuneItem = null;
    }

    public void DisplayRuneInfo(Talent_UILocusRuneItem item)
    {
        string newText = "";

        foreach (var mod in item.RuneItem.locusRune.Tier1Talents)
        {
            newText += mod.modifier.ReadableName() + "\n";
        }

        SelectedRuneText.SetText(newText);
    }

    public void Attach()
    {
        if(selectedLocusRuneItem != null)
        {
            selectedSlot.PutRuneInSlot(selectedLocusRuneItem);
            
        }
        Hide();
    }
}