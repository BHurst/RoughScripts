using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune
{
    public int runeId = 0;
    public string runeName = ".";
    public string runeDescription = "None";

    public enum TargettingRuneTag
    {
        Many,
        Self,
        Single
    }

    public enum EffectRuneTag
    {
        Buff,
        Debuff,
        Harm,
        Heal
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
}