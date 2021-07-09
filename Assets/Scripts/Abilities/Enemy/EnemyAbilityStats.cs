using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAbilityStats
{
    public Guid owner;
    public List<Guid> targets;
    public string abilityName;
    public float damage;
    public float castTime;
    public Rune.SchoolRuneTag school;
    public Behavior behavior;
    public float duration = 0;
    public float maxDuration = 5;
    public float speed = 10;
    public float radius = 3;

    public EnemyAbilityStats Clone()
    {
        return (EnemyAbilityStats)MemberwiseClone();
    }

    public enum Behavior
    {
        Projectile,
        Area_Hit
    }
}