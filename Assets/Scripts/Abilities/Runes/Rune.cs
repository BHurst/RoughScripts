using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rune
{
    public string runeImageLocation = "";
    public Guid runeId = Guid.NewGuid();
    public string runeName = ".";
    public string runeDescription = "None";
    public int rank = 0;
    public bool harmful = true;
    public bool helpful = false;
    public bool selfHarm = false;

    public enum CastModeRuneTag
    {
        Attack,
        CastTime,
        Channel,
        Charges,
        Instant
    }

    public enum SchoolRuneTag
    {
        Air,
        Arcane,
        Astral,
        Earth,
        Electricity,
        Ethereal,
        Fire,
        Ice,
        Kinetic,
        Life,
        Water
    }

    public enum FormRuneTag
    {
        Arc,
        Aura,
        Beam,
        Command,
        Lance,
        Nova,
        Orb,
        Point,
        SelfCast,
        Strike,
        Wave,
        Weapon,
        Zone
    }

    public enum TriggerTag
    {
        OnCast,
        OnHit
    }


}