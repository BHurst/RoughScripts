using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormRune : Rune
{
    public string formCastAnimation = "";
    public string formPrepareAnimation = "";
    public FormRuneTag formRuneType;
    public string tooltipDamageDescription;
    //Implicit
    public float formDuration = 0;
    public float formArea = 0;
    public float formSpeed = 0;
    public float formInterval = 0;
    public int formMaxAdditionalTargets = 1;
    public HitType hitType = HitType.None;
    //Tertiary
    public float formDamageMod = 0;
    public float formAdditionalTargetsDamageMod = 0;
    public float formResourceCostMod = 0;
    public float formCooldownMod = 0;
    public float formCastSpeedMod = 0;

    public FormRune Clone()
    {
        FormRune newFormRune = new FormRune();
        newFormRune.runeName = runeName;
        newFormRune.runeDescription = runeDescription;
        newFormRune.rank = rank;
        newFormRune.harmful = harmful;
        newFormRune.helpful = helpful;
        newFormRune.selfHarm = selfHarm;
        newFormRune.formRuneType = formRuneType;
        newFormRune.hitType = hitType;
        newFormRune.formDamageMod = formDamageMod;
        newFormRune.formAdditionalTargetsDamageMod = formAdditionalTargetsDamageMod;
        newFormRune.formDuration = formDuration;
        newFormRune.formArea = formArea;
        newFormRune.formSpeed = formSpeed;
        newFormRune.formInterval = formInterval;
        newFormRune.formMaxAdditionalTargets = formMaxAdditionalTargets;
        return newFormRune;
    }

    public virtual string GetTooltipDescription(UnitStats unitStats, BasicAbility ability)
    {
        return "";
    }

    public enum HitType
    {
        None,
        DoT,
        Hit,
        MultiHit
    }
}