using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRune
{
    public int maxSimpleTalents = 5;
    public List<SimpleTalent> simpleTalents = new List<SimpleTalent>();
    public int maxComplexTalents = 2;
    public List<ComplexTalent> complexTalents = new List<ComplexTalent>();

    public void PlaceSimpleRune(SimpleTalent talentRune)
    {
        SimpleTalent foundTalent = simpleTalents.Find(x => x.TalentId == talentRune.TalentId);
        if(simpleTalents.Count <= maxSimpleTalents)
        {
            if (foundTalent == null)
                simpleTalents.Add(talentRune);
            else
            {
                RemoveSimpleRune(foundTalent);
                simpleTalents.Add(talentRune);
            }
        }
    }

    public void RemoveSimpleRune(SimpleTalent talentRune)
    {
        SimpleTalent foundTalent = simpleTalents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
            simpleTalents.Remove(foundTalent);
    }

    public void PlaceComplexRune(ComplexTalent talentRune, RootUnit owner)
    {
        ComplexTalent foundTalent = complexTalents.Find(x => x.TalentId == talentRune.TalentId);
        if (complexTalents.Count <= maxSimpleTalents)
        {
            if (foundTalent == null)
            {
                talentRune.owner = owner;
                complexTalents.Add(talentRune);
            }
            else
            {
                RemoveComplexRune(foundTalent);
                talentRune.owner = owner;
                complexTalents.Add(talentRune);
            }
        }
    }

    public void RemoveComplexRune(ComplexTalent talentRune)
    {
        ComplexTalent foundTalent = complexTalents.Find(x => x.TalentId == talentRune.TalentId);

        if (foundTalent != null)
        {
            complexTalents.Remove(foundTalent);
        }
    }
}