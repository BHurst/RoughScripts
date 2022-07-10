using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterTalentsPane : MonoBehaviour
{
    public GameObject mainPanel;
    public Talent_SelectLocusRunePane SelectLocusRunePane;
    public PlayerCharacterUnit unit;
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
        if (unit == null)
            unit = GameObject.Find("PlayerData").GetComponent<PlayerCharacterUnit>();

        activeTalentTree = starterTalentTree;
        activeTalentTree.gameObject.SetActive(true);
        mainPanel.SetActive(false);
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

    public void SetTalentTree()
    {
        if (activeTalentTree != null)
            activeTalentTree.gameObject.SetActive(false);

        activeTalentTree = starterTalentTree;
        activeTalentTreeContent = activeTalentTree.gameObject.GetComponent<TalentPageZoom>().content.transform;
        //switch (talentTreeType)
        //{
        //    case UITalentTreePreset.TalentTreeType.Basic:
        //        {
        //            activeTalentTree = starterTalentTree;
        //            PlayerCharacterUnit.player.talents.activeTalentTree = new TalentTree_Basic();
        //            break;
        //        }
        //    case UITalentTreePreset.TalentTreeType.TalentTree1:
        //        {
        //            activeTalentTree = talentTree1;
        //            PlayerCharacterUnit.player.talents.activeTalentTree = new TalentTree1();
        //            break;
        //        }
        //    case UITalentTreePreset.TalentTreeType.TalentTree2:
        //        {
        //            activeTalentTree = talentTree2;
        //            PlayerCharacterUnit.player.talents.activeTalentTree = new TalentTree2();
        //            break;
        //        }
        //    case UITalentTreePreset.TalentTreeType.TalentTree3:
        //        {
        //            activeTalentTree = talentTree3;
        //            PlayerCharacterUnit.player.talents.activeTalentTree = new TalentTree3();
        //            break;
        //        }
        //    default:
        //        break;
        //}
        activeTalentTree.LoadTree(PlayerCharacterUnit.player.talents.activeTalentTree);
        activeTalentTree.UnlockNextTrunk();
        activeTalentTree.gameObject.SetActive(true);
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
        activeTalentTree.UnlockNextTrunk();
    }
}