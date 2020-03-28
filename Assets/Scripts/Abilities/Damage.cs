using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Damage {
    
    public float minimumDamage = 0;
    public float maximumDamage = 0;
    public SpellStats.AbilitySchool abilityBaseDamageType = SpellStats.AbilitySchool.Physical;
}