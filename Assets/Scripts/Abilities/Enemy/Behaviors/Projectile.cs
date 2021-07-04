using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Behaviors/Projectile")]
public class Projectile : EnemyAbilityBehavior
{
    public override void Tick(GameObject gameObject, EnemyAbilityStats enemyAbilityStats)
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * 10;
    }
}