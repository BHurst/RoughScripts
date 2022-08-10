using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Grunt : Unit_AI_Base, Unit_AI_Brain
{
    private void Start()
    {
        InitializeAI();
        agent.speed = 8.4315f;
        wanderInterval = Random.Range(1.5f, 3.5f);
    }

    public override RootAbility DetermineAbilityToUse()
    {
        return unit.knownAbilities[0];
    }

    public override void Tick()
    {
        if (unit.isAlive == true)
        {
            if (actionState == AIActionState.Patrolling)
            {
                if (unit.currentTarget == null)
                {
                    Patrol();
                    if (unit.hostility == Hostility.Hostile)
                        FindTarget();
                }
            }
            else if(actionState == AIActionState.Attacking)
            {
                Pursue();
            }
        }
    }
}