using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTalentsPane : MonoBehaviour
{
    public GameObject mainPanel;
    public SelectLocusRunePane SelectLocusRunePane;
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
    }

    public void UpdatePoints(int points)
    {
        unit.level.availableTalentPoints += points;
        pointsText.SetText(unit.level.availableTalentPoints.ToString() + "/" + unit.level.maxTalentPoints.ToString());
    }
}