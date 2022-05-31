using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectLocusRunePane : MonoBehaviour
{
    public GameObject LocusRuneListContent;
    public LocusRuneItem selectedLocusRuneItem;
    public Image SelectedRuneImage;
    public TextMeshProUGUI SelectedRuneText;
    public UILocusRuneSlot selectedSlot;
    public GameObject mainContent;

    public void Show(UILocusRuneSlot current)
    {
        foreach (Transform kid in LocusRuneListContent.transform)
            Destroy(kid.gameObject);

        foreach (var item in PlayerCharacterUnit.player.availableLocusRuneItems)
        {
            UILocusRuneItem runeToDisplay = (Instantiate(Resources.Load("Prefabs/UIComponents/Talents/UILocusRuneItem"), LocusRuneListContent.transform) as GameObject).GetComponent<UILocusRuneItem>();
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

    public void DisplayRuneInfo(UILocusRuneItem item)
    {
        string newText = "";

        foreach (var mod in item.RuneItem.LocusRune.Tier1Talents)
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