using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITalentBranchNode : MonoBehaviour
{
    public int index;
    public int branchIndex;
    public int trunkIndex;
    public UITalentBranchNode priorNode;
    public LocusRune runeInNode;
    public Transform connectedBranchNodeParent;
    public List<UITalentBranchNode> connectedBranchNodes;
    public bool active = false;
    public bool available = false;
    public int investment = 0;
    public int investmentForBonus = 0;
    public Image background;
    public List<UITier1Talent> Tier1Talents;
    public List<UITier2Talent> Tier2Talents;
    public List<UITier3Talent> Tier3Talents;

    private void Start()
    {
        StartPlacement();
    }

    public void LoadTree(TalentBranchNode node)
    {
        index = node.index;
        if (node.runeInNode != null)
        {
            SetRune(node.runeInNode);
            for (int i = 0; i < node.runeInNode.Tier1Talents.Count; i++)
            {
                if (node.runeInNode.Tier1Talents[i].active)
                    Tier1Talents[i].Toggle();
            }
            for (int i = 0; i < node.runeInNode.Tier2Talents.Count; i++)
            {
                if (node.runeInNode.Tier2Talents[i].active)
                    Tier2Talents[i].Toggle();
            }
            for (int i = 0; i < node.runeInNode.Tier3Talents.Count; i++)
            {
                if (node.runeInNode.Tier3Talents[i].active)
                    Tier3Talents[i].Toggle();
            }
        }
        else
        {
            runeInNode = null;
            foreach (var item in Tier1Talents)
            {
                item.gameObject.SetActive(false);
            }
            foreach (var item in Tier2Talents)
            {
                item.gameObject.SetActive(false);
            }
            foreach (var item in Tier3Talents)
            {
                item.gameObject.SetActive(false);
            }
        }
        connectedBranchNodes = new List<UITalentBranchNode>();
        foreach (Transform item in connectedBranchNodeParent)
        {
            connectedBranchNodes.Add(item.GetComponent<UITalentBranchNode>());
        }
        for (int i = 0; i < node.connectedBranchNodes.Count; i++)
        {
            connectedBranchNodes[i].priorNode = this;
            connectedBranchNodes[i].LoadTree(node.connectedBranchNodes[i]);
        }
    }

    public void ChangeRune()
    {
        UIManager.main.talentSheet.SelectLocusRunePane.Show(this);
    }

    private void StartPlacement()
    {
        for (int i = 0; i < Tier1Talents.Count; i++)
        {
            Tier1Talents[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < Tier2Talents.Count; i++)
        {
            Tier2Talents[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < Tier3Talents.Count; i++)
        {
            Tier3Talents[i].gameObject.SetActive(false);
        }
    }

    public void SetRune(LocusRune nR)
    {
        runeInNode = nR;
        PlayerCharacterUnit.player.talents.activeTalentTree.trunk.trunkNodes[trunkIndex].connectedBranches[branchIndex].talentBranchNodes[index].runeInNode = nR;
        active = true;

        for (int i = 0; i < Tier1Talents.Count; i++)
        {
            if (nR.Tier1Talents.Count > i)
            {
                Tier1Talents[i].Initialize(nR.Tier1Talents[i]);
                Tier1Talents[i].gameObject.SetActive(true);
            }
            else
                Tier1Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier2Talents.Count; i++)
        {
            if (nR.Tier2Talents.Count > i)
            {
                Tier2Talents[i].Initialize(nR.Tier2Talents[i]);
                Tier2Talents[i].gameObject.SetActive(true);
            }
            else
                Tier2Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier3Talents.Count; i++)
        {
            if (nR.Tier3Talents.Count > i)
            {
                Tier3Talents[i].Initialize(nR.Tier3Talents[i]);
                Tier3Talents[i].gameObject.SetActive(true);
            }
            else
                Tier3Talents[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < runeInNode.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / runeInNode.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * UIManager.main.talentSheet.activeTalentTreeContent.localScale.x, 100 * Mathf.Sin((360 / runeInNode.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * UIManager.main.talentSheet.activeTalentTreeContent.localScale.x);
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talents[0].transform.position = transform.position + (new Vector3(0, -145) * UIManager.main.talentSheet.activeTalentTreeContent.localScale.x);
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talents[0].transform.position = transform.position + (new Vector3(-145, -145) * UIManager.main.talentSheet.activeTalentTreeContent.localScale.x);
            Tier3Talents[1].transform.position = transform.position + (new Vector3(145, -145) * UIManager.main.talentSheet.activeTalentTreeContent.localScale.x);
        }
    }

    public void SetUnavailable()
    {
        background.color = Color.black;
        available = false;
    }

    public void SetAvailable()
    {
        background.color = Color.white;
        available = true;
    }

    public void Invest()
    {
        investment++;
        if (investment == investmentForBonus)
        {
            //Enable Bonus
        }
    }

    public void Divest()
    {
        investment--;
        if (investment < investmentForBonus)
        {
            //Disable Bonus
        }
    }

    public void PutRuneInSlot(LocusRuneItem locusRuneItem)
    {
        if (runeInNode != null && runeInNode.Tier1Talents.Count > 0)
        {
            foreach (var item in Tier1Talents)
            {
                if (item.active)
                    item.Toggle();
            }
            foreach (var item in Tier2Talents)
            {
                if (item.active)
                    item.Toggle();
            }
            foreach (var item in Tier3Talents)
            {
                if (item.active)
                    item.Toggle();
            }
            LocusRuneItem swappedRune = new LocusRuneItem();
            swappedRune.locusRune = runeInNode;
            //PlayerCharacterUnit.player.charInventory.AddItem(swappedRune, true);
            PlayerCharacterUnit.player.availableLocusRuneItems.Add(swappedRune);
        }
        SetRune(locusRuneItem.locusRune);
        foreach (var item in connectedBranchNodes)
        {
            item.SetAvailable();
        }
        PlayerCharacterUnit.player.availableLocusRuneItems.Remove(locusRuneItem);
    }
}