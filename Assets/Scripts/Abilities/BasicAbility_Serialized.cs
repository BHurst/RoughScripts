using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BasicAbility_Serialized
{
    public Guid abilityID;
    public string abilityName;
    public bool harmful = false;
    public bool helpful = false;
    public bool selfHarm = false;
    public string castModeRune;
    public string schoolRune;
    public string formRune;
    public List<string> effectRunes;
    public BasicAbility_Serialized abilityToTrigger;
    public int rank = 1;

    public void FillFromUnserialized(BasicAbility bA)
    {
        abilityID = bA.abilityID;
        abilityName = bA.abilityName;
        harmful = bA.harmful;
        helpful = bA.helpful;
        selfHarm = bA.selfHarm;
        castModeRune = bA.castModeRune.ToString();
        schoolRune = bA.schoolRune.ToString();
        formRune = bA.formRune.ToString();
        effectRunes = new List<string>();
        foreach (var eR in bA.effectRunes)
        {
            effectRunes.Add(eR.ToString());
        }
        abilityToTrigger.FillFromUnserialized((BasicAbility)bA.abilityToTrigger);
        rank = bA.rank;
    }
}