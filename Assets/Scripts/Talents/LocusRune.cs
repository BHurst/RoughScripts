using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRune
{
    public SimpleTalent slot1;
    public SimpleTalent slot2;
    public SimpleTalent slot3;
    public SimpleTalent slot4;
    public SimpleTalent slot5;

    public void PlaceRune(int slot, SimpleTalent talentRune)
    {
        if (slot == 1)
        {
            if(slot1 == null)
            {
                slot1 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(1);
                slot1 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 2)
        {
            if (slot2 == null)
            {
                slot2 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(2);
                slot2 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 3)
        {
            if (slot3 == null)
            {
                slot3 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(3);
                slot3 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 4)
        {
            if (slot4 == null)
            {
                slot4 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(4);
                slot4 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 5)
        {
            if (slot5 == null)
            {
                slot5 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(5);
                slot5 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
    }

    public void RemoveRune(int slot)
    {
        if (slot == 1)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(slot1.modifier.Stat, slot1.modifier.Aspect, slot1.modifier.Method, slot1.modifier.Value);
            slot1 = null;
        }
        if (slot == 2)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(slot2.modifier.Stat, slot2.modifier.Aspect, slot2.modifier.Method, slot2.modifier.Value);
            slot2 = null;
        }
        if (slot == 3)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(slot3.modifier.Stat, slot3.modifier.Aspect, slot3.modifier.Method, slot3.modifier.Value);
            slot3 = null;
        }
        if (slot == 4)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(slot4.modifier.Stat, slot4.modifier.Aspect, slot4.modifier.Method, slot4.modifier.Value);
            slot4 = null;
        }
        if (slot == 5)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(slot5.modifier.Stat, slot5.modifier.Aspect, slot5.modifier.Method, slot5.modifier.Value);
            slot5 = null;
        }
    }
}