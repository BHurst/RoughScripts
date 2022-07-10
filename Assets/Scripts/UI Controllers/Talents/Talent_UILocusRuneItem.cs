using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Talent_UILocusRuneItem : MonoBehaviour, IPointerClickHandler
{
    public Talent_SelectLocusRunePane SelectLocusRunePane;
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
        SelectLocusRunePane = GameObject.Find("Talent_SelectLocusRunePane").GetComponent<Talent_SelectLocusRunePane>();
        runeName.SetText(RuneItem.locusRune.locusRuneName);
        shortInfo.SetText(RuneItem.locusRune.Tier1Talents.Count.ToString() + " T1 talents\n" + RuneItem.locusRune.Tier3Talents.Count.ToString() + " T3 talents");
    }
}