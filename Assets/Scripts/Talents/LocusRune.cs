using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRune
{
    public string locusRuneName = "";
    public static int minTier1Talents = 2;
    public static int maxTier1Talents = 8;
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public static int minTier3Talents = 1;
    public static int maxTier3Talents = 2;
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();

    public void PlaceT1Rune(Tier1Talent talentRune)
    {
        Tier1Talent foundTalent = Tier1Talents.Find(x => x.TalentId == talentRune.TalentId);
        if(Tier1Talents.Count <= maxTier1Talents)
        {
            if (foundTalent == null)
                Tier1Talents.Add(talentRune);
            else
            {
                RemoveT1Rune(foundTalent);
                Tier1Talents.Add(talentRune);
            }
        }
    }

    public void RemoveT1Rune(Tier1Talent talentRune)
    {
        Tier1Talent foundTalent = Tier1Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
            Tier1Talents.Remove(foundTalent);
    }

    public void PlaceT3Rune(Tier3Talent talentRune, RootCharacter owner)
    {
        Tier3Talent foundTalent = Tier3Talents.Find(x => x.TalentId == talentRune.TalentId);
        if (Tier3Talents.Count <= maxTier1Talents)
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
        int t1amt = Random.Range(minTier1Talents, maxTier1Talents);
        int t3amt = Random.Range(minTier3Talents, maxTier3Talents);

        LocusRune newLocusRune = new LocusRune();

        for (int i = 0; i < t1amt; i++)
        {
            Tier1Talent t1T = Tier1Talent.NewRandomTier1Talent();
            newLocusRune.Tier1Talents.Add(t1T);
        }

        for (int i = 0; i < t3amt; i++)
        {
            Tier3Talent t3T = new T3_DotConvert();
            newLocusRune.Tier3Talents.Add(t3T);
        }

        return newLocusRune;
    }
}