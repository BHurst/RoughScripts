using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocusRune : MonoBehaviour
{
    public bool active = false;
    public int investment = 0;
    public int investmentForBonus = 0;
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
    public List<UITier1Talent> Tier1Talents;
    UITier2Talent Tier2Talent1;
    UITier2Talent Tier2Talent2;
    public List<UITier2Talent> Tier2Talents;
    UITier3Talent Tier3Talent1;
    UITier3Talent Tier3Talent2;
    public List<UITier3Talent> Tier3Talents;

    public void SetReferences()
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

        if (Tier2Talent1 == null)
            transform.Find("Tier2Talent1").TryGetComponent<UITier2Talent>(out Tier2Talent1);
        if (Tier2Talent2 == null)
            transform.Find("Tier2Talent2").TryGetComponent<UITier2Talent>(out Tier2Talent2);

        if (Tier3Talent1 == null)
            transform.Find("Tier3Talent1").TryGetComponent<UITier3Talent>(out Tier3Talent1);
        if (Tier3Talent2 == null)
            transform.Find("Tier3Talent2").TryGetComponent<UITier3Talent>(out Tier3Talent2);

        Tier1Talents = new List<UITier1Talent>() { Tier1Talent1, Tier1Talent2, Tier1Talent3, Tier1Talent4, Tier1Talent5, Tier1Talent6, Tier1Talent7, Tier1Talent8 };
        foreach (UITier1Talent tal in Tier1Talents)
            tal.parentRune = this;
        Tier2Talents = new List<UITier2Talent>() { Tier2Talent1, Tier2Talent2 };
        foreach (UITier2Talent tal in Tier2Talents)
            tal.parentRune = this;
        Tier3Talents = new List<UITier3Talent>() { Tier3Talent1, Tier3Talent2 };
        foreach (UITier3Talent tal in Tier3Talents)
            tal.parentRune = this;
    }

    private void Start()
    {
        SetReferences();

        SetRune(LocusRune);
    }

    public void SetRune(LocusRune nR)
    {
        LocusRune = nR;
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

        for (int i = 0; i < LocusRune.Tier1Talents.Count; i++)
        {
            Tier1Talents[i].transform.position = transform.position + new Vector3(100 * Mathf.Cos((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * characterTalents.talentContent.transform.localScale.x, 100 * Mathf.Sin((360 / LocusRune.Tier1Talents.Count * i - 90) * -1 * Mathf.Deg2Rad) * characterTalents.talentContent.transform.localScale.x);
        }

        if (Tier3Talents.Count == 1)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(0, -145) * characterTalents.talentContent.transform.localScale.x);
        }
        else if (Tier3Talents.Count == 2)
        {
            Tier3Talent1.transform.position = transform.position + (new Vector3(-145, -145) * characterTalents.talentContent.transform.localScale.x);
            Tier3Talent2.transform.position = transform.position + (new Vector3(145, -145) * characterTalents.talentContent.transform.localScale.x);
        }
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

    public void FillFromSerialized(UILocusRune_Serialized uiLocusRune_Serialized)
    {
        active = uiLocusRune_Serialized.active;
        LocusRune = uiLocusRune_Serialized.LocusRune;
        LocusRune.Tier3Talents = new List<Tier3Talent>();
        for (int i = 0; i < uiLocusRune_Serialized.ActiveTier3Talents.Count; i++)
        {
            LocusRune.Tier3Talents.Add((Tier3Talent)Activator.CreateInstance(Type.GetType(uiLocusRune_Serialized.ActiveTier3Talents[i].tier3TalentName)));
        }

        SetRune(LocusRune);
        for (int i = 0; i < uiLocusRune_Serialized.ActiveTier1Talents.Count; i++)
        {
            if (uiLocusRune_Serialized.ActiveTier1Talents[i] == true)
                Tier1Talents[i].Toggle();
        }
        for (int i = 0; i < uiLocusRune_Serialized.ActiveTier2Talents.Count; i++)
        {
            if (uiLocusRune_Serialized.ActiveTier2Talents[i] == true)
                Tier2Talents[i].Toggle();
        }
        for (int i = 0; i < uiLocusRune_Serialized.ActiveTier3Talents.Count; i++)
        {
            if (uiLocusRune_Serialized.ActiveTier3Talents[i].active == true)
                Tier3Talents[i].Toggle();
        }
    }
}