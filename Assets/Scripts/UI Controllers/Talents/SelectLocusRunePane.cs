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
    public UILocusRuneConnector selectedConnector;
    public GameObject mainContent;

    public void Show(UILocusRuneConnector current)
    {
        foreach (Transform kid in LocusRuneListContent.transform)
            Destroy(kid.gameObject);

        foreach (var item in GameWorldReferenceClass.GW_Player.availableLocusRuneItems)
        {
            UILocusRuneItem runeToDisplay = (Instantiate(Resources.Load("Prefabs/UIComponents/Talents/UILocusRuneItem"), LocusRuneListContent.transform) as GameObject).GetComponent<UILocusRuneItem>();
            runeToDisplay.RuneItem = item;
        }

        selectedConnector = current;
        mainContent.SetActive(true);
    }

    public void Hide()
    {
        mainContent.SetActive(false);
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
       selectedConnector.runeConnectingFrom.Connect(selectedConnector);
        Hide();
    }
}