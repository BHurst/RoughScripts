using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAbilityStats
{
    public Guid owner;
    public string abilityName;
    public float damage;
    public float castTime;
    public Rune.SchoolRuneTag school;
}