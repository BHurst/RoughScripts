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
    public TextMeshProUGUI pointsText;

    public UITrunkNode node1;
    public UITrunkNode node2;
    public UITrunkNode node3;
    public UITrunkNode node4;
    public UITrunkNode node5;
    public UITrunkNode node6;
    public UITrunkNode node7;

    private void Start()
    {
        mainPanel.transform.position = transform.position;
        if (unit == null)
            unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();

        node1.trunkPreset = new Trunk_1();
        node2.trunkPreset = new Trunk_2();
        node3.trunkPreset = new Trunk_3();
        node4.trunkPreset = new Trunk_4();
        node5.trunkPreset = new Trunk_5();
        node6.trunkPreset = new Trunk_6();
        node7.trunkPreset = new Trunk_7();
        mainPanel.SetActive(false);
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        node1.LoadPreset();
        node1.SetAvailable();
        node2.LoadPreset();
        node3.LoadPreset();
        node4.LoadPreset();
        node5.LoadPreset();
        node6.LoadPreset();
        node7.LoadPreset();
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