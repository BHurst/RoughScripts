using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRune
{
    public int minTier1Talents = 2;
    public int maxTier1Talents = 8;
    public List<Tier1Talent> Tier1Talents = new List<Tier1Talent>();
    public int minTier3Talents = 1;
    public int maxTier3Talents = 2;
    public List<Tier3Talent> Tier3Talents = new List<Tier3Talent>();

    public void PlaceSimpleRune(Tier1Talent talentRune)
    {
        Tier1Talent foundTalent = Tier1Talents.Find(x => x.TalentId == talentRune.TalentId);
        if(Tier1Talents.Count <= maxTier1Talents)
        {
            if (foundTalent == null)
                Tier1Talents.Add(talentRune);
            else
            {
                RemoveSimpleRune(foundTalent);
                Tier1Talents.Add(talentRune);
            }
        }
    }

    public void RemoveSimpleRune(Tier1Talent talentRune)
    {
        Tier1Talent foundTalent = Tier1Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
            Tier1Talents.Remove(foundTalent);
    }

    public void PlaceComplexRune(Tier3Talent talentRune, RootCharacter owner)
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
                RemoveComplexRune(foundTalent);
                talentRune.owner = owner;
                Tier3Talents.Add(talentRune);
            }
        }
    }

    public void RemoveComplexRune(Tier3Talent talentRune)
    {
        Tier3Talent foundTalent = Tier3Talents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
        {
            Tier3Talents.Remove(foundTalent);
        }
    }
}