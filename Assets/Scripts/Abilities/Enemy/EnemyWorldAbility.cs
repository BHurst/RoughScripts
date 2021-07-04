using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorldAbility : MonoBehaviour
{
    public EnemyAbilityStats enemyAbilityStats;
    public EnemyAbilityBehavior enemyAbilityBehavior;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        var target = collider.GetComponent<RootUnit>();
        if (target != null && target.unitID != enemyAbilityStats.owner)
        {
            DamageManager.CalculateEnemyAbilityDefender(collider.transform.GetComponent<RootUnit>().unitID, enemyAbilityStats.damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyAbilityBehavior.Tick(gameObject, enemyAbilityStats);
    }
}