using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrunkNode : MonoBehaviour
{
    public int index;
    public LocusRune runeInNode;
    public List<UITalentBranchNode> connectedBranchNodes;
    public bool active = false;
    public int levelAvailable = 0;
    public int investment = 0;
    public int investmentForBonus = 0;
    public Image background;
    public List<UITier1Talent> Tier1Talents;
    public List<UITier2Talent> Tier2Talents;
    public List<UITier3Talent> Tier3Talents;
    public List<UITalentBranch> connectedBranches;

    private void Start()
    {
        StartPlacement();
    }

    private void StartPlacement()
    {
        for (int i = 0; i < Tier1Talents.Count; i++)
        {
            if (runeInNode.Tier1Talents.Count > i)
            {
                Tier1Talents[i].Initialize(runeInNode.Tier1Talents[i]);
                Tier1Talents[i].gameObject.SetActive(true);
            }
            else
                Tier1Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier2Talents.Count; i++)
        {
            if (runeInNode.Tier2Talents.Count > i)
            {
                Tier2Talents[i].Initialize(runeInNode.Tier2Talents[i]);
                Tier2Talents[i].gameObject.SetActive(true);
            }
            else
                Tier2Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier3Talents.Count; i++)
        {
            if (runeInNode.Tier3Talents.Count > i)
            {
                Tier3Talents[i].Initialize(runeInNode.Tier3Talents[i]);
                Tier3Talents[i].gameObject.SetActive(true);
            }
            else
                Tier3Talents[i].gameObject.SetActive(false);
        }

        //.1f as initially, all talent pages will start zoomed out.
        for (int i = 0; i < runeInNode.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / runeInNode.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * .1f, 100 * Mathf.Sin((360 / runeInNode.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * .1f);
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talents[0].transform.position = transform.position + (new Vector3(0, -145) * .1f);
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talents[0].transform.position = transform.position + (new Vector3(-145, -145) * .1f);
            Tier3Talents[1].transform.position = transform.position + (new Vector3(145, -145) * .1f);
        }
    }

    private void SetRune(LocusRune nR)
    {
        runeInNode = nR;

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

    public void SetActive()
    {
        background.color = Color.black;
        active = true;
    }

    public void SetInactive()
    {
        background.color = Color.grey;
        active = false;
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

    public void LoadTree(TalentTrunkNode trunkNode)
    {
        index = trunkNode.index;
        SetRune(trunkNode.runeInNode);
        for (int i = 0; i < trunkNode.runeInNode.Tier1Talents.Count; i++)
        {
            if (trunkNode.runeInNode.Tier1Talents[i].active)
                Tier1Talents[i].Toggle();
        }
        for (int i = 0; i < trunkNode.runeInNode.Tier2Talents.Count; i++)
        {
            if (trunkNode.runeInNode.Tier2Talents[i].active)
                Tier2Talents[i].Toggle();
        }
        for (int i = 0; i < trunkNode.runeInNode.Tier3Talents.Count; i++)
        {
            if (trunkNode.runeInNode.Tier3Talents[i].active)
                Tier3Talents[i].Toggle();
        }
        for (int i = 0; i < trunkNode.connectedBranches.Count; i++)
        {
            connectedBranches[i].trunkNodeIndex = index;
            connectedBranches[i].LoadTree(trunkNode.connectedBranches[i]);
        }
    }
}