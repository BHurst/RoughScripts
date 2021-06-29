using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusRune
{
    public SimpleTalent Slot1;
    public SimpleTalent Slot2;
    public SimpleTalent Slot3;
    public SimpleTalent Slot4;
    public SimpleTalent Slot5;

    public void PlaceRune(int slot, SimpleTalent talentRune)
    {
        if (slot == 1)
        {
            if(Slot1 == null)
            {
                Slot1 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(1);
                Slot1 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 2)
        {
            if (Slot2 == null)
            {
                Slot2 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(2);
                Slot2 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 3)
        {
            if (Slot3 == null)
            {
                Slot3 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(3);
                Slot3 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 4)
        {
            if (Slot4 == null)
            {
                Slot4 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(4);
                Slot4 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
        if (slot == 5)
        {
            if (Slot5 == null)
            {
                Slot5 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
            else
            {
                RemoveRune(5);
                Slot5 = talentRune;
                GameWorldReferenceClass.GW_Player.totalStats.IncreaseStat(talentRune.modifier.Stat, talentRune.modifier.Aspect, talentRune.modifier.Method, talentRune.modifier.Value);
            }
        }
    }

    public void RemoveRune(int slot)
    {
        if (slot == 1)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(Slot1.modifier.Stat, Slot1.modifier.Aspect, Slot1.modifier.Method, Slot1.modifier.Value);
            Slot1 = null;
        }
        if (slot == 2)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(Slot2.modifier.Stat, Slot2.modifier.Aspect, Slot2.modifier.Method, Slot2.modifier.Value);
            Slot2 = null;
        }
        if (slot == 3)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(Slot3.modifier.Stat, Slot3.modifier.Aspect, Slot3.modifier.Method, Slot3.modifier.Value);
            Slot3 = null;
        }
        if (slot == 4)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(Slot4.modifier.Stat, Slot4.modifier.Aspect, Slot4.modifier.Method, Slot4.modifier.Value);
            Slot4 = null;
        }
        if (slot == 5)
        {
            GameWorldReferenceClass.GW_Player.totalStats.DecreaseStat(Slot5.modifier.Stat, Slot5.modifier.Aspect, Slot5.modifier.Method, Slot5.modifier.Value);
            Slot5 = null;
        }
    }
}