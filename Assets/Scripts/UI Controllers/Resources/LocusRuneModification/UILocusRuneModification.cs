using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocusRuneModification : MonoBehaviour
{
    public LocusRuneItem LocusRune;
    public UITier1TalentModification Tier1Talent1;
    public UITier1TalentModification Tier1Talent2;
    public UITier1TalentModification Tier1Talent3;
    public UITier1TalentModification Tier1Talent4;
    public UITier1TalentModification Tier1Talent5;
    public UITier1TalentModification Tier1Talent6;
    public UITier1TalentModification Tier1Talent7;
    public UITier1TalentModification Tier1Talent8;
    List<UITier1TalentModification> Tier1Talents;
    public UITier2TalentModification Tier2Talent1;
    public UITier2TalentModification Tier2Talent2;
    List<UITier2TalentModification> Tier2Talents;
    public UITier3TalentModification Tier3Talent1;
    public UITier3TalentModification Tier3Talent2;
    List<UITier3TalentModification> Tier3Talents;

    private void Start()
    {
        Tier1Talents = new List<UITier1TalentModification>() { Tier1Talent1, Tier1Talent2, Tier1Talent3, Tier1Talent4, Tier1Talent5, Tier1Talent6, Tier1Talent7, Tier1Talent8 };
        Tier2Talents = new List<UITier2TalentModification>() { Tier2Talent1, Tier2Talent2 };
        Tier3Talents = new List<UITier3TalentModification>() { Tier3Talent1, Tier3Talent2 };
        Hide();
    }

    public void Hide()
    {
        Tier1Talent1.gameObject.SetActive(false);
        Tier1Talent2.gameObject.SetActive(false);
        Tier1Talent3.gameObject.SetActive(false);
        Tier1Talent4.gameObject.SetActive(false);
        Tier1Talent5.gameObject.SetActive(false);
        Tier1Talent6.gameObject.SetActive(false);
        Tier1Talent7.gameObject.SetActive(false);
        Tier1Talent8.gameObject.SetActive(false);
        Tier2Talent1.gameObject.SetActive(false);
        Tier2Talent2.gameObject.SetActive(false);
        Tier3Talent1.gameObject.SetActive(false);
        Tier3Talent2.gameObject.SetActive(false);
    }

    public void SetRune(LocusRuneItem nR)
    {
        LocusRune = nR;

        for (int i = 0; i < Tier1Talents.Count; i++)
        {
            if (nR.locusRune.Tier1Talents.Count > i)
            {
                Tier1Talents[i].Initialize(nR.locusRune.Tier1Talents[i]);
                Tier1Talents[i].gameObject.SetActive(true);
            }
            else
                Tier1Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier2Talents.Count; i++)
        {
            if (nR.locusRune.Tier2Talents.Count > i)
            {
                Tier2Talents[i].Initialize(nR.locusRune.Tier2Talents[i]);
                Tier2Talents[i].gameObject.SetActive(true);
            }
            else
                Tier2Talents[i].gameObject.SetActive(false);

        }

        for (int i = 0; i < Tier3Talents.Count; i++)
        {
            if (nR.locusRune.Tier3Talents.Count > i)
            {
                Tier3Talents[i].Initialize(nR.locusRune.Tier3Talents[i]);
                Tier3Talents[i].gameObject.SetActive(true);
            }
            else
                Tier3Talents[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < LocusRune.locusRune.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / LocusRune.locusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad), 100 * Mathf.Sin((360 / LocusRune.locusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad));
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(0, -145));
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(-145, -145));
            Tier3Talent2.transform.position = transform.position + (new Vector3(145, -145));
        }
    }
}