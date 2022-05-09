using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAbilityCharges
{
    public float baseChargeRecoveryTime = 1.6f;

    public int airCurrentCharges = 0;
    public int airMaxCharges = 2;

    public int arcaneCurrentCharges = 0;
    public int arcaneMaxCharges = 2;

    public int astralCurrentCharges = 0;
    public int astralMaxCharges = 2;

    public int earthCurrentCharges = 0;
    public int earthMaxCharges = 2;

    public int electricityCurrentCharges = 0;
    public int electricityMaxCharges = 2;

    public int etherealCurrentCharges = 0;
    public int etherealMaxCharges = 2;

    public int fireCurrentCharges = 0;
    public int fireMaxCharges = 2;

    public int iceCurrentCharges = 0;
    public int iceMaxCharges = 2;

    public int kineticCurrentCharges = 0;
    public int kineticMaxCharges = 2;

    public int lifeCurrentCharges = 0;
    public int lifeMaxCharges = 2;

    public int waterCurrentCharges = 0;
    public int waterMaxCharges = 2;

    public void RefillCharges()
    {
        airCurrentCharges = airMaxCharges;
        arcaneCurrentCharges = arcaneMaxCharges;
        astralCurrentCharges = astralMaxCharges;
        earthCurrentCharges = earthMaxCharges;
        electricityCurrentCharges = electricityMaxCharges;
        etherealCurrentCharges = etherealMaxCharges;
        fireCurrentCharges = fireMaxCharges;
        iceCurrentCharges = iceMaxCharges;
        kineticCurrentCharges = kineticMaxCharges;
        lifeCurrentCharges = lifeMaxCharges;
        waterCurrentCharges = waterMaxCharges;
    }

    public void RefillCharges(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                airCurrentCharges = airMaxCharges;
                break;
            case Rune.SchoolRuneTag.Arcane:
                arcaneCurrentCharges = arcaneMaxCharges;
                break;
            case Rune.SchoolRuneTag.Astral:
                astralCurrentCharges = astralMaxCharges;
                break;
            case Rune.SchoolRuneTag.Earth:
                earthCurrentCharges = earthMaxCharges;
                break;
            case Rune.SchoolRuneTag.Electricity:
                electricityCurrentCharges = electricityMaxCharges;
                break;
            case Rune.SchoolRuneTag.Ethereal:
                etherealCurrentCharges = etherealMaxCharges;
                break;
            case Rune.SchoolRuneTag.Fire:
                fireCurrentCharges = fireMaxCharges;
                break;
            case Rune.SchoolRuneTag.Ice:
                iceCurrentCharges = iceMaxCharges;
                break;
            case Rune.SchoolRuneTag.Kinetic:
                kineticCurrentCharges = kineticMaxCharges;
                break;
            case Rune.SchoolRuneTag.Life:
                lifeCurrentCharges = lifeMaxCharges;
                break;
            case Rune.SchoolRuneTag.Water:
                waterCurrentCharges = waterMaxCharges;
                break;
            default:
                break;
        }
    }

    public void RecoverCharge(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                if(airCurrentCharges < airMaxCharges)
                {
                    airCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (arcaneCurrentCharges < arcaneMaxCharges)
                {
                    arcaneCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (astralCurrentCharges < astralMaxCharges)
                {
                    astralCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (earthCurrentCharges < earthMaxCharges)
                {
                    earthCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (electricityCurrentCharges < electricityMaxCharges)
                {
                    electricityCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (etherealCurrentCharges < etherealMaxCharges)
                {
                    etherealCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (fireCurrentCharges < fireMaxCharges)
                {
                    fireCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (iceCurrentCharges < iceMaxCharges)
                {
                    iceCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (kineticCurrentCharges < kineticMaxCharges)
                {
                    kineticCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (lifeCurrentCharges < lifeMaxCharges)
                {
                    lifeCurrentCharges++;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (waterCurrentCharges < waterMaxCharges)
                {
                    waterCurrentCharges++;
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
                if (airCurrentCharges >= 0)
                {
                    airCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Arcane:
                if (arcaneCurrentCharges >= 0)
                {
                    arcaneCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Astral:
                if (astralCurrentCharges >= 0)
                {
                    astralCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Earth:
                if (earthCurrentCharges >= 0)
                {
                    earthCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Electricity:
                if (electricityCurrentCharges >= 0)
                {
                    electricityCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Ethereal:
                if (etherealCurrentCharges >= 0)
                {
                    etherealCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Fire:
                if (fireCurrentCharges >= 0)
                {
                    fireCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Ice:
                if (iceCurrentCharges >= 0)
                {
                    iceCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Kinetic:
                if (kineticCurrentCharges >= 0)
                {
                    kineticCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Life:
                if (lifeCurrentCharges >= 0)
                {
                    lifeCurrentCharges--;
                }
                break;
            case Rune.SchoolRuneTag.Water:
                if (waterCurrentCharges >= 0)
                {
                    waterCurrentCharges--;
                }
                break;
            default:
                break;
        }
    }

    public int CheckCharge(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airCurrentCharges;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneCurrentCharges;
            case Rune.SchoolRuneTag.Astral:
                return astralCurrentCharges;
            case Rune.SchoolRuneTag.Earth:
                return earthCurrentCharges;
            case Rune.SchoolRuneTag.Electricity:
                return electricityCurrentCharges;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealCurrentCharges;
            case Rune.SchoolRuneTag.Fire:
                return fireCurrentCharges;
            case Rune.SchoolRuneTag.Ice:
                return iceCurrentCharges;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticCurrentCharges;
            case Rune.SchoolRuneTag.Life:
                return lifeCurrentCharges;
            case Rune.SchoolRuneTag.Water:
                return waterCurrentCharges;
            default:
                return 0;
        }
    }

    public int CheckMaxCharge(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airMaxCharges;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneMaxCharges;
            case Rune.SchoolRuneTag.Astral:
                return astralMaxCharges;
            case Rune.SchoolRuneTag.Earth:
                return earthMaxCharges;
            case Rune.SchoolRuneTag.Electricity:
                return electricityMaxCharges;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealMaxCharges;
            case Rune.SchoolRuneTag.Fire:
                return fireMaxCharges;
            case Rune.SchoolRuneTag.Ice:
                return iceMaxCharges;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticMaxCharges;
            case Rune.SchoolRuneTag.Life:
                return lifeMaxCharges;
            case Rune.SchoolRuneTag.Water:
                return waterMaxCharges;
            default:
                return 0;
        }
    }

    public bool IsChargeFull(Rune.SchoolRuneTag schoolRuneTag)
    {
        switch (schoolRuneTag)
        {
            case Rune.SchoolRuneTag.Air:
                return airCurrentCharges == airMaxCharges;
            case Rune.SchoolRuneTag.Arcane:
                return arcaneCurrentCharges == arcaneMaxCharges;
            case Rune.SchoolRuneTag.Astral:
                return astralCurrentCharges == astralMaxCharges;
            case Rune.SchoolRuneTag.Earth:
                return earthCurrentCharges == earthMaxCharges;
            case Rune.SchoolRuneTag.Electricity:
                return electricityCurrentCharges == electricityMaxCharges;
            case Rune.SchoolRuneTag.Ethereal:
                return etherealCurrentCharges == etherealMaxCharges;
            case Rune.SchoolRuneTag.Fire:
                return fireCurrentCharges == fireMaxCharges;
            case Rune.SchoolRuneTag.Ice:
                return iceCurrentCharges == iceMaxCharges;
            case Rune.SchoolRuneTag.Kinetic:
                return kineticCurrentCharges == kineticMaxCharges;
            case Rune.SchoolRuneTag.Life:
                return lifeCurrentCharges == lifeMaxCharges;
            case Rune.SchoolRuneTag.Water:
                return waterCurrentCharges == waterMaxCharges;
            default:
                return true;
        }
    }
}