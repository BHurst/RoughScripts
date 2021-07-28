using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rune
{
    public Guid runeId = Guid.NewGuid();
    public string runeName = ".";
    public string runeDescription = "None";
    public int rank = 0;
    public bool harmful = true;
    public bool helpful = false;
    public bool selfHarm = false;

    public virtual string RuneImageLocation()
    {
        return "";
    }

    public enum CastModeRuneTag
    {
        Attack,
        CastTime,
        Channel,
        Instant
    }

    public enum SchoolRuneTag
    {
        Air,
        Arcane,
        Astral,
        Electricity,
        Ethereal,
        Ice,
        Fire,
        Kinetic,
        Nature,
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