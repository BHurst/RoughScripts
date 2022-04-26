using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModifierGroup
{
    public EStat Stat = EStat.None;
    public EAspect Aspect = EAspect.None;
    public EMethod Method = EMethod.None;
    public float Value = 0;

    public enum EStat
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
        Earth,
        Electricity,
        Ethereal,
        Ice,
        Fire,
        Kinetic,
        Life,
        Water,
        #endregion
        #region UnitStats
        GlobalDamage,
        Cast,
        Attack,
        MoveSpeed
        #endregion
    }

    public enum EAspect
    {
        None,
        Damage,
        DamageTaken,
        Movement,
        Rate
    }

    public enum EMethod
    {
        None,
        Flat,
        AddPercent,
        MultiplyPercent
    }
}