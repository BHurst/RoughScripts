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

        if (Aspect == EAspect.Resistance)
        {
            statName = ((int)(((1 / -(1 + Value)) + 1) * 10000) / 100f) + "% " + Stat + " Resistance";
            return statName;
        }

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
            case EAspect.Damage:
                statName += "Damage";
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
        switch (UnityEngine.Random.Range(0,11))
        {
            case 0:
                return EStat.Air;
            case 1:
                return EStat.Arcane;
            case 2:
                return EStat.Astral;
            case 3:
                return EStat.Earth;
            case 4:
                return EStat.Electricity;
            case 5:
                return EStat.Ethereal;
            case 6:
                return EStat.Ice;
            case 7:
                return EStat.Fire;
            case 8:
                return EStat.Kinetic;
            case 9:
                return EStat.Life;
            case 10:
                return EStat.Water;
            default:
                return EStat.None;
        }
    }

    public enum EStat
    {
        None,
        #region Cast Mode
        Attack,
        CastTime,
        Channel,
        Reserve,
        #endregion
        #region Forms
        Arc,
        Aura,
        Burst,
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
        Health,
        Mana,
        GlobalDamage,
        Cast,
        Movement,
        Sprint,
        Force,
        #endregion
        Ability
    }

    public enum EAspect
    {
        None,
        Damage,
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