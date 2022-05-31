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
    public TalentSapling webSigil = new TalentSapling();
    public TextMeshProUGUI pointsText;

    public UITrunkNode node1;
    public UITrunkNode node2;
    public UITrunkNode node3;
    public UITrunkNode node4;
    public UITrunkNode node5;
    public UITrunkNode node6;
    public UITrunkNode node7;
    public UITrunkNode node8;
    public UITrunkNode node9;
    public UITrunkNode node10;

    private void Start()
    {
        if (unit == null)
            unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();

        node1.trunkPreset = new Trunk_FlatLife();
        node2.trunkPreset = new Trunk_FlatLife();
        node3.trunkPreset = new Trunk_FlatLife();
        node4.trunkPreset = new Trunk_FlatLife();
        node5.trunkPreset = new Trunk_FlatLife();
        node6.trunkPreset = new Trunk_FlatLife();
        node7.trunkPreset = new Trunk_FlatLife();
        node8.trunkPreset = new Trunk_FlatLife();
        node9.trunkPreset = new Trunk_FlatLife();
        node10.trunkPreset = new Trunk_FlatLife();
        
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        node1.LoadPreset();
        node2.LoadPreset();
        node3.LoadPreset();
        node4.LoadPreset();
        node5.LoadPreset();
        node6.LoadPreset();
        node7.LoadPreset();
        node8.LoadPreset();
        node9.LoadPreset();
        node10.LoadPreset();
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