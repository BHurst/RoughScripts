using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTalentsPane : MonoBehaviour
{
    public GameObject mainPanel;
    public PlayerCharacterUnit unit;
    public GameObject talentContent;
    public WebSigil webSigil = new WebSigil();
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        if (unit == null)
            unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        Display();
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
    }

    private void Display()
    {
        UpdatePoints(0);

        talentContent.transform.GetChild(0).GetChild(0).GetComponent<UISimpleTalent>().talentInSlot = webSigil.locusRunes[0].simpleTalents[0];
        talentContent.transform.GetChild(0).GetChild(0).GetComponent<UISimpleTalent>().SetTooltipInfo();
        talentContent.transform.GetChild(0).GetChild(1).GetComponent<UISimpleTalent>().talentInSlot = webSigil.locusRunes[0].simpleTalents[1];
        talentContent.transform.GetChild(0).GetChild(1).GetComponent<UISimpleTalent>().SetTooltipInfo();
        talentContent.transform.GetChild(0).GetChild(2).GetComponent<UISimpleTalent>().talentInSlot = webSigil.locusRunes[0].simpleTalents[2];
        talentContent.transform.GetChild(0).GetChild(2).GetComponent<UISimpleTalent>().SetTooltipInfo();
                               
        talentContent.transform.GetChild(0).GetChild(3).GetComponent<UIComplexTalent>().talentInSlot = webSigil.locusRunes[0].complexTalents[0];
        talentContent.transform.GetChild(0).GetChild(3).GetComponent<UIComplexTalent>().SetTooltipInfo();
        talentContent.transform.GetChild(0).GetChild(4).GetComponent<UIComplexTalent>().talentInSlot = webSigil.locusRunes[0].complexTalents[1];
        talentContent.transform.GetChild(0).GetChild(4).GetComponent<UIComplexTalent>().SetTooltipInfo();
    }

    public void UpdatePoints(int points)
    {
        unit.level.availableTalentPoints += points;
        pointsText.SetText(unit.level.availableTalentPoints.ToString() + "/" + unit.level.maxTalentPoints.ToString());
    }
}