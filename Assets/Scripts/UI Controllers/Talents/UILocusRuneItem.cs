using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILocusRuneItem : MonoBehaviour, IPointerClickHandler
{
    public SelectLocusRunePane SelectLocusRunePane;
    public LocusRuneItem RuneItem;
    public Image RuneImage;
    public TextMeshProUGUI runeName;
    public TextMeshProUGUI shortInfo;

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectLocusRunePane.selectedLocusRuneItem = RuneItem;
        SelectLocusRunePane.DisplayRuneInfo(this);
    }

    void Start()
    {
        SelectLocusRunePane = GameObject.Find("SelectLocusRunePane").GetComponent<SelectLocusRunePane>();
        runeName.SetText(RuneItem.LocusRune.locusRuneName);
        shortInfo.SetText(RuneItem.LocusRune.Tier1Talents.Count.ToString() + " T1 talents\n" + RuneItem.LocusRune.Tier3Talents.Count.ToString() + " T3 talents");
    }
}