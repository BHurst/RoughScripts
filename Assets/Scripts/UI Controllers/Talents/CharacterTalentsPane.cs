using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTalentsPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Talent_SelectLocusRunePane SelectLocusRunePane;
    public UITalentTree activeTalentTree;
    public Transform activeTalentTreeContent;
    public UITalentTree starterTalentTree;
    public UITalentTree talentTree1;
    public UITalentTree talentTree2;
    public UITalentTree talentTree3;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        mainPanel.transform.position = transform.position;

        activeTalentTree = starterTalentTree;
        activeTalentTree.gameObject.SetActive(true);
        talentTree1.gameObject.SetActive(false);
        talentTree2.gameObject.SetActive(false);
        talentTree3.gameObject.SetActive(false);
        mainPanel.SetActive(false);
        SetTalentTree(TalentTree.TalentTreeType.Tree1);
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

    public void SetTalentTree(TalentTree.TalentTreeType talentTreeType)
    {
        if (activeTalentTree != null)
            activeTalentTree.gameObject.SetActive(false);

        switch (talentTreeType)
        {
            case TalentTree.TalentTreeType.Basic:
                {
                    activeTalentTree = starterTalentTree;
                }
                break;
            case TalentTree.TalentTreeType.Tree1:
                {
                    activeTalentTree = talentTree1;
                }
                break;
            case TalentTree.TalentTreeType.Tree2:
                {
                    activeTalentTree = talentTree2;
                }
                break;
            case TalentTree.TalentTreeType.Tree3:
                {
                    activeTalentTree = talentTree3;
                }
                break;
            default:
                break;
        }
        activeTalentTreeContent = activeTalentTree.gameObject.GetComponent<TalentPageZoom>().content.transform;
        PlayerCharacterUnit.player.talents.Setup(activeTalentTree.ConvertToTalentTree());
        //activeTalentTree.LoadTree(PlayerCharacterUnit.player.talents.activeTalentTree);
        activeTalentTree.UnlockNextTrunk();
        activeTalentTree.gameObject.SetActive(true);
    }

    private void Display()
    {
        UpdatePoints(0);
    }

    public void UpdatePoints(int points)
    {
        PlayerCharacterUnit.player.level.availableTalentPoints += points;
        pointsText.SetText(PlayerCharacterUnit.player.level.availableTalentPoints.ToString() + "/" + PlayerCharacterUnit.player.level.maxTalentPoints.ToString());
    }

    public void Event_UpdateLevel(object args, CharacterLevel characterLevel)
    {
        pointsText.SetText(characterLevel.availableTalentPoints.ToString() + "/" + characterLevel.maxTalentPoints.ToString());
        activeTalentTree.UnlockNextTrunk();
    }
}