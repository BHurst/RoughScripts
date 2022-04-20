using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public FormRuneTag formRuneType;
    public float formDamageMod = 1f;

    public FormRune Clone()
    {
        FormRune temp = new FormRune();
        temp.runeName = runeName;
        temp.runeDescription = runeDescription;
        temp.rank = rank;
        temp.harmful = harmful;
        temp.helpful = helpful;
        temp.selfHarm = selfHarm;
        temp.formRuneType = formRuneType;
        temp.formDamageMod = formDamageMod;
        return temp;
    }

    public override string RuneImageLocation()
    {
        switch (formRuneType)
        {
            case FormRuneTag.Arc:
                return "Abilities/Runes/Forms/Arc";
            case FormRuneTag.Aura:
                return "Abilities/Runes/Forms/Aura";
            case FormRuneTag.Beam:
                return "Abilities/Runes/Forms/Beam";
            case FormRuneTag.Command:
                return "Abilities/Runes/Forms/Command";
            case FormRuneTag.Lance:
                return "Abilities/Runes/Forms/Lance";
            case FormRuneTag.Nova:
                return "Abilities/Runes/Forms/Nova";
            case FormRuneTag.Orb:
                return "Abilities/Runes/Forms/Orb";
            case FormRuneTag.Point:
                return "Abilities/Runes/Forms/Point";
            case FormRuneTag.SelfCast:
                return "Abilities/Runes/Forms/SelfCast";
            case FormRuneTag.Strike:
                return "Abilities/Runes/Forms/Strike";
            case FormRuneTag.Wave:
                return "Abilities/Runes/Forms/Wave";
            case FormRuneTag.Weapon:
                return "Abilities/Runes/Forms/Weapon";
            case FormRuneTag.Zone:
                return "Abilities/Runes/Forms/Zone";
            default:
                return "Abilities/Runes/Forms/Default";
        }
    }

    public float Duration()
    {
        switch (rank)
        {
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
            case 4:
                return 5;
            case 5:
                return 7;
            case 6:
                return 8;
            case 7:
                return 10;
            case 8:
                return 12;
            case 9:
                return 15;
            case 10:
                return 20;
            default:
                return 0;
        }
    }

    public string FormAnimation()
    {
        switch (formRuneType)
        {
            case FormRuneTag.Arc:
                return "triggerMainHandCast";
            case FormRuneTag.Aura:
                return "triggerTwoHandSelfCast";
            case FormRuneTag.Beam:
                return "triggerMainHandCast";
            case FormRuneTag.Command:
                return "triggerMainHandCast";
            case FormRuneTag.Lance:
                return "triggerMainHandCast";
            case FormRuneTag.Nova:
                return "triggerTwoHandSelfCast";
            case FormRuneTag.Orb:
                return "triggerMainHandCast";
            case FormRuneTag.Point:
                return "triggerMainHandCast";
            case FormRuneTag.SelfCast:
                return "triggerTwoHandSelfCast";
            case FormRuneTag.Strike:
                return "triggerMainHandCast";
            case FormRuneTag.Wave:
                return "triggerMainHandCast";
            case FormRuneTag.Weapon:
                return "triggerMainHandCast";
            case FormRuneTag.Zone:
                return "triggerTwoHandSelfCast";
            default:
                return "triggerMainHandCast";
        }
    }
}