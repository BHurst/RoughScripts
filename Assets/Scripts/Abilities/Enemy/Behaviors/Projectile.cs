using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Behaviors/Projectile")]
public class Projectile : EnemyAbilityBehavior
{
    public override void Tick(GameObject gameObject, EnemyAbilityStats enemyAbilityStats)
    {
        enemyAbilityStats.duration += Time.deltaTime;
        if (enemyAbilityStats.duration > enemyAbilityStats.maxDuration)
            Destroy(gameObject);
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * enemyAbilityStats.speed;
    }
}