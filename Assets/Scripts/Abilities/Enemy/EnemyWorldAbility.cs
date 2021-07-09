using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorldAbility : MonoBehaviour
{
    public EnemyAbilityStats enemyAbilityStats;
    public EnemyAbilityBehavior enemyAbilityBehavior;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Projectile)
        {
            if (collider.gameObject.layer == 9)
                Destroy(gameObject);
            var target = collider.GetComponent<RootUnit>();
            if (target != null && target.unitID != enemyAbilityStats.owner)
            {
                DamageManager.CalculateEnemyAbilityDefender(collider.transform.GetComponent<RootUnit>().unitID, enemyAbilityStats.damage);
                Destroy(gameObject);
            }
        }
        else if (enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Area_Hit)
        {

        }
            
    }

    void Update()
    {
        enemyAbilityBehavior.Tick(gameObject, enemyAbilityStats);
        if(enemyAbilityStats.behavior == EnemyAbilityStats.Behavior.Area_Hit)
        {
            foreach (var target in enemyAbilityStats.targets)
            {
                DamageManager.CalculateEnemyAbilityDefender(target, enemyAbilityStats.damage);
            }
            Destroy(gameObject);
        }
    }
}