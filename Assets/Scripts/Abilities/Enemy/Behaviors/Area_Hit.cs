using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Area_Hit", menuName = "ScriptableObjects/Behaviors/Area_Hit")]
public class Area_Hit : EnemyAbilityBehavior
{
    public override void Tick(GameObject gameObject, EnemyAbilityStats enemyAbilityStats)
    {
        var areaTargets = Physics.OverlapCapsule(gameObject.transform.position, gameObject.transform.position + new Vector3(0, 1, 0), enemyAbilityStats.radius, 1 << 8 | 1 << 12);

        foreach (var target in areaTargets)
        {
            if(target.GetComponent<RootUnit>().unitID != enemyAbilityStats.owner)
                enemyAbilityStats.targets.Add(target.GetComponent<RootUnit>().unitID);
        }
    }
}