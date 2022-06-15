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
    public List<EquipmentSlot.SlotType> availableOn = new List<EquipmentSlot.SlotType>();
    public float Value = 0;
    public float RangeLow = 0;
    public float RangeHigh = 0;
    public float Tier = 1;
    public float DropWeight = 1000;

    public string ReadableName()
    {
        string statName = "";

        if (Method == EMethod.AddPercent || Method == EMethod.MultiplyPercent)
            statName += Value * 100;
        else
            statName += Value;

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
            case EAspect.Cost:
                statName += "Cost";
                break;
            case EAspect.Damage:
                statName += "Damage";
                break;
            case EAspect.Duration:
                statName += "Duration";
                break;
            case EAspect.Resistance:
                statName += "Resistance";
                break;
            case EAspect.Rate:
                statName += "Speed";
                break;
            case EAspect.Area:
                statName += "Area";
                break;
            case EAspect.Chains:
                statName += "Chains";
                break;
            case EAspect.Projectiles:
                statName += "Projectiles";
                break;
            case EAspect.Max:
                statName += "Maximum";
                break;
            case EAspect.Regeneration:
                statName += "Regeneration";
                break;
            case EAspect.Strength:
                statName += "Effect";
                break;
            default:
                break;
        }

        return statName;
    }

    public static EStat RandomElement()
    {
        return (EStat)UnityEngine.Random.Range(300, 311);
    }

    public static EAspect RandomAspect(EStat stat)
    {
        if (stat >= (EStat)300 && stat <= (EStat)310)
        {
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    return EAspect.Damage;
                case 1:
                    return EAspect.Resistance;
                default:
                    return EAspect.None;
            }
        }

        return EAspect.None;
    }

    public static EMethod RandomMethod()
    {
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                return EMethod.Flat;
            case 1:
                return EMethod.AddPercent;
            case 2:
                return EMethod.MultiplyPercent;
            default:
                return EMethod.None;
        }
    }

    public enum EStat
    {
        None = 0,
        #region Cast Mode 100
        Attack = 100,
        CastTime = 101,
        Channel = 102,
        Reserve = 103,
        #endregion
        #region Forms 200
        Arc = 200,
        Aura = 201,
        Burst = 202,
        Command = 203,
        Lance = 204,
        Nova = 205,
        Orb = 206,
        Point = 207,
        SelfCast = 208,
        Strike = 209,
        Wave = 210,
        Weapon = 211,
        Zone = 212,
        #endregion
        #region School 300
        Air = 300,
        Arcane = 301,
        Astral = 302,
        Earth = 303,
        Electricity = 304,
        Ethereal = 305,
        Ice = 306,
        Fire = 307,
        Kinetic = 308,
        Life = 309,
        Water = 310,
        #endregion
        #region UnitStats 400
        Health = 400,
        Mana = 401,
        GlobalDamage = 402,
        Cast = 403,
        Movement = 404,
        Sprint = 405,
        Force = 406,
        #endregion
        Ability = 500,
        #region Statuses 600
        Distortion = 600,
        SoulRot = 601,
        Burn = 602,
        Frostbite = 603,
        Decay = 604,
        #endregion
    }

    public enum EAspect
    {
        None,
        Cost,
        Damage,
        Duration,
        Resistance,
        Rate,
        Max,
        Regeneration,
        Strength,
        Area,
        Chains,
        Projectiles
    }

    public enum EMethod
    {
        None,
        Flat,
        AddPercent,
        MultiplyPercent
    }
}