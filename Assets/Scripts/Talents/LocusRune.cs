using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LocusRune
{
    public string locusRuneName = "";
    public const int minTier1Talents = 2;
    public const int maxTier1Talents = 8;
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public const int minTier2Talents = 0;
    public const int maxTier2Talents = 2;
    public List<Tier2Talent> Tier2Talents = new List<Tier2Talent>();
    public const int minTier3Talents = 0;
    public const int maxTier3Talents = 2;
    [NonSerialized]
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();
    public List<UITalent_Serialized> Tier3TalentNames = new List<UITalent_Serialized>();

    public int baseTier1RerollCost = 2;
    public int currentTier1RerollCost = 2;
    public int baseTier2RerollCost = 4;
    public int currentTier2RerollCost = 4;
    public int baseTier3RerollCost = 8;
    public int currentTier3RerollCost = 8;

    public int breakdownRefund = 10;

    public void PlaceT1Rune(Tier1Talent talentRune)
    {
        if (Tier1Talents.Count < maxTier1Talents)
        {
            Tier1Talents.Add(talentRune);
        }
    }

    public void RemoveT1Rune(Tier1Talent talentRune)
    {
        Tier1Talent foundTalent = Tier1Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
            Tier1Talents.Remove(foundTalent);
    }

    public void PlaceT2Rune(Tier2Talent talentRune)
    {
        if (Tier1Talents.Count < maxTier1Talents)
        {
            Tier2Talents.Add(talentRune);
        }
    }

    public void RemoveT2Rune(Tier2Talent talentRune)
    {
        Tier2Talent foundTalent = Tier2Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
            Tier2Talents.Remove(foundTalent);
    }

    public void PlaceT3Rune(Tier3Talent talentRune, RootCharacter owner)
    {
        Tier3Talent foundTalent = Tier3Talents.Find(x => x.TalentId == talentRune.TalentId);
        if (Tier3Talents.Count < maxTier1Talents)
        {
            if (foundTalent == null)
            {
                talentRune.owner = owner;
                Tier3Talents.Add(talentRune);
            }
            else
            {
                RemoveT3Rune(foundTalent);
                talentRune.owner = owner;
                Tier3Talents.Add(talentRune);
            }
        }
    }

    public void RemoveT3Rune(Tier3Talent talentRune)
    {
        Tier3Talent foundTalent = Tier3Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
        {
            Tier3Talents.Remove(foundTalent);
        }
    }

    public static LocusRune RandomRune()
    {
        int t1amt = UnityEngine.Random.Range(minTier1Talents, maxTier1Talents + 1);
        int t2amt = UnityEngine.Random.Range(minTier2Talents, maxTier2Talents + 1);
        int t3amt = UnityEngine.Random.Range(minTier3Talents, maxTier3Talents + 1);

        LocusRune newLocusRune = new LocusRune();

        for (int i = 0; i < t1amt; i++)
        {
            Tier1Talent t1T = Tier1Talent.NewRandomTier1Talent();
            newLocusRune.Tier1Talents.Add(t1T);
        }

        for (int i = 0; i < t2amt; i++)
        {
            Tier2Talent t2T = Tier2Talent.NewRandomTier2Talent();
            newLocusRune.Tier2Talents.Add(t2T);
        }

        for (int i = 0; i < t3amt; i++)
        {
            Tier3Talent t3T = new T3_DotConvert();
            newLocusRune.Tier3Talents.Add(t3T);
        }

        return newLocusRune;
    }

    public void FillOutTier3Talents()
    {
        Tier3Talents = new List<Tier3Talent>();
        for (int i = 0; i < Tier3TalentNames.Count; i++)
        {
            Tier3Talents.Add((Tier3Talent)Activator.CreateInstance(Type.GetType(Tier3TalentNames[i].tier3TalentName)));
            Tier3Talents[i].active = Tier3TalentNames[i].active;
        }
    }
}