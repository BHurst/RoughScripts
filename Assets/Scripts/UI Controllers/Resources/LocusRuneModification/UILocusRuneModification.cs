using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocusRuneModification : MonoBehaviour
{
    public LocusRune LocusRune;
    UITier1TalentModification Tier1Talent1;
    UITier1TalentModification Tier1Talent2;
    UITier1TalentModification Tier1Talent3;
    UITier1TalentModification Tier1Talent4;
    UITier1TalentModification Tier1Talent5;
    UITier1TalentModification Tier1Talent6;
    UITier1TalentModification Tier1Talent7;
    UITier1TalentModification Tier1Talent8;
    List<UITier1TalentModification> Tier1Talents;
    UITier2TalentModification Tier2Talent1;
    UITier2TalentModification Tier2Talent2;
    List<UITier2TalentModification> Tier2Talents;
    UITier3TalentModification Tier3Talent1;
    UITier3TalentModification Tier3Talent2;
    List<UITier3TalentModification> Tier3Talents;

    private void Awake()
    {
        if (Tier1Talent1 == null)
            transform.Find("Tier1Talent1").TryGetComponent<UITier1TalentModification>(out Tier1Talent1);
        if (Tier1Talent2 == null)
            transform.Find("Tier1Talent2").TryGetComponent<UITier1TalentModification>(out Tier1Talent2);
        if (Tier1Talent3 == null)
            transform.Find("Tier1Talent3").TryGetComponent<UITier1TalentModification>(out Tier1Talent3);
        if (Tier1Talent4 == null)
            transform.Find("Tier1Talent4").TryGetComponent<UITier1TalentModification>(out Tier1Talent4);
        if (Tier1Talent5 == null)
            transform.Find("Tier1Talent5").TryGetComponent<UITier1TalentModification>(out Tier1Talent5);
        if (Tier1Talent6 == null)
            transform.Find("Tier1Talent6").TryGetComponent<UITier1TalentModification>(out Tier1Talent6);
        if (Tier1Talent7 == null)
            transform.Find("Tier1Talent7").TryGetComponent<UITier1TalentModification>(out Tier1Talent7);
        if (Tier1Talent8 == null)
            transform.Find("Tier1Talent8").TryGetComponent<UITier1TalentModification>(out Tier1Talent8);

        if (Tier2Talent1 == null)
            transform.Find("Tier2Talent1").TryGetComponent<UITier2TalentModification>(out Tier2Talent1);
        if (Tier2Talent2 == null)
            transform.Find("Tier2Talent2").TryGetComponent<UITier2TalentModification>(out Tier2Talent2);

        if (Tier3Talent1 == null)
            transform.Find("Tier3Talent1").TryGetComponent<UITier3TalentModification>(out Tier3Talent1);
        if (Tier3Talent2 == null)
            transform.Find("Tier3Talent2").TryGetComponent<UITier3TalentModification>(out Tier3Talent2);
    }

    private void Start()
    {
        Tier1Talents = new List<UITier1TalentModification>() { Tier1Talent1, Tier1Talent2, Tier1Talent3, Tier1Talent4, Tier1Talent5, Tier1Talent6, Tier1Talent7, Tier1Talent8 };
        Tier2Talents = new List<UITier2TalentModification>() { Tier2Talent1, Tier2Talent2 };
        Tier3Talents = new List<UITier3TalentModification>() { Tier3Talent1, Tier3Talent2 };

        SetRune(LocusRune.RandomRune());
    }

    public void SetRune(LocusRune nR)
    {
        LocusRune = nR;

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

        for (int i = 0; i < LocusRune.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad), 100 * Mathf.Sin((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad));
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