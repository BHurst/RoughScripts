using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UILocusRune_Serialized
{
    public bool active = false;
    public LocusRune LocusRune;
    public List<bool> ActiveTier1Talents;
    public List<bool> ActiveTier2Talents;
    public List<UITalent_Serialized> ActiveTier3Talents;

    public void FillFromUnserialized(UILocusRune uiLocusRune)
    {
        active = uiLocusRune.active;
        LocusRune = uiLocusRune.LocusRune;
        ActiveTier1Talents = new List<bool>();
        foreach (var item in uiLocusRune.Tier1Talents)
        {
            if (item.talentInSlot.talentName != "")
                ActiveTier1Talents.Add(item.active);
        }
        ActiveTier2Talents = new List<bool>();
        foreach (var item in uiLocusRune.Tier2Talents)
        {
            if (item.talentInSlot.talentName != "")
                ActiveTier2Talents.Add(item.active);
        }
        ActiveTier3Talents = new List<UITalent_Serialized>();
        foreach (var item in uiLocusRune.Tier3Talents)
        {
            if (item.talentInSlot.talentName != "")
            {
                UITalent_Serialized newTalent = new UITalent_Serialized();
                newTalent.active = item.active;
                newTalent.tier3TalentName = item.talentInSlot.ToString();
                ActiveTier3Talents.Add(newTalent);
            }
        }
    }
}