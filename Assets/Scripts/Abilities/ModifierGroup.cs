using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModifierGroup
{
    public eStat Stat = eStat.None;
    public eAspect Aspect = eAspect.None;
    public eMethod Method = eMethod.None;
    public float Value = 0;

    public enum eStat
    {
        None,
        #region Forms
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
        Zone,
        #endregion
        #region School
        Air,
        Arcane,
        Astral,
        Electricity,
        Ethereal,
        Ice,
        Fire,
        Kinetic,
        Nature,
        Water,
        #endregion
        #region UnitStats
        GlobalDamage,
        Cast,
        Attack,
        MoveSpeed
        #endregion
    }

    public enum eAspect
    {
        None,
        DamageDone,
        DamageTaken,
        Movement,
        Rate
    }

    public enum eMethod
    {
        None,
        Flat,
        AddPercent,
        MultiplyPercent
    }
}