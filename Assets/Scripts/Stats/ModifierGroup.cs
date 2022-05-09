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

    public string ReadableName()
    {
        string statName = "";

        statName += Value * 100;

        switch (Method)
        {
            case EMethod.None:
                break;
            case EMethod.Flat:
                statName += " Additional ";
                break;
            case EMethod.AddPercent:
                statName += "% Increased ";
                break;
            case EMethod.MultiplyPercent:
                statName += "% More ";
                break;
            default:
                break;
        }

        if (Stat != EStat.None)
            statName += Stat + " ";

        switch (Aspect)
        {
            case EAspect.None:
                break;
            case EAspect.Damage:
                statName += "Damage";
                break;
            case EAspect.DamageTaken:
                statName += "Damage Taken";
                break;
            case EAspect.Rate:
                statName += "Speed";
                break;
            default:
                break;
        }

        return statName;
    }

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