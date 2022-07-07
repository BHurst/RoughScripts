using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTalentsPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Talent_SelectLocusRunePane SelectLocusRunePane;
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
        node1.LoadPreset();
        node1.SetAvailable();
        node2.trunkPreset = new Trunk_2();
        node2.LoadPreset();
        node3.trunkPreset = new Trunk_3();
        node3.LoadPreset();
        node4.trunkPreset = new Trunk_4();
        node4.LoadPreset();
        node5.trunkPreset = new Trunk_5();
        node5.LoadPreset();
        node6.trunkPreset = new Trunk_6();
        node6.LoadPreset();
        node7.trunkPreset = new Trunk_7();
        node7.LoadPreset();
        mainPanel.SetActive(false);
    }

    public void Show()
    {
        mainPanel.SetActive(true);
        Display();
    }

    public void UnlockNextTrunk(int level)
    {
        if (level >= 5)
        {
            node2.SetAvailable();
        }
        if (level >= 10)
        {
            node3.SetAvailable();
        }
        if (level >= 15)
        {
            node4.SetAvailable();
        }
        if (level >= 20)
        {
            node5.SetAvailable();
        }
        if (level >= 25)
        {
            node6.SetAvailable();
        }
        if (level >= 30)
        {
            node7.SetAvailable();
        }
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

    public void Event_UpdateLevel(object args, CharacterLevel characterLevel)
    {
        pointsText.SetText(characterLevel.availableTalentPoints.ToString() + "/" + characterLevel.maxTalentPoints.ToString());
        if (characterLevel.currentLevel % 5 == 0)
            UnlockNextTrunk(characterLevel.currentLevel);
    }
}