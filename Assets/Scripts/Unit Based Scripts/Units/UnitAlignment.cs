using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitAlignment {

    public int Trustworthiness = 0;
    public int Compassion = 0;
    public int Charitability = 0;
    public int Amicability = 0;
    public int Dedication = 0;

    public void ModifyAlignment(string attribute, int mod)
    {
        switch (attribute)
        {
            case "BonusTrustworthiness":
                Trustworthiness += mod;
                if (Trustworthiness < 0)
                    Trustworthiness = 0;
                break;
            case "BonusCompassion":
                Compassion += mod;
                if (Compassion < 0)
                    Compassion = 0;
                break;
            case "BonusCharity":
                Charitability += mod;
                if (Charitability < 0)
                    Charitability = 0;
                break;
            case "BonusAmicability":
                Amicability += mod;
                if (Amicability < 0)
                    Amicability = 0;
                break;
            case "BonusDedication":
                Dedication += mod;
                if (Dedication < 0)
                    Dedication = 0;
                break;
            default:
                break;
        }
    }
}