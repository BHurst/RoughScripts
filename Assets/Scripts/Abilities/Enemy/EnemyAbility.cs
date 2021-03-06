using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAbility", menuName = "ScriptableObjects/Enemy/Ability")]
public class EnemyAbility : ScriptableObject
{
    public EnemyAbilityStats enemyAbilityStats;
    public EnemyAbilityBehavior enemyAbilityBehavior;

    public EnemyWorldAbility CreateWorldAbility(Guid unit)
    {
        GameObject abilityResult = Instantiate(Resources.Load("Prefabs/Abilities/Enemy/EnemyAbilityBase")) as GameObject;
        EnemyWorldAbility worldAbility = abilityResult.GetComponent<EnemyWorldAbility>();
        worldAbility.enemyAbilityStats = enemyAbilityStats.Clone();
        worldAbility.enemyAbilityStats.targets = new List<Guid>();
        worldAbility.enemyAbilityStats.owner = unit;
        worldAbility.enemyAbilityBehavior = enemyAbilityBehavior;

        return worldAbility;
    }
}