using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocusRune : MonoBehaviour
{
    public CharacterTalentsPane characterTalents;
    public LocusRune LocusRune;
    UITier1Talent Tier1Talent1;
    UITier1Talent Tier1Talent2;
    UITier1Talent Tier1Talent3;
    UITier1Talent Tier1Talent4;
    UITier1Talent Tier1Talent5;
    UITier1Talent Tier1Talent6;
    UITier1Talent Tier1Talent7;
    UITier1Talent Tier1Talent8;
    List<UITier1Talent> Tier1Talents;
    UITier3Talent Tier3Talent1;
    UITier3Talent Tier3Talent2;
    List<UITier3Talent> Tier3Talents;

    private void Awake()
    {
        if (characterTalents == null)
            characterTalents = GameObject.Find("CharacterTalentCanvas").GetComponent<CharacterTalentsPane>();

        if (Tier1Talent1 == null)
            transform.Find("Tier1Talent1").TryGetComponent<UITier1Talent>(out Tier1Talent1);
        if (Tier1Talent2 == null)
            transform.Find("Tier1Talent2").TryGetComponent<UITier1Talent>(out Tier1Talent2);
        if (Tier1Talent3 == null)
            transform.Find("Tier1Talent3").TryGetComponent<UITier1Talent>(out Tier1Talent3);
        if (Tier1Talent4 == null)
            transform.Find("Tier1Talent4").TryGetComponent<UITier1Talent>(out Tier1Talent4);
        if (Tier1Talent5 == null)
            transform.Find("Tier1Talent5").TryGetComponent<UITier1Talent>(out Tier1Talent5);
        if (Tier1Talent6 == null)
            transform.Find("Tier1Talent6").TryGetComponent<UITier1Talent>(out Tier1Talent6);
        if (Tier1Talent7 == null)
            transform.Find("Tier1Talent7").TryGetComponent<UITier1Talent>(out Tier1Talent7);
        if (Tier1Talent8 == null)
            transform.Find("Tier1Talent8").TryGetComponent<UITier1Talent>(out Tier1Talent8);

        if (Tier3Talent1 == null)
            transform.Find("Tier3Talent1").TryGetComponent<UITier3Talent>(out Tier3Talent1);
        if (Tier3Talent2 == null)
            transform.Find("Tier3Talent2").TryGetComponent<UITier3Talent>(out Tier3Talent2);
    }

    public void DelayedStart()
    {
        Tier1Talents = new List<UITier1Talent>() { Tier1Talent1, Tier1Talent2, Tier1Talent3, Tier1Talent4, Tier1Talent5, Tier1Talent6, Tier1Talent7, Tier1Talent8 };
        Tier3Talents = new List<UITier3Talent>() { Tier3Talent1, Tier3Talent2 };
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
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * characterTalents.talentContent.transform.localScale.x, 100 * Mathf.Sin((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * characterTalents.talentContent.transform.localScale.x);
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(0, -150) * characterTalents.talentContent.transform.localScale.x);
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(-150, -150) * characterTalents.talentContent.transform.localScale.x);
            Tier3Talent2.transform.position = transform.position + (new Vector3(150, -150) * characterTalents.talentContent.transform.localScale.x);
        }
    }
}