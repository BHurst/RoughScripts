using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAbilityReserve
{
    public float baseReserveRecoveryTime = 1.6f;

    public int airCurrentReserve = 0;
    public int airMaxReserve = 2;

    public int arcaneCurrentReserve = 0;
    public int arcaneMaxReserve = 2;

    public int astralCurrentReserve = 0;
    public int astralMaxReserve = 2;

    public int earthCurrentReserve = 0;
    public int earthMaxReserve = 2;

    public int electricityCurrentReserve = 0;
    public int electricityMaxReserve = 2;

    public int etherealCurrentReserve = 0;
    public int etherealMaxReserve = 2;

    public int fireCurrentReserve = 0;
    public int fireMaxReserve = 2;

    public int iceCurrentReserve = 0;
    public int iceMaxReserve = 2;

    public int kineticCurrentReserve = 0;
    public int kineticMaxReserve = 2;

    public int lifeCurrentReserve = 0;
    public int lifeMaxReserve = 2;

    public int waterCurrentReserve = 0;
    public int waterMaxReserve = 2;

    public void RefillReserve()
    {
        airCurrentReserve = airMaxReserve;
        arcaneCurrentReserve = arcaneMaxReserve;
        astralCurrentReserve = astralMaxReserve;
        earthCurrentReserve = earthMaxReserve;
        electricityCurrentReserve = electricityMaxReserve;
        etherealCurrentReserve = etherealMaxReserve;
        fireCurrentReserve = fireMaxReserve;
        iceCurrentReserve = iceMaxReserve;
        kineticCurrentReserve = kineticMaxReserve;
        lifeCurrentReserve = lifeMaxReserve;
        waterCurrentReserve = waterMaxReserve;
    }

    public void RefillReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                airCurrentReserve = airMaxReserve;
                break;
            case Rune.SchoolRuneTag.Arcane:
                arcaneCurrentReserve = arcaneMaxReserve;
                break;
            case Rune.SchoolRuneTag.Astral:
                astralCurrentReserve = astralMaxReserve;
                break;
            case Rune.SchoolRuneTag.Earth:
                earthCurrentReserve = earthMaxReserve;
                break;
            case Rune.SchoolRuneTag.Electricity:
                electricityCurrentReserve = electricityMaxReserve;
                break;
            case Rune.SchoolRuneTag.Ethereal:
                etherealCurrentReserve = etherealMaxReserve;
                break;
            case Rune.SchoolRuneTag.Fire:
                fireCurrentReserve = fireMaxReserve;
                break;
            case Rune.SchoolRuneTag.Ice:
                iceCurrentReserve = iceMaxReserve;
                break;
            case Rune.SchoolRuneTag.Kinetic:
                kineticCurrentReserve = kineticMaxReserve;
                break;
            case Rune.SchoolRuneTag.Life:
                lifeCurrentReserve = lifeMaxReserve;
                break;
            case Rune.SchoolRuneTag.Water:
                waterCurrentReserve = waterMaxReserve;
                break;
            default:
                break;
        }
    }

    public void RecoverReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                if(airCurrentReserve < airMaxReserve)
                {
                    airCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (arcaneCurrentReserve < arcaneMaxReserve)
                {
                    arcaneCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (astralCurrentReserve < astralMaxReserve)
                {
                    astralCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (earthCurrentReserve < earthMaxReserve)
                {
                    earthCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (electricityCurrentReserve < electricityMaxReserve)
                {
                    electricityCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (etherealCurrentReserve < etherealMaxReserve)
                {
                    etherealCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (fireCurrentReserve < fireMaxReserve)
                {
                    fireCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (iceCurrentReserve < iceMaxReserve)
                {
                    iceCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (kineticCurrentReserve < kineticMaxReserve)
                {
                    kineticCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (lifeCurrentReserve < lifeMaxReserve)
                {
                    lifeCurrentReserve++;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (waterCurrentReserve < waterMaxReserve)
                {
                    waterCurrentReserve++;
                }
                break;
            default:
                break;
        }
    }

    public void ExpendCharge(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                if (airCurrentReserve >= 0)
                {
                    airCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (arcaneCurrentReserve >= 0)
                {
                    arcaneCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (astralCurrentReserve >= 0)
                {
                    astralCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (earthCurrentReserve >= 0)
                {
                    earthCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (electricityCurrentReserve >= 0)
                {
                    electricityCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (etherealCurrentReserve >= 0)
                {
                    etherealCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (fireCurrentReserve >= 0)
                {
                    fireCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (iceCurrentReserve >= 0)
                {
                    iceCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (kineticCurrentReserve >= 0)
                {
                    kineticCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (lifeCurrentReserve >= 0)
                {
                    lifeCurrentReserve--;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (waterCurrentReserve >= 0)
                {
                    waterCurrentReserve--;
                }
                break;
            default:
                break;
        }
    }

    public int CheckReserves(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airCurrentReserve;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneCurrentReserve;
            case Rune.SchoolRuneTag.Astral:
                return astralCurrentReserve;
            case Rune.SchoolRuneTag.Earth:
                return earthCurrentReserve;
            case Rune.SchoolRuneTag.Electricity:
                return electricityCurrentReserve;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealCurrentReserve;
            case Rune.SchoolRuneTag.Fire:
                return fireCurrentReserve;
            case Rune.SchoolRuneTag.Ice:
                return iceCurrentReserve;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticCurrentReserve;
            case Rune.SchoolRuneTag.Life:
                return lifeCurrentReserve;
            case Rune.SchoolRuneTag.Water:
                return waterCurrentReserve;
            default:
                return 0;
        }
    }

    public int CheckMaxReserve(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airMaxReserve;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneMaxReserve;
            case Rune.SchoolRuneTag.Astral:
                return astralMaxReserve;
            case Rune.SchoolRuneTag.Earth:
                return earthMaxReserve;
            case Rune.SchoolRuneTag.Electricity:
                return electricityMaxReserve;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealMaxReserve;
            case Rune.SchoolRuneTag.Fire:
                return fireMaxReserve;
            case Rune.SchoolRuneTag.Ice:
                return iceMaxReserve;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticMaxReserve;
            case Rune.SchoolRuneTag.Life:
                return lifeMaxReserve;
            case Rune.SchoolRuneTag.Water:
                return waterMaxReserve;
            default:
                return 0;
        }
    }

    public bool IsReserveFull(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airCurrentReserve == airMaxReserve;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneCurrentReserve == arcaneMaxReserve;
            case Rune.SchoolRuneTag.Astral:
                return astralCurrentReserve == astralMaxReserve;
            case Rune.SchoolRuneTag.Earth:
                return earthCurrentReserve == earthMaxReserve;
            case Rune.SchoolRuneTag.Electricity:
                return electricityCurrentReserve == electricityMaxReserve;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealCurrentReserve == etherealMaxReserve;
            case Rune.SchoolRuneTag.Fire:
                return fireCurrentReserve == fireMaxReserve;
            case Rune.SchoolRuneTag.Ice:
                return iceCurrentReserve == iceMaxReserve;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticCurrentReserve == kineticMaxReserve;
            case Rune.SchoolRuneTag.Life:
                return lifeCurrentReserve == lifeMaxReserve;
            case Rune.SchoolRuneTag.Water:
                return waterCurrentReserve == waterMaxReserve;
            default:
                return true;
        }
    }
}