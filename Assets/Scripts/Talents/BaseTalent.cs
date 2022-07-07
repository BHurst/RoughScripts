using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseTalent
{
    public Guid TalentId;
    public string talentName;
    public int itemLevel;
    public int quality = 0;
    public int cost;
    public Tier tier = Tier.tier1;

    public enum Tier
    {
        tier1,
        tier2,
        tier3
    }
}